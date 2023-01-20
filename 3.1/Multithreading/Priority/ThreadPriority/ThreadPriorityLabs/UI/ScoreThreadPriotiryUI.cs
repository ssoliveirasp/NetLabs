using System;
using System.Collections.Generic;
using System.Threading;
using ThreadPriorityLabs.ThreadPriorityLabs.BL;

namespace ThreadPriorityLabs.ThreadPriorityLabs.UI
{
    public class ScoreThreadPriotiryUI
    {
        readonly List<ThreadWithState> ts = new List<ThreadWithState>();

        public void Add(ThreadWithState t)
        {
            ts.Add(t);
        }

        public void PrintValues()
        {
            while (true)
            {
                Console.Clear();

                foreach (ThreadWithState x in ts)
                {
                    Console.WriteLine($"{x.Id} | %: {x.Percentage()} | {x.NumberValue:0000000000000} | Priority: {x.Priority}");
                }

                Thread.Sleep(600);
            }
        }
    }

}