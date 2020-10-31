using System;
using System.Collections.Generic;
using System.Text;

namespace StringReversal.Algorithms
{
    class StackReverseAlgorithm : IAlgorithm
    {
        public string ReverseString(string input)
        {
            var output = new char[input.Length];
            var stack = new Stack<char>(input.Length);
            foreach (var c in input)
                stack.Push(c);
            for (int i = 0; i < input.Length; i++)
                output[i] = stack.Pop();
            return new string(output);
        }
    }
}
