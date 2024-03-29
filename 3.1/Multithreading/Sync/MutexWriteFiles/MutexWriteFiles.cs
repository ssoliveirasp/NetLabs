﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexWriteFiles
{
    public class MutexWriteFiles
    {
        private readonly string ProcessName;
        private readonly Mutex Mutex;

        public MutexWriteFiles(string processName)
        {
            var MutexName = new DirectoryInfo(Directory.GetCurrentDirectory()).Name;

            ProcessName = processName;
            Mutex = new Mutex(initiallyOwned: false, name: MutexName);
        }

        public void WriteFile()
        {
            var range = Enumerable.Range(1, 1000);

            Console.WriteLine($"WriteFile started Process: {ProcessName} TaskId: {Task.CurrentId}");

            range.AsParallel().AsOrdered().ForAll(i =>
            {
                Thread.Sleep(10);

                Mutex.WaitOne();

                try
                {
                    File.AppendAllLines("testMutex.txt", new[] { $" {DateTime.Now} Process: {ProcessName} Number: {i} TaskId: {Task.CurrentId}" });
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine($"Task has finished with exception {ex.InnerException.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Task has finished with exception {ex.Message}");
                }

                finally
                {
                    Mutex.ReleaseMutex();
                }
            });

            Console.WriteLine($"WriteFile sucess Process: {ProcessName} TaskId: {Task.CurrentId}");

        }
    }
}