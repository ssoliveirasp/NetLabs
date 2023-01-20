using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorRWFiles
{
    public class MonitorWriteFile
    {
        private readonly string ProcessName;

        public MonitorWriteFile(string processName)
        {
            ProcessName = processName;
        }
        private static object Locker { get; } = new object();

        public void WriteFile()
        {
            var range = Enumerable.Range(1, 1000);

            Console.WriteLine($"WriteFile started Process: {ProcessName} TaskId: {Task.CurrentId}");

            range.AsParallel().AsOrdered().ForAll(i =>
            {
                
                Monitor.Enter(Locker);
                try
                {
                    File.AppendAllLines($"test.txt", new[] { $" {DateTime.Now} Process: {ProcessName} Number: {i} TaskId: {Task.CurrentId}" });
                    
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine($"Task has finished with exception { ex.InnerException.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Task has finished with exception {ex.Message}");
                }

                finally
                {
                    Monitor.Exit(Locker);
                }
            });

            Console.WriteLine($"WriteFile sucess Process: {ProcessName} TaskId: {Task.CurrentId}");

        }
    }
}
