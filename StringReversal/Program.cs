using Lamar;
using Serilog;
using Serilog.Core;
using StringReversal.Algorithms;

namespace StringReversal
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
