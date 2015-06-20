using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.Models
{
    [Table("PartyMusics")]
    public class PartyMusicModel
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }

        [Required]
        public string MusicLink { get; set; }
    }
}