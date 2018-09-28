using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public class BlurConvolutionMatriz : IConvolution
    {
        public int[,] MatrizParametros {get; private set;}
        
        public int Complement {get; private set;}
        public int Divisor {get; private set;}

        public BlurConvolutionMatriz()
        {
            this.MatrizParametros = new int[3,3];
            this.Complement = 0;
            this.Divisor = 9;
            
            for (int x = 0; x < 3 ; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    MatrizParametros[x,y] = 1;
                }
            }
        }
    }
}