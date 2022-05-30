using System;
using BenchmarkDotNet.Running;

namespace CollectionBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<CloneCollectionBenchmark>();
        }
    }
}
