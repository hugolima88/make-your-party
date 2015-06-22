using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.YouTube
{
    /// <summary>
    /// Global constants for the solution
    /// </summary>
    public class GlobalConstants
    {
        #region GoogleAPI
        /// <summary>
        /// Constants required to use the Google API
        /// </summary>
        public class GoogleAPI
        {
            /// <summary>
            /// YouTube player width
            /// </summary>
            public const string YouTubePlayerWidth = "425";
            /// <summary>
            /// YouTube player height
            /// </summary>
            public const string YouTubePlayerHeight = "355";
            /// <summary>
            /// Google API Developer Key - your developer key
            /// </summary>
            public const string DeveloperKey = "AIzaSyB7CGRV2U5wMJFQ3xKoeFgKmDHq5OeUgbE";
            public const string ApplicationName = "makeyourparty";
            /// <summary>
            /// http://gdata.youtube.com - required for Authsub
            /// </summary>
            public const string YouTubeScope = "http://gdata.youtube.com";
            /// <summary>
            /// http://gdata.youtube.com/feeds/api/videos/ - used to get Video object
            /// </summary>
            public const string VideoEntryURL = YouTubeScope + "/feeds/api/videos/";
        }
        #endregion
    }
}