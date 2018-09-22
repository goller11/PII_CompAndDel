using System;
using CompAndDel.Filters;
using CompAndDel.Filters.Pipes;
using twitterPublisher;

namespace CompAndDel {
    class Program {
        static void Main (string[] args) {

            PictureProvider img = new PictureProvider ();
            IPicture image = img.GetPicture ("BreakingBad.jpg");

            IFilter negative = new FilterNegative ();
            IFilter twitterPub = new TwitterFilter ();

            IPipe end = new PipeNull ();
            IPipe twitter = new PipeSerial (twitterPub, end);
            IPipe serial = new PipeSerial (negative, twitter);

            img.SavePicture (serial.Send(image), "BreakingBadNegative.jpg");          

        }
    }
}