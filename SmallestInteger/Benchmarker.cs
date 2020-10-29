using System;
using System.Collections.Generic;
using System.Diagnostics;
using Serilog;
using SmallestInteger.Algorithms;

namespace SmallestInteger
{
    internal class Benchmarker : IBenchmarker
    {
        private readonly IEnumerable<IAlgorithm> _algorithms;
        private readonly ILogger _logger;

        public Benchmarker(IEnumerable<IAlgorithm> algorithms, ILogger logger)
        {
            _algorithms = algorithms;
            _logger = logger;
        }

        public void Run()
        {
            var numbers = Time(LoadIntegers, "LoadIntegers");

            foreach (var algorithm in _algorithms)
                Time(() => algorithm.FindSmallestInteger(numbers), algorithm.ToString());
        }

        public T Time<T>(Func<T> func, string name)
        {
            var sw = Stopwatch.StartNew();
            var result = func.Invoke();
            sw.Stop();
            _logger.Information($"Method {name} ran in {sw.Elapsed.TotalSeconds} seconds{(result is int ? $", returning a result of {result}" : string.Empty)}.");
            return result;
        }

        private int[] LoadIntegers()
        {
            var rng = new Random();
            var count = rng.Next(100, int.MaxValue);
            _logger.Information($"Generating {count:N0} integers");
            var numbers = new int[count];
            var percentIncrement = count / 100;

            for (var i = 0; i < count; i++)
            {
                if (i % percentIncrement == 0)
                    _logger.Information($"{i / percentIncrement}% done");
                numbers[i] = rng.Next();
            }

            _logger.Information($"\nInteger generation finished");
            return numbers;
        }
    }
}
