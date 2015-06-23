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
        public JsonResult SearchMusics(string SearchText)
        {
            var musicList = YouTubeHelper.SearchMusic(SearchText);
            return Json(musicList);
        }
    }
}