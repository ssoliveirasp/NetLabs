using System;

namespace loadbalancingPartitioner
{
    internal class Program
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
