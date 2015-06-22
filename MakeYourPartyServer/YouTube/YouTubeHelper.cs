using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using MakeYourPartyServer.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MakeYourPartyServer.YouTube
{
    public static class YouTubeHelper
    {

        /// <summary>
        /// Gets the embedded player HTML using default settings.
        /// </summary>
        /// <param name="videoId">The video id.</param>
        /// <example>
        /// <code>
        /// div_to_hold_player.InnerHtml = googleAPI.GetEmbeddedPlayerHTML(video_id)
        /// </code>
        /// </example>
        /// <returns>html string for inserting embedded player</returns>
        public static string GetEmbeddedPlayerHTML(string videoId)
        {
            return GetPlayerCode(videoId + EncodePlayerSettingsFromYouTubePlayerObjectToQueryString(new YouTubePlayer()));
        }

        /// <summary>
        /// Encodes the player settings from you tube player object to query string.
        /// </summary>
        /// <param name="player">The YouTubePlayer.</param>
        /// <returns>string (encoded querystring)</returns>
        private static string EncodePlayerSettingsFromYouTubePlayerObjectToQueryString(YouTubePlayer player)
        {
            var sb = new StringBuilder();

            sb.Append("?rel=" + player.LoadRelatedVideos);

            if (player.AutoPlay == 1)
                sb.Append("&autoplay=" + player.AutoPlay);

            if (player.Loop == 1)
                sb.Append("&loop=" + player.Loop);

            if (player.EnableJavaScriptAPI == 1)
                sb.Append("&enablejsapi=" + player.EnableJavaScriptAPI);

            sb.Append("&playerapiid=" + player.PlayerAPIId);

            if (player.DisableKeyboard == 1)
                sb.Append("&disablekb=" + player.DisableKeyboard);

            if (player.EnhancedGenieMenu == 1)
                sb.Append("&egm=" + player.EnhancedGenieMenu);

            if (player.Border == 1)
                sb.Append("&border=" + player.Border);

            if (!string.IsNullOrEmpty(player.PrimaryBorderColor))
                sb.Append("&color1=" + player.PrimaryBorderColor);

            if (!string.IsNullOrEmpty(player.SecondaryBorderColor))
                sb.Append("&color2=" + player.SecondaryBorderColor);

            if (player.SecondsFromStart > 0)
                sb.Append("&start=" + player.SecondsFromStart);

            if (player.FullScreen == 1)
                sb.Append("&fs=" + player.FullScreen);

            if (player.HD == 1)
                sb.Append("&hd=" + player.HD);

            if (player.ShowSearchBox == 0)
                sb.Append("&showsearch=" + player.ShowSearchBox);

            if (player.ShowVideoInfo == 0)
                sb.Append("&showinfo=" + player.ShowVideoInfo);

            if (player.VideoAnnotations == 3)
                sb.Append("&iv_load_policy=" + player.VideoAnnotations);

            return sb.ToString();
        }

        /// <summary>
        /// Gets the player code.
        /// </summary>
        /// <param name="videoURL">The video URL.</param>
        /// <returns></returns>
        private static string GetPlayerCode(string videoURL)
        {
            var sb = new StringBuilder();

            sb.Append("<object width=\"" + GlobalConstants.GoogleAPI.YouTubePlayerWidth + "\" height=\"" + GlobalConstants.GoogleAPI.YouTubePlayerHeight + "\">");
            sb.Append("<param name=\"movie\" value=\"http://www.youtube.com/v/" + videoURL + "\"></param>");
            sb.Append("<param name=\"allowFullScreen\" value=\"true\"></param>");
            sb.Append("<embed src=\"http://www.youtube.com/v/" + videoURL + "\" type=\"application/x-shockwave-flash\" width=\""
                + GlobalConstants.GoogleAPI.YouTubePlayerWidth + "\" height=\""
                + GlobalConstants.GoogleAPI.YouTubePlayerHeight + "\" allowfullscreen=\"true\"></embed>");
            sb.Append("</object>");

            return sb.ToString();
        }

        public static IList<MusicItemViewModel> SearchMusic(string searhText)
        {
            var list = new List<MusicItemViewModel>();

            YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApplicationName = "makeyourparty",
                ApiKey = "AIzaSyB7CGRV2U5wMJFQ3xKoeFgKmDHq5OeUgbE",
            });
            
            SearchResource.ListRequest listRequest = youtube.Search.List("snippet");
            listRequest.Q = searhText;
            listRequest.MaxResults = 5;
            listRequest.Type = "video";
            
            SearchListResponse resp = listRequest.Execute();
            
            foreach (SearchResult result in resp.Items)
            {
                list.Add(new MusicItemViewModel(result));

            }

            return list;
        }
    }
}