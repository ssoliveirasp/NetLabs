using MultithreadingLabs.Synchronization.MonitorSyncLabs;
using System;

namespace MultithreadingLabs
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
                        MonitorThreadSync.Execute();
                        break;
                }
            }
        }

        static ConsoleKeyInfo CreateUI()
        {
            Console.Clear();
            Console.WriteLine("1. Execute 'Monitor Synchronization' - Add Number");

            return Console.ReadKey();
        }
    }
}