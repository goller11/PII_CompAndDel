using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;

namespace CompAndDel.Filters.Pipes {
    class PipeConditional : IPipe {
        protected IFilterBool filtroBool;
        protected IPipe nextPipe;

        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="filtro">Filtro que se debe aplicar sobre la imagen</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeConditional (IFilterBool filtroBool, IPipe nextPipe) 
        {
            this.filtroBool = filtroBool;
            this.nextPipe = nextPipe;
        }
        /// <summary>
        /// Devuelve el proximo IPipe
        /// </summary>
        public IPipe Next {
            get { return this.nextPipe; }
        }
        /// <summary>
        /// Devuelve el IFilter que aplica este pipe
        /// </summary>
        public bool Filter {
            get { return this.filtroBool; }
        }
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send (IPicture picture) {
            picture = this.filtro.Filter (picture);
            return this.nextPipe.Send (picture);
        }
    }
}