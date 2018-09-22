using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using CompAndDel;
using twitterPublisher;

namespace CompAndDel.Filters {
    public class TwitterFilter : IFilter {
        string consumerKey = "XnIleywqqB5rO00H7SMJdMekX";
        string consumerKeySecret = "hI5ugPxcSaJhkznhLUxNr1IiTfsIHFcva2rqCiXhL7M92kSi3p";
        string accessToken = "1017550784354021376-6dzrn5TPasnEynp4wZ224XfUwdaLKn";
        string accessTokenSecret = "b1Qqhryvvrgd0TNRoNZbipocNonKfeCnkvdEtrAAcs278";

        public IPicture Filter (IPicture image) {

            var imageTwitter = new TwitterImage (consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
            imageTwitter.PublishToTwitter ("Breaking", "BreakingBadNegative.jpg");
            return image;
        }
    }

}