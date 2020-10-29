using SmallestInteger.Algorithms;

namespace TestBench.Algorithms
{
    public class SimpleAlgorithm : IAlgorithm
    {
        public int FindSmallestInteger(int[] inputs)
        {
            var result = int.MaxValue;
            foreach (var input in inputs)
                if (input < result)
                    result = input;

            return result;
        }
    }
}
