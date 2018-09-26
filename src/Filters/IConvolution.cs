using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel{

    public interface IConvolution
    {

        int[,] MatrizConvolution {get;}
        int Complemento {get;}
        int Divisor {get;}
    }
}