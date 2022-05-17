using System;
using System.Collections.Generic;
using System.Threading;

namespace MultithreadingLabs.Threading
{
    public class ScoreThreadPriotiryUI
    {
        List<ThreadWithState> ts = new List<ThreadWithState>();

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
                    Console.WriteLine($"{x.ID} | %: {x.Percentage()} | {x.numberValue.ToString("0000000000000")} | Priority: {x.Priority}");
                }

                Thread.Sleep(600);
            }
        }
    }

}
