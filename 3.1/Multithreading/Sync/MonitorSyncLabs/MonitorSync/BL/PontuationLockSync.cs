using System.Diagnostics;

namespace MultithreadingLabs.Synchronization.MonitorSyncLabs
{
    public class PontuationLockSync
    {
        private PontuationManager _pontuationManager;
        private static readonly object _lock_WithLockSync = new object();

        public PontuationLockSync(PontuationManager pontuationManager)
        {
            _pontuationManager = pontuationManager;
        }

        public void AddPontuation_WithLockSync()
        {
            var s = new Stopwatch();

            for (long i = 0; i <= _pontuationManager.Pontuation_WithLockSync.MaxValue; i++)
            {
                lock (_lock_WithLockSync)
                {
                    s.Start();

                    _pontuationManager.Pontuation_WithLockSync.IncrementOne();

                    s.Stop();

                    _pontuationManager.Pontuation_WithLockSync.MsLastExecution = s.ElapsedMilliseconds;
                }
            }
        }
    }
}