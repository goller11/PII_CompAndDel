using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;

namespace CompAndDel.Filters.Pipes
{
    public class PipeConditional : IPipe
    {
        public IFilterBool filtroBool;
        public IPipe nextPipeTrue;
        public IPipe nextPipeFalse;
        
        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="filtro">Filtro que se debe aplicar sobre la imagen</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeConditional(IFilterBool filtro, IPipe nextPipeTrue, IPipe nextPipeFalse)
        {
            this.filtroBool = filtro;            
            this.nextPipeTrue = nextPipeTrue;
            this.nextPipeFalse = nextPipeFalse;
        }
        public IFilter filter
        {
            get { return this.filtroBool; }
        }
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture picture)
        {
            IPicture picture1 = this.filtroBool.Filter(picture);

            if (this.filtroBool.FaceOrNot)
            {
                Console.WriteLine("Face Found! :)");
                return this.nextPipeTrue.Send(picture1);
            }
            else
            {
                Console.WriteLine("No Face Found :(");
                return this.nextPipeFalse.Send(picture1);

            }
        }
    }
}