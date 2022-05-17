using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;

namespace BenchmarkDotNetStarted
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31)] // Define .Net Version
    [MemoryDiagnoser] //Turn on MemoryDiagnoser to get the GC and allocation columns
                      // [Config(typeof(GCSettingsConfig))]  //Use our config with different GC settings see the GCSettingsConfig class below
    [RPlotExporter]
    public class TestBenchmark
    {
      //  [Params(10, 20, 30)]
      [Params(10)]
        public int Len { get; set; }

        [Benchmark]
        public void Fibonacci()
        {
            int a = 0, b = 1, c = 0;
            Console.Write("{0} {1}", a, b);

            for (int i = 2; i < Len; i++)
            {
                c = a + b;
                Console.Write(" {0}", c);
                a = b;
                b = c;
            }
        }

        [Benchmark]
        public void FibonacciRecursive()
        {
            Fibonacci_Recursive(0, 1, 1, Len);
        }

        private void Fibonacci_Recursive(int a, int b, int counter, int len)
        {
            if (counter <= len)
            {
                Console.Write("{0} ", a);
                Fibonacci_Recursive(b, a + b, counter + 1, len);
            }
        }
    }
}
