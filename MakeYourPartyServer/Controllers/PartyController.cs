using MakeYourPartyServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using Google.Apis.Samples.Helper;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using MakeYourPartyServer.Models.ViewModel;
using MakeYourPartyServer.YouTube;

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
        [ValidateAntiForgeryToken]
        public ActionResult SearchVideo(PartyViewModel model)
        {
            ModelState.Remove("PartyCode");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.MusicList = YouTubeHelper.SearchMusic(model.SearchText);

            return View("Party", model);
        }
    }
}