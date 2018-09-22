using System;
using CompAndDel.Filters;
using CompAndDel.Filters.Pipes;
using twitterPublisher;

namespace CompAndDel {
    class Program {
        static void Main (string[] args) {

            PictureProvider img = new PictureProvider (); 
            IPicture image = img.GetPicture ("BreakingBad.jpg"); // "Recoge" la imagen 

            IFilter negative = new FilterNegative (); // Creación del filtro negativo
            IFilter twitterPub = new TwitterFilter (); //Creación del filtro de Twitter para publicar

            IPipe end = new PipeNull (); // Pipe donde termina el programa
            IPipe twitter = new PipeSerial (twitterPub, end); // PipeSerial para publicar en Twitter y llevar la imagen al último Pipe
            IPipe serial = new PipeSerial (negative, twitter); // PipeSerial para aplicarle el filtro NEGATIVO y pasaje al segundo Pipe 

            img.SavePicture (serial.Send(image), "BreakingBadNegative.jpg"); // Guarda la imagen con el nombre que se le adjudica       

        }
    }
}