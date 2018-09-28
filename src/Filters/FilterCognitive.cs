using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using CognitiveCore;
using CompAndDel;

namespace CompAndDel.Filters {
    public class FilterCognitive : IFilterBool {
        CognitiveFace cognitiveFace = new CognitiveFace ("e927a605774f4d7e84cd8304988c8c3b", Color.Black);
        public bool FaceOrNot { get; set; }
        PictureProvider imageProvider = new PictureProvider ();
        public IPicture Filter (IPicture image) {

            imageProvider.SavePicture (image, "TempVikings.jpg");
            cognitiveFace.Recognize (@"TempVikings.jpg");

            FaceOrNot = cognitiveFace.FaceFound;

            IPicture imagen = imageProvider.GetPicture("TempVikings.jpg");
            return imagen;
        }
    }
}