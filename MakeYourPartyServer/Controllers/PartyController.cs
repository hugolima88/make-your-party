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
        public ActionResult CreateParty(PartyModel model)
        {
            // Validate if the user already has a party running


            ModelState.Remove("UserId");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var context = new ApplicationDbContext())
            {
                string loginUserId = User.Identity.GetUserId();
                model.UserId = loginUserId;
                var party = context.Parties.Add(model);

                context.SaveChanges();
                return View("Party", party);
            }
        }
    }
}