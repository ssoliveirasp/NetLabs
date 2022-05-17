using MultithreadingLabs.Synchronization.MonitorSyncLabs.BL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MultithreadingLabs.Synchronization.MonitorSyncLabs
{
    public class GeneralScoreSync
    {
        private static object _lock_WithMonitorSync = new object();
        private static object _lock_WithLockSync = new object();

        public PontuationScore Pontuation_WithoutMonitorSync { get; private set; } = new PontuationScore("Pontuation_WithoutMonitorSync");
        public PontuationScore Pontuation_WithMonitorSync { get; private set; } = new PontuationScore("Pontuation_WithMonitorSync");
        public PontuationScore Pontuation_WithLockSync { get; private set; } = new PontuationScore("Pontuation_WithLockSync");

        public void AddPontuation_WithoutSync()
        {
            var s = new Stopwatch();

            for (long i = 0; i <= Pontuation_WithoutMonitorSync.MaxValue; i++)
            {
                s.Start();

                Pontuation_WithoutMonitorSync.IncrementOne();

                s.Stop();

                Pontuation_WithoutMonitorSync.MsLastExecution = s.ElapsedMilliseconds;
            }
        }

        public void AddPontuation_WithMonitorSync()
        {
            var s = new Stopwatch();

            for (long i = 0; i <= Pontuation_WithMonitorSync.MaxValue; i++)
            {
                Monitor.Enter(_lock_WithMonitorSync);

                s.Start();

                Pontuation_WithMonitorSync.IncrementOne();

                s.Stop();

                Pontuation_WithMonitorSync.MsLastExecution = s.ElapsedMilliseconds;

                Monitor.Exit(_lock_WithMonitorSync);
            }
        }

        public void AddPontuation_WithLockSync()
        {
            var s = new Stopwatch();

            for (long i = 0; i <= Pontuation_WithLockSync.MaxValue; i++)
            {
                lock (_lock_WithLockSync)
                {
                    s.Start();

                    Pontuation_WithLockSync.IncrementOne();

                    s.Stop();

                    Pontuation_WithLockSync.MsLastExecution = s.ElapsedMilliseconds;
                }
            }
        }
    }
}
