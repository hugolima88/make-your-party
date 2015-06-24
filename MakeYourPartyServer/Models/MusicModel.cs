using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.Models
{
    public class MusicModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual UserModel User { get; set; }

        public string Title { get; set; }

        public string VideoId { get; set; }

        public int PartyId { get; set; }
    }
}