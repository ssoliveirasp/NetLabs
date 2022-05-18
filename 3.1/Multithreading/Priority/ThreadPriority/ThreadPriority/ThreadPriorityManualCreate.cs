using System;
using System.Text;
using System.Threading;

namespace MultithreadingLabs.Threading
{
    public class ThreadPriorityManualCreate
    {
        public static void Execute()
        {

            var tStateLowest1 = new ThreadWithState("Thread 1", ThreadPriority.Lowest);
            var tStateBelowNormal2 = new ThreadWithState("Thread 2", ThreadPriority.BelowNormal);
            var tStateNormal3 = new ThreadWithState("Thread 3", ThreadPriority.Normal);
            var tStateHighest4 = new ThreadWithState("Thread 4", ThreadPriority.Highest);

            var scoreThread = new ScoreThreadPriotiryUI();

            scoreThread.Add(tStateLowest1);
            scoreThread.Add(tStateBelowNormal2);
            scoreThread.Add(tStateNormal3);
            scoreThread.Add(tStateHighest4);

            Thread tScoreThread = new Thread(new ThreadStart(scoreThread.PrintValues));

            // we create 4 threads, we transfer as parameter the name of the function executed by the thread
            Thread t1Lowest = new Thread(new ThreadStart(tStateLowest1.Process));
            Thread t2BelowNormal = new Thread(new ThreadStart(tStateBelowNormal2.Process));
            Thread T3Normal = new Thread(new ThreadStart(tStateNormal3.Process));
            Thread t4Highest = new Thread(new ThreadStart(tStateHighest4.Process));

            // we assign priorities to threads
            t1Lowest.Priority = tStateLowest1.Priority;  // lowest
            t2BelowNormal.Priority = tStateBelowNormal2.Priority;  // below normal
            T3Normal.Priority = tStateNormal3.Priority;  // normal
            t4Highest.Priority = tStateHighest4.Priority;  // highest

            // we run each thread and pass the thread number as a parameter
            t1Lowest.Start();
            t2BelowNormal.Start();
            T3Normal.Start();
            t4Highest.Start();

            tScoreThread.Start();
            tScoreThread.Join();


        }
    }

}