using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManualResetEventLabs
{
    internal class ManualResetLabs
    {
        ManualResetEvent manualResetEvent = new ManualResetEvent(false);

        public void Execute() 
        {
            Task signallingTask = Task.Factory.StartNew(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    Thread.Sleep(1000);

                    if (i != 2)
                    {
                        Console.WriteLine(
                            $"[BeforeSignal.{i}]   Task with CurrentId {Task.CurrentId} LoopId: {i} will give signal to enter");
                        manualResetEvent.Set();
                    }
                    else
                    {
                        Console.WriteLine($"[WithoutSignal.{i}]  Task with id {Task.CurrentId} id: {i} without signal to enter");
                    }
                }
            });

            int sum = 0;

            Parallel.For(1, 5, (i) =>
            {
                Console.WriteLine($"[WaitSignal.{i}]     Task with CurrentId {Task.CurrentId} LoopId: {i} waiting for signal to enter");

                manualResetEvent.WaitOne();
                Console.WriteLine($"[ReceivedSignal.{i}] Task with CurrentId {Task.CurrentId} LoopId: {i} received signal to enter");

                sum += i;
            });
        }
    }
}
