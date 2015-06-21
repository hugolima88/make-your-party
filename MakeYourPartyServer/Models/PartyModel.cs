using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.Models
{
    public class PartyModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual UserModel User { get; set; }

        public virtual ICollection<InviteModel> Invites { get; set; }

        public string Password { get; set; }
    }
}