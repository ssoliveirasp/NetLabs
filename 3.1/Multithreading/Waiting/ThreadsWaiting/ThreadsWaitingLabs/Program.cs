using MultithreadingLabs.Waiting;
using System;

namespace ThreadsWaitingLabs
{
    class Program
    {
       
        static void Main()
        {
            while (true)
            {
                var ret = CreateUI();

                switch (ret.KeyChar)
                {
                    case '1':
                        ThreadWaiting.Execute();
                        break;
                }
            }
        }

        static ConsoleKeyInfo CreateUI()
        {
            Console.Clear();
            Console.WriteLine("Selecione uma das opções:");
            Console.WriteLine("1. Execute 'Thread Waiting' - Add Number");

            return Console.ReadKey();
        }
    }
}