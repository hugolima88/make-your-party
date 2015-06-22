using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.YouTube
{
    /// <summary>
    /// Wrapper for all the settings for the You Tube embedded player
    /// </summary>
    public class YouTubePlayer
    {
        public YouTubePlayer()
        {
            LoadRelatedVideos = 1;
            AutoPlay = 0;
            Loop = 0;
            EnableJavaScriptAPI = 0;
            PlayerAPIId = string.Empty;
            DisableKeyboard = 0;
            EnhancedGenieMenu = 0;
            Border = 0;
            PrimaryBorderColor = "#FFFFFF";
            SecondaryBorderColor = "#FFFFFF";
            SecondsFromStart = 0;
            FullScreen = 1;
            HD = 0;
            ShowSearchBox = 0;
            ShowVideoInfo = 0;
            VideoAnnotations = 3;
        }

        /// <summary>
        /// Values: 0 or 1. Default is 1. Sets whether the player should load related videos once playback of the initial video starts. 
        /// Related videos are displayed in the "genie menu" when the menu button is pressed. 
        /// The player search functionality will be disabled if rel is set to 0.
        /// </summary>
        /// <value>0 or 1</value>
        public int LoadRelatedVideos { get; set; }

        /// <summary>
        /// Values: 0 or 1. Default is 0. Sets whether or not the initial video will autoplay when the player loads.
        /// </summary>
        /// <value>0 or 1</value>
        public int AutoPlay { get; set; }

        /// <summary>
        /// Values: 0 or 1. Default is 0. In the case of a single video player, a setting of 1 will cause the player to play the initial video again 
        /// and again. In the case of a playlist player (or custom player), the player will play the entire playlist and then start again at the first video.
        /// </summary>
        /// <value>0 or 1</value>
        public int Loop { get; set; }

        /// <summary>
        /// Values: 0 or 1. Default is 0. Setting this to 1 will enable the Javascript API. For more information on the Javascript API 
        /// and how to use it, see the JavaScript API documentation.
        /// </summary>
        /// <see cref="http://code.google.com/apis/youtube/js_api_reference.html"/>
        /// <value>0 or 1</value>
        public int EnableJavaScriptAPI { get; set; }

        /// <summary>
        /// Value can be any alphanumeric string. This setting is used in conjunction with the JavaScript API. See the JavaScript API documentation for details.
        /// </summary>
        /// <see cref="http://code.google.com/apis/youtube/js_api_reference.html"/>
        /// <value>The player API id (any alphanumeric string)</value>
        public string PlayerAPIId { get; set; }

        /// <summary>
        /// Values: 0 or 1. Default is 0. Setting to 1 will disable the player keyboard controls. Keyboard controls are as follows: 
        /// Spacebar: Play / Pause 
        /// Arrow Left: Restart current video 
        /// Arrow Right: Jump ahead 10% in the current video 
        /// Arrow Up: Volume up 
        /// Arrow Down: Volume Down
        /// </summary>
        /// <value>0 or 1</value>
        public int DisableKeyboard { get; set; }

        /// <summary>
        /// Values: 0 or 1. Default is 0. Setting to 1 enables the "Enhanced Genie Menu". This behavior causes the genie menu (if present) to appear 
        /// when the user's mouse enters the video display area, as opposed to only appearing when the menu button is pressed.
        /// </summary>
        /// <value>0 or 1</value>
        public int EnhancedGenieMenu { get; set; }

        /// <summary>
        /// Values: 0 or 1. Default is 0. Setting to 1 enables a border around the entire video player. The border's primary color can be set via 
        /// the color1 (PrimaryBorderColor) parameter, and a secondary color can be set by the color2 (SecondaryBorderColor) parameter.
        /// </summary>
        /// <value>0 or 1</value>
        public int Border { get; set; }

        /// <summary>
        /// Values: Any RGB value in hexadecimal format. This is the primary border color.
        /// </summary>
        /// <value>RGB value in hexadecimal format</value>
        public string PrimaryBorderColor { get; set; }

        /// <summary>
        /// Values: Any RGB value in hexadecimal format. This is the video control bar background color and secondary border color.
        /// </summary>
        /// <value>RGB value in hexadecimal format</value>
        public string SecondaryBorderColor { get; set; }

        /// <summary>
        /// Values: A positive integer. This parameter causes the player to begin playing the video at the given number of seconds from the start of the video. 
        /// Similar to the seekTo function, the player will look for the closest keyframe to the time you specify. 
        /// This means sometimes the play head may seek to just before the requested time, usually no more than ~2 seconds.
        /// </summary>
        /// <value>A positive integer</value>
        public int SecondsFromStart { get; set; }

        /// <summary>
        /// Values: 0 or 1. Default is 0. Setting to 1 enables the fullscreen button. This has no effect on the Chromeless Player. 
        /// Note that you must include some extra arguments to your embed code for this to work. The param allowfullscreen of the below example enable fullscreen functionality:
        /// </summary>
        /// <value>0 or 1</value>
        // <object width="425" height="344">
        // <param name="movie" value="http://www.youtube.com/v/u1zgFlCw8Aw&fs=1"</param>
        // <param name="allowFullScreen" value="true"></param>
        // <embed src="http://www.youtube.com/v/u1zgFlCw8Aw&fs=1"
        // type="application/x-shockwave-flash"
        // allowfullscreen="true"
        // width="425" height="344">
        // </embed>
        // </object>
        public int FullScreen { get; set; }

        /// <summary>
        /// Values: 0 or 1. Default is 0. Setting to 1 enables HD playback by default. This has no effect on the Chromeless Player. 
        /// This also has no effect if an HD version of the video is not available. If you enable this option, keep in mind that users with a 
        /// slower connection may have an sub-optimal experience unless they turn off HD. You should ensure your player is large enough to 
        /// display the video in its native resolution.
        /// </summary>
        /// <value>0 or 1</value>
        public int HD { get; set; }

        /// <summary>
        /// Values: 0 or 1. Default is 1. Setting to 0 disables the search box from displaying when the video is minimized. 
        /// If the rel (LoadRelatedVideos) parameter is set to 0 then the search box will also be disabled, regardless of the value of showsearch.
        /// </summary>
        /// <value>0 or 1</value>
        public int ShowSearchBox { get; set; }

        /// <summary>
        /// Values: 0 or 1. Default is 1. Setting to 0 causes the player to not display information like the video title and rating before the video starts playing.
        /// </summary>
        /// <value>0 or 1</value>
        public int ShowVideoInfo { get; set; }

        /// <summary>
        /// Values: 1 or 3. Default is 1. Setting to 1 will cause video annotations to be shown by default, whereas setting to 3 will cause video annotation to not be shown by default.
        /// </summary>
        /// <value>1 or 3</value>
        public int VideoAnnotations { get; set; }
    }
}