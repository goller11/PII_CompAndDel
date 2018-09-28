using System;
using CompAndDel.Filters;
using CompAndDel.Filters.Pipes;
using twitterPublisher;

namespace CompAndDel {
    class Program {
        static void Main (string[] args) {

            PictureProvider imgProvider = new PictureProvider ();
            IPicture pictureP = imgProvider.GetPicture ("BreakingBAD.jpg"); // "Recoge" la imagen 

            IConvolution matrix = new BlurConvolutionMatriz ();

            IFilter blurFilter = new FilterConvolution (matrix);
            IFilter negativeFilter = new FilterNegative (); // Creación del filtro negativo
            IFilter twitterFilter = new TwitterFilter (); //Creación del filtro de Twitter para publicar
            FilterCognitive faceRecognition = new FilterCognitive();

            IPipe pipeEnd = new PipeNull (); // Pipe donde termina el programa
            //IPipe pipeTwitter = new PipeSerial (twitterPub, pipeEnd); // PipeSerial para publicar en Twitter y llevar la imagen al último Pipe
            IPipe pipeBlur = new PipeSerial (blurFilter, pipeEnd); // PipeSerial para aplicarle el filtro NEGATIVO y pasaje al segundo Pipe 
            IPipe pipeNegative = new PipeSerial (negativeFilter, pipeEnd);
            PipeConditional pipeFace = new PipeConditional(faceRecognition, pipeEnd, pipeNegative)

            imgProvider.SavePicture (pipeFace.Send (pictureP), "BreakingBadFace.jpg"); // Guarda la imagen con el nombre que se le adjudica       
            imgProvider.SavePicture (pipeNegative.Send (pictureP), "BreakingBadNegative.jpg");
        }
    }
}