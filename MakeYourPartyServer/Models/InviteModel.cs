using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.Models
{
    [Table("Invites")]
    public class InviteModel
    {
        [Required, Key, Column(Order = 0)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }

        [Required, Key, Column(Order = 1)]
        public int PartyId { get; set; }

        [ForeignKey("PartyId")]
        public virtual PartyModel Party { get; set; }
    }
}