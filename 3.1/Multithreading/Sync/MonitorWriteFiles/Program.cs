using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MonitorRWFiles;

namespace MutexLabs
{
    internal class Program
    {
        static void Main()
        {
            Task[] tasksProcess = new Task[100000];

            try
            {
                foreach (var i in Enumerable.Range(1, tasksProcess.Length))
                {
                    tasksProcess[i - 1] = Task.Factory.StartNew(() => new MonitorWriteFile($"#{i}").WriteFile());
                }

                Task.WhenAll(tasksProcess);
            }
            catch (AggregateException ex)
            {
                foreach (Exception innerException in ex.InnerExceptions)
                {
                    Console.WriteLine(innerException.Message);
                }
            }

            Console.ReadKey();
        }

        public static void ExecuteShortRunningOperation(object id)
        {
            id ??= $"T{DateTime.Now.Second}";

            var tp1 = new MonitorWriteFile($"{id}");

            tp1.WriteFile();
        }
    }
}
