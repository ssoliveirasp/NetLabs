using MultithreadingLabs.Synchronization.MonitorSyncLabs;
using System;

namespace MultithreadingLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var ret = createUI();

                switch (ret.KeyChar)
                {
                    case '1':
                        MonitorThreadSync.Execute();
                        break;
                }
            }
        }

        static ConsoleKeyInfo createUI()
        {
            Console.Clear();
            Console.WriteLine("1. Execute 'Monitor Synchronization' - Add Number");

            return Console.ReadKey();
        }
    }
}