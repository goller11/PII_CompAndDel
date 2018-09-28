using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CognitiveCore;
using CompAndDel;
using CompAndDel.Filters;

namespace CompAndDel.Filters.Pipes {
    class PipeConditional : IPipe {
        protected IFilterBool filtroBool;
        protected IPipe nextPipeTrue;
        protected IPipe nextPipeFalse;

        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="filtroBool">Filtro que se debe aplicar sobre la imagen</param>
        /// <param name="nextPipeTrue">Siguiente cañería si reconoce una cara</param>
        /// <param name="nextPipeFalse">Siguiente cañería si no reconoce una cara</param>
        public PipeConditional (IFilterBool filtroBool, IPipe nextPipeTrue, IPipe nextPipeFalse) {
            this.filtroBool = filtroBool;
            this.nextPipeTrue = nextPipeTrue;
            this.nextPipeFalse = nextPipeFalse;
        }
        public IFilter Filter {
            get { return this.filtroBool; }
        }
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>

        public IPicture Send (IPicture picture) {
            this.filtroBool.Filter (picture);

            if (this.filtroBool.FaceOrNot) {
                Console.WriteLine ("¡Se ha encontrado una cara!");
                return this.nextPipeTrue.Send (picture);
            } else {
                Console.WriteLine ("No se ha encontrado nada...");
                return this.nextPipeFalse.Send (picture);
            }
        }
    }
}