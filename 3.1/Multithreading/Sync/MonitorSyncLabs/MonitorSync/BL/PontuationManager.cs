using MultithreadingLabs.Synchronization.MonitorSyncLabs.BL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MultithreadingLabs.Synchronization.MonitorSyncLabs
{
    public class PontuationManager
    {
        private readonly PontuationMonitorSync _pontuationMonitorSync;
        private readonly PontuationLockSync _pontuationLockSync;
        private readonly PontuationWithoutSync _pontuationWithoutSync;

        public PontuationManager()
        {
            _pontuationMonitorSync = new PontuationMonitorSync(this);
            _pontuationLockSync = new PontuationLockSync(this);
            _pontuationWithoutSync = new PontuationWithoutSync(this);
        }

        public PontuationScore Pontuation_WithoutMonitorSync { get; } = new PontuationScore("Pontuation_WithoutMonitorSync");
        public PontuationScore Pontuation_WithMonitorSync { get; } = new PontuationScore("Pontuation_WithMonitorSync");
        public PontuationScore Pontuation_WithLockSync { get; } = new PontuationScore("Pontuation_WithLockSync");

        public PontuationMonitorSync PontuationMonitorSync
        {
            get { return _pontuationMonitorSync; }
        }

        public PontuationLockSync PontuationLockSync
        {
            get { return _pontuationLockSync; }
        }

        public PontuationWithoutSync PontuationWithoutSync
        {
            get { return _pontuationWithoutSync; }
        }
    }
}