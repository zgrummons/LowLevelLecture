using System;
using System.Collections.Generic;
using System.Diagnostics;
using Serilog;
using StringReversal.Algorithms;

namespace StringReversal
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
                Time(() => algorithm.ReverseString("reverse me"), algorithm.ToString());
        }

        public T Time<T>(Func<T> func, string name)
        {
            var sw = Stopwatch.StartNew();
            var result = func.Invoke();
            sw.Stop();
            _logger.Information($"Method {name} ran in {sw.Elapsed.TotalSeconds} seconds{(result is int ? $", returning a result of {result}" : string.Empty)}.");
            return result;
        }
    }
}
