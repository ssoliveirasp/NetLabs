using MultithreadingLabs.Waiting;
using System;

namespace ThreadsWaitingLabs
{
    class Program
    {
       
        static void Main(string[] args)
        {
            bool MainMenuExecuted = false;


            while (true)
            {
                var ret = createUI();

                switch (ret.KeyChar)
                {
                    case '1':
                        ThreadWaiting.Execute();
                        MainMenuExecuted = true;
                        break;
                }
            }
        }

        static ConsoleKeyInfo createUI()
        {
            Console.Clear();
            Console.WriteLine("Selecione uma das opções:");
            Console.WriteLine("1. Execute 'Thread Waiting' - Add Number");

            return Console.ReadKey();
        }
    }
}