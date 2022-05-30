using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace CollectionBenchmark
{
    [MemoryDiagnoser]
    public class CloneCollectionBenchmark
    {
        private byte[] _array = null!;

        [Params(1, 10, 1_000, 10_000)]
        public int Size { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _array = Enumerable.Range(0, Size).Select(i => (byte)i).ToArray();
        }

        [Benchmark]
        public void Array_ToArray() => _array.ToArray();

        [Benchmark]
        public void Array_ToList() => _array.ToList();

        [Benchmark]
        public void Enumerable_ToArray() => AsEnumerable(_array).ToArray();

        [Benchmark]
        public void Enumerable_ToList() => AsEnumerable(_array).ToList();

        // Avoid optimizations as ToList or ToArray cannot know
        // the number of items in the collection to clone
        IEnumerable<T> AsEnumerable<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                yield return item;
        }
    }
}
