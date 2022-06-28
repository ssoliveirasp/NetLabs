using System.Diagnostics;

namespace MultithreadingLabs.Synchronization.MonitorSyncLabs
{
    public class PontuationWithoutSync
    {
        private PontuationManager _pontuationManager;

        public PontuationWithoutSync(PontuationManager pontuationManager)
        {
            _pontuationManager = pontuationManager;
        }

        public void AddPontuation_WithoutSync()
        {
            var s = new Stopwatch();

            for (long i = 0; i <= _pontuationManager.Pontuation_WithoutMonitorSync.MaxValue; i++)
            {
                s.Start();

                _pontuationManager.Pontuation_WithoutMonitorSync.IncrementOne();

                s.Stop();

                _pontuationManager.Pontuation_WithoutMonitorSync.MsLastExecution = s.ElapsedMilliseconds;
            }
        }
    }
}