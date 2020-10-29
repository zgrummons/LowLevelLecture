using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringReversal.Algorithms
{
    public class LinqReverseAlgorithm : IAlgorithm
    {
        public string ReverseString(string input)
        {
            return new string(input.Reverse().ToArray());
        }
    }
}
