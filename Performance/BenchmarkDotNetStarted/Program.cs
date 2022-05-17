using BenchmarkDotNet.Running;
using System;

namespace BenchmarkDotNetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<TestBenchmark>();
            Console.Read();
        }
    }
}
