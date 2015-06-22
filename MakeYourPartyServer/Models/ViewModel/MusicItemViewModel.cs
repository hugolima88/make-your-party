using Google.Apis.YouTube.v3.Data;
using MakeYourPartyServer.YouTube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.Models.ViewModel
{
    public class MusicItemViewModel
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public string InnerHtmlPlayer { get; set; }

        public MusicItemViewModel() { }

        public MusicItemViewModel (SearchResult video)
        {
            this.VideoId = video.Id.VideoId;
            this.Title = video.Snippet.Title;
            this.Description = video.Snippet.Description;

            this.Thumbnail = "<img src=\"" + video.Snippet.Thumbnails.Default.Url + "\" alt=\"" + this.Title + "\" />";

            this.InnerHtmlPlayer = YouTubeHelper.GetEmbeddedPlayerHTML(video.Id.VideoId);

        }
    }
}