using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loadbalancingPartitioner
{
    /// <summary>
    /// https://docs.microsoft.com/pt-br/dotnet/standard/parallel-programming/custom-partitioners-for-plinq-and-tpl
    /// </summary>
    internal class PartitionerLabs
    {
        private const int NumInteractions = 100000;

        public static void ExecuteParallelFor_WithouPartitioner()
        {
            var sw = new Stopwatch();

            Console.WriteLine($"[{nameof(ExecuteParallelFor_WithouPartitioner)}] Start");

            sw.Start();

            Parallel.For(1, NumInteractions, index => { SimulateProcess(); });

            sw.Stop();

            Console.WriteLine(
                $"[{nameof(ExecuteParallelFor_WithouPartitioner)}] Tempo execução (ms): {sw.ElapsedMilliseconds} items: {NumInteractions}");
        }

        /// <summary>
        // Range partitioning
        // This type of partitioning is primarily used with collections where the length is known in advance.
        // As the name suggests, every thread gets a range of elements to process or the start and end index of a source collection.
        // This is the simplest form of partitioning and very efficient in the sense that every thread executes its range without overwriting other threads.
        // There is no synchronization overhead, though some bits of performance are lost initially while creating ranges.
        // This type of partitioning works best in scenarios where the number of elements in each range is the same so that they will take a similar length of time to finish.
        // With a different number of elements, some tasks may finish early and sit idle, whereas other tasks may have a lot of pending elements in the range to process.
        /// </summary>
        public static void ExecuteParallelForEach_WithPartitioner_RangePartition()
        {
            var source = new List<int>();
            var result = new Double[NumInteractions];
            var sw = new Stopwatch();

            Console.WriteLine($"[{nameof(ExecuteParallelForEach_WithPartitioner_RangePartition)}] Start");

            //Add Items
            source.AddRange(Enumerable.Range(1, NumInteractions));

            var elapsedMilliseconds = SimulateProcessParallel(source);

            Console.WriteLine(
                $"[{nameof(ExecuteParallelForEach_WithPartitioner_RangePartition)}] Tempo execução (ms): {elapsedMilliseconds} Items: {NumInteractions}");
        }

        /// <summary>
        /// Chunk partitioning
        /// This type of partitioning is primarily used with collections such as LinkedList, where the length isn't known in advance.
        /// Chunk partitioning provides more load balancing in case you have uneven collections. Every thread picks up a chunk of elements, processes them,
        /// and then comes back to pick up another chunk that hasn't been picked up by other threads yet.
        /// The size of the chunk depends on the partitioner's implementation and there is synchronization overhead to make sure that the chunks that are allocated to
        /// two threads don't contain duplicates.
        /// </summary>
        public static void ExecuteParallelForEach_WithPartitioner_ChunkPartitioning()
        {
            var source = new List<int>();

            //Initialize Items
            source.AddRange(Enumerable.Range(1, NumInteractions));

            for (int numCycle = 1; numCycle <= 3; numCycle++)
            {
                Console.WriteLine($"[{nameof(ExecuteParallelForEach_WithPartitioner_ChunkPartitioning)}] Start - Cycle: {numCycle}");

                //Chunck Items
                var block = source.ChuckBy(NumInteractions);
                var chunckItems = block[numCycle - 1].ToList();

                //Process
                ProcessChunk(chunckItems, numCycle);

                //Add New Items
                source.AddRange(Enumerable.Range(source.Count + 1, NumInteractions));
            }

            static void ProcessChunk(List<int> chunckItems, int numCycle)
            {
                var elapsedMilliseconds = SimulateProcessParallel(chunckItems);

                Console.WriteLine(
                    $"[{nameof(ExecuteParallelForEach_WithPartitioner_ChunkPartitioning)}] Tempo execução (ms): {elapsedMilliseconds} - Cycle: {numCycle} Items: {chunckItems.Count}");
            }
        }

        private static long SimulateProcessParallel(List<int> source)
        {
            var sw = new Stopwatch();

            sw.Start();

            Parallel.ForEach(Partitioner.Create(0, source.Count), range =>
            {
                for (var index = range.Item1; index < range.Item2; index++)
                {
                    SimulateProcess();
                }
            });

            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        private static void SimulateProcess()
        {
            Task.Delay(500);
        }
    }
}

