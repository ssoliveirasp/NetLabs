using MultithreadingLabs.Synchronization.MonitorSyncLabs.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultithreadingLabs.Synchronization.MonitorSyncLabs
{

    public class MonitorThreadSync
    {

        public static void Execute()
        {
            PontuationManager score = new PontuationManager();
            GeneralScoreUI screen = new GeneralScoreUI(score);

            ThreadPool.QueueUserWorkItem(AddPontuation_WithoutSync, score);
            ThreadPool.QueueUserWorkItem(AddPontuation_WithoutSync, score);

            ThreadPool.QueueUserWorkItem(AddPontuation_WithLockSync, score);
            ThreadPool.QueueUserWorkItem(AddPontuation_WithLockSync, score);

            ThreadPool.QueueUserWorkItem(AddPontuation_WithMonitorSync, score);
            ThreadPool.QueueUserWorkItem(AddPontuation_WithMonitorSync, score);

            ThreadPool.QueueUserWorkItem(UpdateScreen, screen);
        }

        private static void AddPontuation_WithoutSync(object data)
        {
            var s = (PontuationManager)data;
            s.PontuationWithoutSync.AddPontuation_WithoutSync();
        }

        private static void AddPontuation_WithMonitorSync(object data)
        {
            var s = (PontuationManager)data;
            s.PontuationMonitorSync.AddPontuation_WithMonitorSync();
        }

        private static void AddPontuation_WithLockSync(object data)
        {
            var s = (PontuationManager)data;
            s.PontuationLockSync.AddPontuation_WithLockSync();
        }

        private static void UpdateScreen(object data)
        {
            var s = (GeneralScoreUI)data;
            s.PrintValues();
        }
    }
}