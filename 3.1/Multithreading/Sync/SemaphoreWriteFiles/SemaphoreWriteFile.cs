using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreWriteFiles
{
    internal class SemaphoreWriteFile
    {
        private readonly string ProcessName;
        private readonly Semaphore SemaphoreFile;

        public SemaphoreWriteFile(string processName)
        {
            var SemaphoreName = new DirectoryInfo(Directory.GetCurrentDirectory()).Name;

            ProcessName = processName;
            SemaphoreFile = new Semaphore(initialCount: 1, maximumCount: 5, name: SemaphoreName);
        }
        private static object Locker { get; } = new object();

        public void WriteFile()
        {
            var range = Enumerable.Range(1, 10);

            Console.WriteLine($"WriteFile started Process: {ProcessName} TaskId: {Task.CurrentId}");

            range.AsParallel().AsOrdered().ForAll(i =>
            {
                Thread.Sleep(10);

                SemaphoreFile.WaitOne();

                try
                {
                    File.AppendAllLines("testMutex.txt", new[] { $" {DateTime.Now} Process: {ProcessName} Number: {i.ToString()} TaskId: {Task.CurrentId}" });
                }
                catch (AggregateException ae)
                {
                    ae.Handle(ex =>
                    {
                        Console.WriteLine($"Task has finished with exception {ex.Message}");
                        return true;
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Task has finished with exception {ex.Message}");
                }

                finally
                {
                    SemaphoreFile.Release();
                }
            });

            Console.WriteLine($"WriteFile finished process: {ProcessName} TaskId: {Task.CurrentId}");

        }
    }
}
