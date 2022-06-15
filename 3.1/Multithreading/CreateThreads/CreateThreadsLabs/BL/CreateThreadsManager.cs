using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CreateThreadsLabs.UI;

namespace CreateThreadsLabs.BL
{
    internal class CreateThreadsManager
    {
        public CreateThreadsManager CreateStart_Thread_WithThreadStart_ParameterLess()
        {
            var worker =
                new Thread(new ThreadStart(ProcessOperationStatic.ExecuteShortRunningOperationWithoutParameter));

            worker.Start();

            return this;
        }

        public CreateThreadsManager CreateStart_Thread_WithoutThreadStart_ParameterLess()
        {
            var worker = new Thread(ProcessOperationStatic.ExecuteShortRunningOperationWithoutParameter);

            worker.Start();

            return this;
        }

        public CreateThreadsManager CreateStart_Thread_ClassMethod()
        {
            var processOperation = new ProcessOperation();
            var tScoreThread3 = new Thread(processOperation.ExecuteLongRunningOperation);

            tScoreThread3.Start();
            tScoreThread3.IsBackground = true;

            return this;
        }

        public CreateThreadsManager CreateStart_Thread_ParameterizedThreadStart()
        {
            var tscoreThread4 =
                new Thread(new ParameterizedThreadStart(ProcessOperationStatic.ExecuteLongRunningOperation));

            tscoreThread4.Start(10000000);
            tscoreThread4.IsBackground = true;

            return this;
        }

        public CreateThreadsManager CreateStart_ThreadPool_QueueUserWorkItem_ParamLess()
        {
            ThreadPool.QueueUserWorkItem(ProcessOperationStatic.ExecuteShortRunningOperation);

            return this;
        }

        public CreateThreadsManager CreateStart_ThreadPool_QueueUserWorkItem_Background_True()
        {
            ThreadPool.QueueUserWorkItem((_) =>
            {
                Thread.CurrentThread.IsBackground = true;
                ProcessOperationStatic.ExecuteShortRunningOperation(1000);
                LogThreads.LogCompleted(nameof(CreateThreadsManager),
                    nameof(CreateStart_ThreadPool_QueueUserWorkItem_Background_True));
            });

            return this;
        }

        public CreateThreadsManager CreateStart_ThreadPool_QueueUserWorkItem_Background_False()
        {
            ThreadPool.QueueUserWorkItem((_) =>
            {
                Thread.CurrentThread.IsBackground = false;
                ProcessOperationStatic.ExecuteShortRunningOperation(1000);
                LogThreads.LogCompleted(nameof(CreateThreadsManager), "CreateStart_ThreadPool_QueueUserWorkItem_Background_False");
            });

            return this;
        }

        public CreateThreadsManager CreateStart_Task_Run_WithParam()
        {
            Task t = Task.Run(() => ProcessOperationStatic.ExecuteLongRunningOperation(5000));

            return this;
        }

        public CreateThreadsManager CreateStart_Task_Factory_StartNew_WithParam()
        {
            Task tf = Task.Factory.StartNew(() => ProcessOperationStatic.ExecuteLongRunningOperation(5000));

            return this;
        }
    }
}
