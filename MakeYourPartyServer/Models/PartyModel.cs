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
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string Id_User { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}