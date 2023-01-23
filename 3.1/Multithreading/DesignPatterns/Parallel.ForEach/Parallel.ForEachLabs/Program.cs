using System;

namespace ParallelForEachLabs
{
    internal static class Program
    {
        static void Main()
        {
            ParallelForEach.For_Threadlocalvariable();
            ParallelForEach.For_ParallelBreak();

            _ = Console.Read();
        }
    }
}
