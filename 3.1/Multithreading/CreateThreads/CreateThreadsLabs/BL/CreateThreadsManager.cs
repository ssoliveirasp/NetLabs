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
    }
}
