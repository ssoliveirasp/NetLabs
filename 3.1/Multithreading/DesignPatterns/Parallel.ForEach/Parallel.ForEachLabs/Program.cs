using System;

namespace ParallelForEachLabs
{
    internal class Program
    {
        static void Main()
        {
            ParallelForEach.For_Threadlocalvariable();
            ParallelForEach.For_ParallelBreak();

            _ = Console.Read();
        }
    }
}
