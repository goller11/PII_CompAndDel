using System;
using CompAndDel.Filters;
using CompAndDel.Filters.Pipes;
using twitterPublisher;

namespace CompAndDel {
    class Program {
        static void Main (string[] args) {

            PictureProvider imgProvider = new PictureProvider ();
            IPicture pictureProv = imgProvider.GetPicture ("Vikings.jpg");

            IConvolution matrix = new BlurConvolutionMatriz();
            FilterConvolution blurFilter = new FilterConvolution (matrix);
            
            
            FilterNegative negativeFilter = new FilterNegative ();
            FilterTwitter twitterFilter = new FilterTwitter ();
            FilterCognitive faceRecognition = new FilterCognitive();

            
            PipeNull pipeEnd = new PipeNull ();
            PipeSerial pipeTwitter = new PipeSerial (twitterFilter, pipeEnd);
            PipeSerial pipeBlur = new PipeSerial (blurFilter, pipeEnd);
            PipeSerial pipeNegative = new PipeSerial (negativeFilter, pipeEnd);

            PipeConditional pipeFace = new PipeConditional(faceRecognition, pipeTwitter, pipeNegative);

            imgProvider.SavePicture (pipeFace.Send(pictureProv), "Vikings.jpg");
        }
    }
}