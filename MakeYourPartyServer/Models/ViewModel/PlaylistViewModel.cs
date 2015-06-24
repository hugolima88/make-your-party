using Google.Apis.YouTube.v3.Data;
using MakeYourPartyServer.YouTube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.Models.ViewModel
{
    public class PlaylistViewModel
    {
        public string VideoId { get; set; }
        public string Title { get; set; }

        public PlaylistViewModel() { }

        public PlaylistViewModel(MusicModel video)
        {
            this.VideoId = video.VideoId;
            this.Title = video.Title;
        }
    }
}