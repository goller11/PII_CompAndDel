using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CognitiveCore;
using CompAndDel;

namespace CompAndDel.Filters.Pipes {
    public class PipeConditional : IPipe {

        public IFilterBool filtro;
        public IPipe nextPipeTrue;
        public IPipe nextPipeFalse;

        public PipeConditional (IFilterBool filtroBool, IPipe nextPipeTrue, IPipe nextPipeFalse) {
            this.filtro = filtroBool;
            this.nextPipeTrue = nextPipeTrue;
            this.nextPipeFalse = nextPipeFalse;
        }
        
        public IPicture Send (IPicture picture) {
            
            picture = this.filtro.Filter(picture);

            if (this.filtro.FaceOrNot) {
                Console.WriteLine ("Face Found! :)");
                return this.nextPipeTrue.Send(picture);
            } else {
                Console.WriteLine ("No Face Found :(");
                return this.nextPipeFalse.Send(picture);
            }
        }
    }
}