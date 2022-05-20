using MultithreadingLabs.Synchronization.MonitorSyncLabs.BL;
using MultithreadingLabs.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingLabs.Waiting
{
    public class MonitorWaitingSync
    {
        static WaitingScoreModel model = new WaitingScoreModel();
        private static object _lock_WithMonitorSync = new object();
        private static object _lock_MonitorWaiting = new object();
        public bool EmPausa { get; set; }

        public void ExecutePontuation()
        {
            for (long i = 0; i <= model.MaxValue; i++)
            {
                Monitor.Enter(_lock_WithMonitorSync);

                Stopwatch sw = MonitorSyncWaiting();

                MonitorWaitingUI.StartMonitorWaiting(model, sw.Elapsed.TotalSeconds);

                model.MsLastExecution = model.IncrementOne();

                MonitorWaitingUI.PrintValues(model);

                Monitor.Exit(_lock_WithMonitorSync);
            }

            static Stopwatch MonitorSyncWaiting()
            {
                var sw = new Stopwatch();
                sw.Start();
                Monitor.Wait(_lock_WithMonitorSync);
                sw.Stop();
                return sw;
            }
        }



        public void ExecuteTimeWaiting()
        {
            var dtExecucao = DateTime.MinValue;

            while (true)
            {
                var proximaExecucao = dtExecucao.AddSeconds(5);

                if (dtExecucao == DateTime.MinValue || DateTime.Now >= proximaExecucao)
                {
                    this.EmPausa = !this.EmPausa;

                    if (this.EmPausa != false)
                    {
                        Monitor.Enter(_lock_WithMonitorSync);
                        Monitor.PulseAll(_lock_WithMonitorSync);
                        Monitor.Exit(_lock_WithMonitorSync);
                    }

                    dtExecucao = DateTime.Now;
                }
            }

        }
    }
}