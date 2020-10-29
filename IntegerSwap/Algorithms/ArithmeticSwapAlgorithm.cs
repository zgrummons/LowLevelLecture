using System;
using System.Collections.Generic;
using System.Text;

namespace IntegerSwap.Algorithms
{
    public class ArithmeticSwapAlgorithm : IAlgorithm
    {
        public (int, int) SwapIntegers(int a, int b)
        {
            a = a + b;
            b = a - b;
            a -= b;

            return (a, b);
        }
    }
}
