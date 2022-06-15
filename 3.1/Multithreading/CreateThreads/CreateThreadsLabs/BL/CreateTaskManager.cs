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

        public CreateTaskManager CreateStart_Task_Run_ActionDelegate()
        {
            Task.Run(new Action(ProcessOperationStatic.ExecuteShortRunningOperationWithoutParameter));

            return this;
        }

        public CreateTaskManager CreateStart_Task_Run_Delegate()
        {
            Task.Run(delegate { ProcessOperationStatic.ExecuteShortRunningOperation(1000); });
            
            return this;
        }

        public CreateTaskManager CreateStart_Task_Factory_StartNew_WithParam()
        {
            Task tf = Task.Factory.StartNew(() => ProcessOperationStatic.ExecuteLongRunningOperation(5000));

            return this;
        }

        public CreateTaskManager CreateStart_NewTask_LambdaExpression()
        {
            var task = new Task(() => ProcessOperationStatic.ExecuteShortRunningOperation(1000));

            task.Start();

            return this;
        }

        public CreateTaskManager CreateStart_NewTask_ActionDelegate()
        {
            var task = new Task(new Action(ProcessOperationStatic.ExecuteShortRunningOperationWithoutParameter));

            task.Start();

            return this;
        }

        public CreateTaskManager CreateStart_NewTask_UsingDelegate()
        {
            Task task = new Task(delegate { ProcessOperationStatic.ExecuteShortRunningOperation(1000); });

            task.Start();

            return this;
        }
    }
}
