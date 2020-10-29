using SmallestInteger.Algorithms;
using System.Linq;

namespace TestBench.Algorithms
{
    public class LinqAlgorithm : IAlgorithm
    {
        public int FindSmallestInteger(int[] inputs) => inputs.Min();
    }
}
