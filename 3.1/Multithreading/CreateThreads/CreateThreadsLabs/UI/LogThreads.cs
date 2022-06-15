using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CreateThreadsLabs.UI
{
    internal static class LogThreads
    {
        public static void LogCompleted(string metodo, string Identificador = "")
        {
            Console.WriteLine($"[Completed] [{metodo}] {Identificador} Id: {Thread.CurrentThread.ManagedThreadId} IsBackground: {Thread.CurrentThread.IsBackground}");
        }
    }
}
