using MakeYourPartyServer.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.Models
{
    public class SearchMusicResultViewModel
    {
        public SearchMusicResultViewModel(IList<MusicItemViewModel> results, int partyId, string userId)
        {
            this.UserId = userId;
            this.Results = results;
            this.PartyId = partyId;
        }

        public SearchMusicResultViewModel() { }

        public string UserId { get; set; }

        public IList<MusicItemViewModel> Results { get; set; }

        public int PartyId { get; set; }
    }
}