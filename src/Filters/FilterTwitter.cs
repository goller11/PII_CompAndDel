using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using CompAndDel;
using twitterPublisher;

namespace CompAndDel.Filters {
    public class FilterTwitter : IFilter {
        /// <summary>
        /// Recibe una imagen y la retorna con un filtro del tipo negativo aplicado
        /// </summary>
        /// <param name="image">Imagen a la cual se le va a plicar el filtro.</param>
        /// <returns>Imagen con el filtro aplicado</returns>
        public IPicture Filter (IPicture image) {
            string consumerKey = "XnIleywqqB5rO00H7SMJdMekX";
            string consumerKeySecret = "hI5ugPxcSaJhkznhLUxNr1IiTfsIHFcva2rqCiXhL7M92kSi3p";
            string accessToken = "1017550784354021376-6dzrn5TPasnEynp4wZ224XfUwdaLKn";
            string accessTokenSecret = "b1Qqhryvvrgd0TNRoNZbipocNonKfeCnkvdEtrAAcs278";

            PictureProvider pictureProvider = new PictureProvider ();
            
            var twitterPub = new TwitterImage (consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
            Console.WriteLine (twitterPub.PublishToTwitter ("Trying", @"tmpFace.jpg"));

            return image;
        }
    }
}