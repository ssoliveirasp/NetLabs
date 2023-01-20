using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BarrierLabs
{
    public class BarrierTeaMaker
    {
        // Demonstrates:
        //      Barrier constructor with post-phase action
        //      Barrier.AddParticipants()
        //      Barrier.RemoveParticipant()
        //      Barrier.SignalAndWait(), incl. a BarrierPostPhaseException being thrown

        public static void MakeTea()
        {
            Console.WriteLine("\n With Barrier \n");
            MakeTeaSync(true);

            Console.WriteLine("\n Without Barrier \n");
            MakeTeaSync(false);

            Console.ReadKey();
        }

        private static void MakeTeaSync(bool useBarrier)
        {
            ConfigureParticipants();

            var water = Task.Factory.StartNew(() => Water(useBarrier));
            var cup = Task.Factory.StartNew(() => Cup(useBarrier));

            var tea = Task.Factory.ContinueWhenAll(new[] { water, cup }, taks =>
            {
                Console.WriteLine("\n ** Enjoy you cup of tea**");
            });

            tea.Wait();
        }

        private static readonly Barrier barrier = new Barrier(1, b =>
        {
            Console.WriteLine($"Phase {b.CurrentPhaseNumber} is finished");
        });

        static void ConfigureParticipants()
        {
            barrier.RemoveParticipants(1);
            barrier.AddParticipants(2);
        }

        private static void Water(bool useBarrier)
        {
            Console.WriteLine("1.1 Putting the kettle on (take a bit longer).");
            Thread.Sleep(2000);
            if (useBarrier)
                barrier.SignalAndWait();

            Console.WriteLine("1.2 Putting water into the cup");
            Thread.Sleep(3000);
            if (useBarrier)
                barrier.SignalAndWait();

            Thread.Sleep(2000);
            Console.WriteLine("1.3 Putting the kettle away.");
            if (useBarrier)
                barrier.SignalAndWait();
        }

        private static void Cup(bool useBarrier)
        {
            Console.WriteLine("2.1 Findins the nicest tea cup (only takes a second).");
            if (useBarrier)
                barrier.SignalAndWait();

            Console.WriteLine("2.2 Adding tea");
            if (useBarrier)
                barrier.SignalAndWait();

            Console.WriteLine("2.3 Adding sugar");
            if (useBarrier)
                barrier.SignalAndWait();
        }
    }
}
