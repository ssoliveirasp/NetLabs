using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CreateThreadsLabs.UI;

namespace CreateThreadsLabs.BL
{
    internal class CreateThreadsPoolManager
    {
        public CreateThreadsPoolManager CreateStart_ThreadPool_QueueUserWorkItem_ParamLess()
        {
            ThreadPool.QueueUserWorkItem(ProcessOperationStatic.ExecuteShortRunningOperation);

            return this;
        }

        public CreateThreadsPoolManager CreateStart_ThreadPool_QueueUserWorkItem_Background_True()
        {
            ThreadPool.QueueUserWorkItem((_) =>
            {
                Thread.CurrentThread.IsBackground = true;
                ProcessOperationStatic.ExecuteShortRunningOperation(1000);
                LogThreads.LogCompleted(nameof(CreateThreadsPoolManager), "");
            });

            return this;
        }

        public CreateThreadsPoolManager CreateStart_ThreadPool_QueueUserWorkItem_Background_False()
        {
            ThreadPool.QueueUserWorkItem((_) =>
            {
                Thread.CurrentThread.IsBackground = false;
                ProcessOperationStatic.ExecuteShortRunningOperation(1000);
                LogThreads.LogCompleted(nameof(CreateThreadsPoolManager), "");
            });

            return this;
        }
    }
}
