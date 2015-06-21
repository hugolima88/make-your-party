using MakeYourPartyServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
                    Password = model.Password
                };

                partyModel = context.Parties.Add(partyModel);
                context.SaveChanges();

                return View("Party", new PartyViewModel(partyModel));
            }
        }
    }
}