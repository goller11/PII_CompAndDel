using System;
using CompAndDel.Filters;
using CompAndDel.Filters.Pipes;
using twitterPublisher;

namespace CompAndDel {
    class Program {
        static void Main (string[] args) {

            PictureProvider imgProvider = new PictureProvider ();
            IPicture pictureP = imgProvider.GetPicture ("BreakingBAD.jpg");

            IConvolution matrix = new BlurConvolutionMatriz ();

            IFilter blurFilter = new FilterConvolution (matrix);
            IFilter negativeFilter = new FilterNegative ();
            IFilter twitterFilter = new TwitterFilter ();

            FilterCognitive faceRecognition = new FilterCognitive ();

            IPipe pipeEnd = new PipeNull ();
            //IPipe pipeTwitter = new PipeSerial (twitterPub, pipeEnd);
            IPipe pipeSerial = new PipeSerial (blurFilter, pipeEnd);
            IPipe pipeSerial2 = new PipeSerial (negativeFilter, pipeEnd);
            PipeConditional pipeFace = new PipeConditional (faceRecognition, pipeEnd, pipeSerial2);

/* Si reconoce la cara, pasa directamente al Null,
de otra forma, se le aplica el filtro negativo.*/
            
            imgProvider.SavePicture (pipeFace.Send (pictureP), "BreakingBadFace.jpg"); // Guarda la imagen con el nombre que se le adjudica       
            //imgProvider.SavePicture (pipeSerial2.Send (pictureP), "BreakingBadNegative.jpg");
        }
    }
}