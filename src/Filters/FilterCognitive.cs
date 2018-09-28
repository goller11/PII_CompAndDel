using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using CognitiveCore;
using CompAndDel;

namespace CompAndDel.Filters {
    public class FilterCognitive : IFilterBool {
        CognitiveFace cogni = new CognitiveFace ("6cc93ca750fc4e0b9b716925f303dcc1", Color.GreenYellow);

        public IPicture Filter (IPicture cognitive) {

            PictureProvider img = new PictureProvider ();
            img.SavePicture (cognitive, "Facial.jpg");
            cogni.Recognize (@"BreakingBAD.jpg");
            FoundFace (cogni);
        }
    }
}