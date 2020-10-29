using System;
using System.Collections.Generic;
using System.Text;

namespace IntegerSwap.Algorithms
{
    public class TempVariableSwapAlgorithm : IAlgorithm
    {
        public (int, int) SwapIntegers(int a, int b)
        {
            var c = a;
            a = b;
            b = c;

            return (a, b);
        }
    }
}
