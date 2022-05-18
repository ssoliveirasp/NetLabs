using System;
using System.Threading;

namespace MultithreadingLabs.Threading
{
    public class ThreadWithState
    {
        // State information used in the task.
        public string ID { get; private set; }
        public ThreadPriority Priority { get; private set; }
        public decimal numberValue { get; private set; }

        public decimal Percentage()
        {
            return Math.Round((numberValue / long.MaxValue) * 100, 10);
        }

        public ThreadWithState(string id, ThreadPriority priority)
        {
            ID = id;
            Priority = priority;
        }

        public void Process()
        {
            for (long i = 0; i <= long.MaxValue; i++)
            {
                numberValue++;
            }
        }

        // The thread procedure performs the task, such as formatting
        // and printing a document.
        private void ThreadProc()
        {
            Console.WriteLine(numberValue);
        }
    }

}