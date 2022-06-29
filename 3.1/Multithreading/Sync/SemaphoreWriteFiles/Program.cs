using System;
using System.Linq;
using System.Threading.Tasks;

namespace SemaphoreWriteFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task[] tasksProcess = new Task[20];

            try
            {
                foreach (var i in Enumerable.Range(1, tasksProcess.Length))
                {
                    tasksProcess[i - 1] = Task.Factory.StartNew(() => new SemaphoreWriteFile($"#{i}").WriteFile());
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
    }
}
