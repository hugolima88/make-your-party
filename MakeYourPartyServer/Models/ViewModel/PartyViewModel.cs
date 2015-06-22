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
            this.User = model.User;
            this.Invites = model.Invites;
            this.PartyCode = model.PartyCode;
        }

        public PartyViewModel() { }

        public virtual UserModel User { get; set; }

        public ICollection<InviteModel> Invites { get; set; }

        [Required]
        [Display(Name = "Party Code")]
        public string PartyCode { get; set; }

        public string SearchText { get; set; }

        public IList<MusicItemViewModel> MusicList { get; set; }
    }
}