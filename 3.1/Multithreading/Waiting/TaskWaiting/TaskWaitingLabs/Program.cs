using System;
using System.Threading.Tasks;

namespace TaskWaitingLabs
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("What is the output of 20/2. We will show result in 2 seconds.");
            Task.Delay(2000);
            Console.WriteLine("After 2 seconds delay");
            Console.WriteLine("The output is 10");
            
            TaskYield();

            Console.ReadKey();
        }

        private async static void TaskYield()
        {
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(i);
                if (i % 1000 == 0)
                    await Task.Yield();
            }
        }
    }
}
