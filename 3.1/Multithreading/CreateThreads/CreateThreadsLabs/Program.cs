using CreateThreadsLabs.BL;
using System;
using System.Threading;

namespace CreateThreadsLabs
{
    public class Program
    {
        static void Main()
        {
            var threadManager = new CreateThreadsManager();
            var poolManager = new CreateThreadsPoolManager();
            var taskManager = new CreateTaskManager();

            threadManager
                .CreateStart_Thread_WithThreadStart_ParameterLess()
                .CreateStart_Thread_WithoutThreadStart_ParameterLess()
                .CreateStart_Thread_ClassMethod()
                .CreateStart_Thread_ParameterizedThreadStart();

            poolManager
                .CreateStart_ThreadPool_QueueUserWorkItem_ParamLess()
                .CreateStart_ThreadPool_QueueUserWorkItem_Background_True()
                .CreateStart_ThreadPool_QueueUserWorkItem_Background_False();

            taskManager
                .CreateStart_Task_Run_WithParam()
                .CreateStart_Task_Run_ActionDelegate()
                .CreateStart_Task_Run_Delegate();

            taskManager
                .CreateStart_Task_Factory_StartNew_WithParam();

            taskManager
                .CreateStart_NewTask_LambdaExpression()
                .CreateStart_NewTask_ActionDelegate()
                .CreateStart_NewTask_UsingDelegate();

            Console.WriteLine($"Pressione uma tecla. Para finalizar.");
            Console.Read();
            Console.WriteLine($"finalizando processo.");
        }

        private static void ExecuteWithoutParamStatic()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"{nameof(ExecuteWithoutParamStatic)} Id: {Thread.CurrentThread.ManagedThreadId} IsBackground: {Thread.CurrentThread.IsBackground}");
        }

       
    }
}
