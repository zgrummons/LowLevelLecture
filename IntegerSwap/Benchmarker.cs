using System;
using System.Collections.Generic;
using System.Diagnostics;
using IntegerSwap.Algorithms;
using Serilog;

namespace IntegerSwap
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
            foreach (var algorithm in _algorithms)
            {
                var name = algorithm.ToString();
                var result = Time(() => algorithm.SwapIntegers(12345, 67890), name);
                _logger.Information($"Method {name} returned a result of {result.Item1}, {result.Item2}");
            }
        }

        public T Time<T>(Func<T> func, string name)
        {
            var sw = Stopwatch.StartNew();
            var result = func.Invoke();
            sw.Stop();
            _logger.Information($"Method {name} ran in {sw.Elapsed.TotalSeconds} seconds");
            return result;
        }
    }
}
