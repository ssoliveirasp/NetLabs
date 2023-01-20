using MultithreadingLabs.Synchronization.MonitorSyncLabs.BL;
using System;
using System.Globalization;
using System.Threading;

namespace MultithreadingLabs.Synchronization.MonitorSyncLabs.UI
{
    public class GeneralScoreUI
    {
        readonly PontuationManager _score = new PontuationManager();

        public GeneralScoreUI(PontuationManager score)
        {
            _score = score;
        }

        public void PrintValues()
        {
            while (true)
            {
                Console.Clear();

                PrintPontuation(_score.Pontuation_WithoutMonitorSync);
                PrintPontuation(_score.Pontuation_WithMonitorSync);
                PrintPontuation(_score.Pontuation_WithLockSync);
                PrintThreadPool();

                Thread.Sleep(600);
            }
        }

        private void PrintPontuation(PontuationScore p)
        {
            Console.WriteLine($"{p.Description} | %: {p.Percentage.ToString(CultureInfo.CurrentCulture)} | {p.Value:0000000000000} | Last Time(ms): {p.MsLastExecution}");
        }

        private void PrintThreadPool()
        {
            Console.WriteLine($"ThreadPool | Count: {ThreadPool.ThreadCount} | Completed: {ThreadPool.CompletedWorkItemCount}");
        }
    }

}