using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LazyInitializationLabs.BL
{
    internal class LazyThreadSafe
    {
        public static void Execute()
        {
            // Initialize the integer to the managed thread id of the
            // first thread that accesses the Value property.
            Console.WriteLine("\n LazyThreadSafe Test");

            Lazy<int> number = new Lazy<int>(() => Thread.CurrentThread.ManagedThreadId);

            Thread t1 = new Thread(() => Console.WriteLine("number on t1 = {0} ThreadID = {1}",
                number.Value, Thread.CurrentThread.ManagedThreadId));
            t1.Start();

            Thread t2 = new Thread(() => Console.WriteLine("number on t2 = {0} ThreadID = {1}",
                number.Value, Thread.CurrentThread.ManagedThreadId));
            t2.Start();

            Thread t3 = new Thread(() => Console.WriteLine("number on t3 = {0} ThreadID = {1}", number.Value,
                Thread.CurrentThread.ManagedThreadId));
            t3.Start();

            // Ensure that thread IDs are not recycled if the
            // first thread completes before the last one starts.
            t1.Join();
            t2.Join();
            t3.Join();

            /* Sample Output:
                number on t1 = 11 ThreadID = 11
                number on t3 = 11 ThreadID = 13
                number on t2 = 11 ThreadID = 12
                Press any key to exit.
            */
        }
    }
}
