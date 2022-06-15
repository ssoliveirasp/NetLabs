using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreateThreadsLabs.BL
{
    internal class CreateTaskManager
    {
        public CreateTaskManager CreateStart_Task_Run_WithParam()
        {
            Task t = Task.Run(() => ProcessOperationStatic.ExecuteLongRunningOperation(5000));

            return this;
        }

        public CreateTaskManager CreateStart_Task_Factory_StartNew_WithParam()
        {
            Task tf = Task.Factory.StartNew(() => ProcessOperationStatic.ExecuteLongRunningOperation(5000));

            return this;
        }

        public CreateTaskManager CreateStart_Task_LambdaExpression()
        {
            var task = new Task(() => ProcessOperationStatic.ExecuteShortRunningOperation(1000));

            task.Start();

            return this;
        }
    }
}
