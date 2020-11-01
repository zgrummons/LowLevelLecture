using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwaitThreading
{
    class Program
    {
        static async Task Main(string[] args)
        {
            for (int i = 0; i < Process.GetCurrentProcess().Threads.Count; i++)
                if (Process.GetCurrentProcess().Threads[i].ThreadState != ThreadState.Wait)
                    Console.WriteLine($"{Process.GetCurrentProcess().Threads[i].Id}: {Process.GetCurrentProcess().Threads[i].BasePriority}");
            var delayTask = Task.Delay(TimeSpan.FromSeconds(5));
            for (int i = 0; i < Process.GetCurrentProcess().Threads.Count; i++)
                if (Process.GetCurrentProcess().Threads[i].ThreadState != ThreadState.Wait)
                    Console.WriteLine($"{Process.GetCurrentProcess().Threads[i].Id}: {Process.GetCurrentProcess().Threads[i].}");
            Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().Threads.Count);
            await delayTask;
        }
    }
}
