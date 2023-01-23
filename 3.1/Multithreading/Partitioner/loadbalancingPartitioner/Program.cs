using System;

namespace loadbalancingPartitioner
{
    internal static class Program
    {
        static void Main()
        {
            PartitionerLabs.ExecuteParallelFor_WithouPartitioner();
            PartitionerLabs.ExecuteParallelForEach_WithPartitioner_RangePartition();
            PartitionerLabs.ExecuteParallelForEach_WithPartitioner_ChunkPartitioning();
            Console.ReadKey();
        }
    }
}
