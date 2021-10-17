using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

namespace ClosureAllocation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkClass>();
            Console.ReadLine();
        }
    }

    [MemoryDiagnoser]
    public class BenchmarkClass
    {
        [Benchmark]
        public int WithClosure()
        {
            var sampleInt1 = 1;
            var sampleInt2 = 2;
            return new Func<int>(() => { return sampleInt1 + sampleInt2; })();
        }
        [Benchmark]
        public int WithoutClosure()
        {
            return new Func<int>(() =>
            {
                var sampleInt1 = 1;
                var sampleInt2 = 2;
                return sampleInt1 + sampleInt2;
            })();
        }
    }
}