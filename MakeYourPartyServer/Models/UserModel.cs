using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MakeYourPartyServer.Models
{
    public class UserModel : IdentityUser
    {
        public virtual ICollection<PartyModel> Parties { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserModel> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}