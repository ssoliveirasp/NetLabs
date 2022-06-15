using CreateThreadsLabs.BL;
using CreateThreadsLabs.UI;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CreateThreadsLabs
{
    public class Program
    {
        static void Main(string[] args)
        {
            var manager = new CreateThreadsManager();

            var processOperation = new ProcessOperation();

            var tScoreThread2 = new Thread(ProcessOperationStatic.ExecuteShortRunningOperationWithoutParameter);
            var tScoreThread3 = new Thread(processOperation.ExecuteLongRunningOperation);
            var tscoreThread4 = new Thread(new ParameterizedThreadStart(ProcessOperationStatic.ExecuteLongRunningOperation));

            manager
             .CreateStart_ThreadWithThreadStart();
            
            tScoreThread2.Start();

            tScoreThread3.Start();
            tScoreThread3.IsBackground = true;

            tscoreThread4.Start(10000000);
            tscoreThread4.IsBackground = true;

            ThreadPool.QueueUserWorkItem(ProcessOperationStatic.ExecuteShortRunningOperation);

            ThreadPool.QueueUserWorkItem((_) =>
            {
                Thread.CurrentThread.IsBackground = true;
                ProcessOperationStatic.ExecuteShortRunningOperation(1000);
                LogThreads.LogCompleted(nameof(Main), "QueueUserWorkItem_Local");
            });

            ThreadPool.QueueUserWorkItem((_) =>
            {
                Thread.CurrentThread.IsBackground = false;
                ProcessOperationStatic.ExecuteShortRunningOperation(1000);
                LogThreads.LogCompleted(nameof(Main), "QueueUserWorkItem_Local");
            });

            Task t = Task.Run(() => ProcessOperationStatic.ExecuteLongRunningOperation(5000));

            Task tf = Task.Factory.StartNew(() => ProcessOperationStatic.ExecuteLongRunningOperation(5000));

            Console.WriteLine($"Pressione uma tecla. Para finalizar.");
            Console.ReadKey();
            Console.WriteLine($"finalizando processo.");
        }

        private static void ExecuteWithoutParamStatic()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"{nameof(ExecuteWithoutParamStatic)} Id: {Thread.CurrentThread.ManagedThreadId} IsBackground: {Thread.CurrentThread.IsBackground}");
        }

       
    }
}
