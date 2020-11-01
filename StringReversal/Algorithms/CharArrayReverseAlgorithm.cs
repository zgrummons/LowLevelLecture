using System;
using System.Collections.Generic;
using System.Text;

namespace StringReversal.Algorithms
{
    public class CharArrayReverseAlgorithm : IAlgorithm
    {
        public string ReverseString(string input)
        {
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
