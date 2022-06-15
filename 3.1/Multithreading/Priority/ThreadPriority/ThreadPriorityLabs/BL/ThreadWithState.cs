using System;

namespace ThreadPriorityLabs.ThreadPriorityLabs.BL
{
    public class ThreadWithState
    {
        // State information used in the task.
        public string Id { get; }
        public System.Threading.ThreadPriority Priority { get; }
        public decimal NumberValue { get; private set; }

        public decimal Percentage()
        {
            return Math.Round((NumberValue / long.MaxValue) * 100, 10);
        }

        public ThreadWithState(string id, System.Threading.ThreadPriority priority)
        {
            Id = id;
            Priority = priority;
        }

        public void Process()
        {
            for (long i = 0; i <= long.MaxValue; i++)
            {
                NumberValue++;
            }
        }
    }

}