using MultithreadingLabs.Synchronization.MonitorSyncLabs.BL;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MultithreadingLabs.Threading
{
    public class MonitorWaitingUI
    {

        public static void StartMonitorWaiting(WaitingScoreModel x, double SegundosPausa)
        {
            Console.WriteLine($"Execução: {DateTime.Now.ToString("HH:mm:ss")}  Pausa (s): {SegundosPausa.ToString("00000")}");
        }

        public static void PrintValues(WaitingScoreModel x)
        {
            Console.WriteLine($"%: {x.Percentage} | Valor: {x.Value.ToString("0000000000000")} ");
        }
    }
}