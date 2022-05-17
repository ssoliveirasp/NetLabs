using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkDotNetStarted
{
    /// <summary>
    /// Configuration to start the tests with different GC settings
    /// </summary>
    public class GCSettingsConfig : ManualConfig
    {
        public GCSettingsConfig()
        {
            Add(Job.Default
                //Workstation, Background
                .With(new GcMode()
                {
                    Server = false,
                    Concurrent = true
                }));
            Add(Job.Default
                //Workstation, non-concurrent
                .With(new GcMode()
                {
                    Server = false,
                    Concurrent = false
                }));
            Add(Job.Default
                //Server, Background
                .With(new GcMode()
                {
                    Server = true,
                    Concurrent = true
                }));
            Add(Job.Default
                //Server, non-concurrent
                .With(new GcMode()
                {
                    Server = true,
                    Concurrent = false
                }));
        }
    }
}
