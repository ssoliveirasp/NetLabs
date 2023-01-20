using System.Diagnostics;
using System.Threading;

namespace MultithreadingLabs.Synchronization.MonitorSyncLabs
{
    public class PontuationMonitorSync
    {
        private readonly PontuationManager _pontuationManager;
        private static readonly object _lock_WithMonitorSync = new object();

        public PontuationMonitorSync(PontuationManager pontuationManager)
        {
            _pontuationManager = pontuationManager;
        }

        public void AddPontuation_WithMonitorSync()
        {
            var s = new Stopwatch();

            for (long i = 0; i <= _pontuationManager.Pontuation_WithMonitorSync.MaxValue; i++)
            {
                Monitor.Enter(_lock_WithMonitorSync);

                s.Start();

                _pontuationManager.Pontuation_WithMonitorSync.IncrementOne();

                s.Stop();

                _pontuationManager.Pontuation_WithMonitorSync.MsLastExecution = s.ElapsedMilliseconds;

                Monitor.Exit(_lock_WithMonitorSync);
            }
        }
    }
}