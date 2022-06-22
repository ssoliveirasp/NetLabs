using System;

namespace ParallelForEachLabs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParallelForEach.For_Threadlocalvariable();
            ParallelForEach.For_ParallelBreak();

            Console.ReadKey();
        }
    }
}
