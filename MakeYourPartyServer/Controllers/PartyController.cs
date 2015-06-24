using MakeYourPartyServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Collections;
using Google.Apis.Samples.Helper;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using MakeYourPartyServer.Models.ViewModel;
using MakeYourPartyServer.YouTube;
using Newtonsoft.Json;
using System.Data.Entity.Validation;

namespace MakeYourPartyServer.Controllers
{
    public class PartyController : Controller
    {
        public ActionResult CreateParty()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateParty(PartyViewModel model)
        {
            // Validate if the user already has a party running

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var context = new ApplicationDbContext())
            {
                var partyModel = new PartyModel()
                {
                    UserId = User.Identity.GetUserId(),
                    PartyCode = model.PartyCode
                };

                partyModel = context.Parties.Add(partyModel);
                context.SaveChanges();

                return View("Party", new PartyViewModel(partyModel));
            }
        }


        [HttpPost]
        public ActionResult SearchMusics(string searchText, int partyId, string userId)
        {
            var musicList = YouTubeHelper.SearchMusic(searchText);
            return PartialView("_SearchResult", new SearchMusicResultViewModel(musicList, partyId, userId));
        }

        [HttpPost]
        public ActionResult AddToPlaylist(string title, string videoId, int partyId, string userId)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var musicModel = new MusicModel()
                    {
                        PartyId = partyId,
                        VideoId = videoId,
                        Title = title,
                        UserId = userId
                    };

                    musicModel = context.Musics.Add(musicModel);
                    context.SaveChanges();
                    var musicList = (from u in context.Musics
                                     where u.PartyId == partyId
                                     select u).ToList();

                    var playlist = new List<PlaylistViewModel>();

                    foreach (var music in musicList)
                        playlist.Add(new PlaylistViewModel(music));

                    return PartialView("_Playlist", playlist);
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}