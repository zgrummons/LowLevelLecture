﻿using Lamar;
using Serilog;
using SmallestInteger.Algorithms;

namespace SmallestInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.AddAllTypesOf<IAlgorithm>();
                });

                _.For<IBenchmarker>().Use<Benchmarker>().Singleton();
                _.For<ILogger>().Use(new LoggerConfiguration().WriteTo.Console().CreateLogger()).Singleton();
            });

            container.GetInstance<IBenchmarker>().Run();
        }
    }
}
