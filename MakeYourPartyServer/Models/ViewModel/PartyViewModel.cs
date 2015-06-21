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
            this.Password = model.Password;
        }

        public PartyViewModel() { }

        public virtual UserModel User { get; set; }

        public ICollection<InviteModel> Invites { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}