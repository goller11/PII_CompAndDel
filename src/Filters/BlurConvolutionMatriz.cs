using System;
using System.Drawing;
using CompAndDel.Filters.Pipes;

namespace CompAndDel {
    public class BlurConvolutionMatriz : IConvolution

    {
        public int[,] MatrizConvolution { get; set; }

        public int Complemento { get; set; }

        public int Divisor { get; set; }

        public BlurConvolutionMatriz () 
        {  
            this.MatrizConvolution = new int[3, 3];
            this.Complemento = 0;
            this.Divisor = 9;
            for (int x = 0; x < 3; x++) 
            {
                    for (int y = 0; y < 3; y++) 
                    {
                        MatrizConvolution[x, y] = 1;
                    }
            }
        }

    }
}