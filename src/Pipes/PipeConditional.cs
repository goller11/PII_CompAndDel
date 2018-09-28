using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;

namespace CompAndDel.Filters.Pipes {
    class PipeConditional : IPipe {

        protected IFilter filtro;
        protected IFilterBool filtroBool;
        protected IPipe nextPipeTrue;
        protected IPipe nextPipeFalse;

        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="filtro">Filtro que se debe aplicar sobre la imagen</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeConditional (IFilterBool filtroBool, IPipe nextPipeTrue, IPipe nextPipeFalse) {
            this.filtroBool = filtroBool;
            this.nextPipeTrue = nextPipeTrue;
            this.nextPipeFalse = nextPipeFalse;
        }
        
        public IFilter Filter {
            get { return this.filtro; }
        }

    public IPicture Send(IPicture picture)
        {
            picture = this.filtro.Filter(picture);

            if (this.filtro.Boolean)
            {
                Console.WriteLine("Face Found! :)");
                return this.nextPipeTrue.Send(picture);
            }
            else
            {
                Console.WriteLine("No Face Found :(");
                return this.nextPipeFalse.Send(picture);
            }
        }
}
}