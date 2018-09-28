using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using CognitiveCore;
using CompAndDel;

namespace CompAndDel.Filters {
    public class FilterCognitive : IFilterBool {
        CognitiveFace cognitiveFace = new CognitiveFace ("6cc93ca750fc4e0b9b716925f303dcc1", Color.GreenYellow);
        public bool FaceOrNot { get; set; }

        PictureProvider imgProvider = new PictureProvider ();
        public IPicture Filter(IPicture image) {

            imgProvider.SavePicture (image, "TempBreakingBAD.jpg");
            cognitiveFace.Recognize (@"TempBreakingBAD.jpg");

            FaceOrNot = cognitiveFace.FaceFound;

            IPicture imagen = imgProvider.GetPicture ("tmpFace.jpg");
            return imagen;
        }
    }
}