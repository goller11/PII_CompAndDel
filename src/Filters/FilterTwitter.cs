using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using CompAndDel;
using twitterPublisher;

namespace CompAndDel.Filters {
    public class TwitterFilter : IFilter {
        string consumerKey = "";
        string consumerKeySecret = "";
        string accessToken = "";
        string accessTokenSecret = "";

        public IPicture Filter (IPicture image) {

            var imageTwitter = new TwitterImage (consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
            imageTwitter.PublishToTwitter ("Breaking", "BreakingBadNegative.jpg");
            return image;
        }
    }

}
