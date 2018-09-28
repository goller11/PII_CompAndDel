using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public interface IConvolution
    {
        int[,] MatrizParametros {get;}
        int Complement {get;}
        int Divisor {get;}
    }
}