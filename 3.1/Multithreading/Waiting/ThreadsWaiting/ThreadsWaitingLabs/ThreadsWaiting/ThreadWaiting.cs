using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultithreadingLabs.Waiting
{
    public class ThreadWaiting
    {
        public static void Execute()
        {
            MonitorWaitingSync waiting = new MonitorWaitingSync();

            ThreadPool.QueueUserWorkItem(ExecutePontuation, waiting);
            ThreadPool.QueueUserWorkItem(ExecuteTimeWaiting, waiting);
        }

        private static void ExecutePontuation(object data)
        {
            var s = (MonitorWaitingSync)data;
            s.ExecutePontuation();
        }

        private static void ExecuteTimeWaiting(object data)
        {
            var s = (MonitorWaitingSync)data;
            s.ExecuteTimeWaiting();
        }
    }
}