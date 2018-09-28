using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CognitiveCore;

namespace CompAndDel.Filters.Pipes {
        class PipeConditional : IPipe {

<<<<<<< HEAD
                public bool FaceOrNot;
                protected IFilter filtro;
                protected IPipe nextPipeTrue;
                protected IPipe nextPipeFalse;

                /// <summary>
                /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
                /// </summary>
                /// <param name="filtro">Filtro que se debe aplicar sobre la imagen</param>
                /// <param name="nextPipe">Siguiente cañería</param>
                public PipeConditional (IFilter filtro, IPipe nextPipeTrue, IPipe nextPipeFalse) {
                    this.filtro = filtro;
                    this.nextPipeTrue = nextPipeTrue;
                    this.nextPipeFalse = nextPipeFalse;
                }
                /// <summary>
                /// Devuelve el proximo IPipe
                /// </summary>
                public IPipe Next {

                    get { 
                        if (FaceOrNot == true){
                            
                            return this.nextPipeTrue; }
                        else{
                            return this.nextPipeFalse;
                        }
                    }
                }

                    public IPipe NextFalse {
                        get { return this.nextPipeFalse; }
                    }
                    /// <summary>
                    /// Devuelve el IFilter que aplica este pipe
                    /// </summary>
                    public IFilter Filter {
                        get { return this.filtro; }
                    }
                        /// <summary>
                        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
                        /// </summary>
                        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
                    public IPicture Send (IPicture picture) {
                        
                        picture = this.filtro.Filter (picture);
                        return this.nextPipeTrue.Send (picture);
                        }
                    }
                
        }
=======
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
            get { return this.filtroBool; }
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
>>>>>>> aad7c5f5d0f8b4d38ae26de86524263a1cf268f6
