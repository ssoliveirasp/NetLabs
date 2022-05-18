using MultithreadingLabs.Threading;
using System;

namespace ThreadPriorityLabs
{
    class Program
    {
        static bool MainMenuExecuted = false;

        static void Main(string[] args)
        {

            while (true)
            {
                var ret = createUI();

                switch (ret.KeyChar)
                {
                    case '1':
                        ThreadPriorityManualCreate.Execute();
                        MainMenuExecuted = true;
                        break;
                    case '2':
                        ThreadPriorityThreadPool.Execute();
                        MainMenuExecuted = true;
                        break;
                }
            }
        }

        static ConsoleKeyInfo createUI()
        {
            Console.Clear();
            Console.WriteLine("Selecione uma das opções:");
            Console.WriteLine("1. Execute 'Thread Priority Manual Create' - Add number");
            Console.WriteLine("2. Execute 'Thread Priority ThreadPool Create' - Add Number");

            return Console.ReadKey();
        }
    }
}
