using MakeYourPartyServer.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.Models
{
    public class PartyViewModel
    {
        public PartyViewModel(PartyModel model)
        {
            this.UserId = model.UserId;
            this.Invites = model.Invites;
            this.PartyCode = model.PartyCode;
            this.PartyId = model.Id;
        }

        public PartyViewModel() { }

        public string UserId { get; set; }

        public ICollection<InviteModel> Invites { get; set; }

        [Required]
        [Display(Name = "Private Code")]
        public string PartyCode { get; set; }

        public int PartyId { get; set; }

        public string SearchText { get; set; }

        public IList<MusicItemViewModel> MusicList { get; set; }
    }
}