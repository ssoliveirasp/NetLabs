using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MultithreadingLabs.Synchronization.MonitorSyncLabs.BL
{
    public class WaitingScoreModel
    {
        public decimal Value { get; private set; }
        public double MsLastExecution { get; set; }
        public decimal Percentage => Math.Round((Value / long.MaxValue) * 100, 10);
        public long MaxValue => long.MaxValue;

        public double IncrementOne()
        {
            var s = new Stopwatch();

            s.Start();
            Value++;
            s.Stop();

            return s.Elapsed.TotalMilliseconds;
        }
    }
}
