using System;
using System.Collections.Generic;
using System.Text;

namespace MultithreadingLabs.Synchronization.MonitorSyncLabs.BL
{
    public class PontuationScore
    {
        public decimal Value { get; private set; }
        public string Description { get; }
        public long MsLastExecution { get; set; }

        public decimal Percentage => Math.Round((Value / long.MaxValue) * 100, 10);
        public long MaxValue => long.MaxValue;

        public PontuationScore(string Description)
        {
            this.Description = Description;
        }

        public void IncrementOne()
        {
            Value++;
        }
    }
}