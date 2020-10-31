using System;

namespace StringReversal
{
    internal interface IBenchmarker
    {
        void Run();
        T Time<T>(Func<T> func, string name);
    }
}
