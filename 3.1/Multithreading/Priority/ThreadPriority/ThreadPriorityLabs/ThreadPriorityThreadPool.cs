using System.Threading;
using ThreadPriorityLabs.ThreadPriorityLabs.BL;
using ThreadPriorityLabs.ThreadPriorityLabs.UI;

namespace ThreadPriorityLabs.ThreadPriorityLabs
{
    public class ThreadPriorityThreadPool
    {
        public static void Execute()
        {
            CreateThreadWithState(out ThreadWithState t1, out ThreadWithState t2, out ThreadWithState t3, out ThreadWithState t4);
            CreateThreadScore(t1, t2, t3, t4);
        }

        private static void CreateThreadWithState(out ThreadWithState t1, out ThreadWithState t2, out ThreadWithState t3, out ThreadWithState t4)
        {
            t1 = new ThreadWithState("Thread 1", ThreadPriority.Normal);
            t2 = new ThreadWithState("Thread 2", ThreadPriority.Normal);
            t3 = new ThreadWithState("Thread 3", ThreadPriority.Normal);
            t4 = new ThreadWithState("Thread 4", ThreadPriority.Normal);

            ThreadPool.QueueUserWorkItem(ProcessThreadState, t1);
            ThreadPool.QueueUserWorkItem(ProcessThreadState, t2);
            ThreadPool.QueueUserWorkItem(ProcessThreadState, t3);
            ThreadPool.QueueUserWorkItem(ProcessThreadState, t4);

            static void ProcessThreadState(object state)
            {
                var t = (ThreadWithState)state;
                t.Process();
            }
        }

        private static void CreateThreadScore(ThreadWithState t1, ThreadWithState t2, ThreadWithState t3, ThreadWithState t4)
        {
            var scoreThread = new ScoreThreadPriotiryUI();

            scoreThread.Add(t1);
            scoreThread.Add(t2);
            scoreThread.Add(t3);
            scoreThread.Add(t4);

            ThreadPool.QueueUserWorkItem(ScorePrintValues, scoreThread);

            static void ScorePrintValues(object state)
            {
                var scoreThread = (ScoreThreadPriotiryUI)state;
                scoreThread.PrintValues();
            }
        }
    }
}