using System;
using ThreadPriorityLabs.ThreadPriorityLabs;

namespace ThreadPriorityLabs
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
                        ThreadPriorityManualCreate.Execute();
                        MainMenuExecuted = true;
                        break;
                    case '2':
                        ThreadPriorityThreadPool.Execute();
                        MainMenuExecuted = true;
                        break;
                }

                 Console.WriteLine($"Process executed Success: {MainMenuExecuted}");
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
