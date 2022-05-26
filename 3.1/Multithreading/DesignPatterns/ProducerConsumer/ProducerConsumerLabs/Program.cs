using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using TplProducerConsumerLabs.BlockingCollectionLabs.BL;

namespace ProducerConsumerLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            var mbroken = new MessageBroken();

            var producer = new ProducerQueue(maxProducers: 5,
                                             maxMessagesPerProducer: 5,
                                             broken: mbroken);

            var consumers = new ConsumersQueue(broken: mbroken,
                                               maxConsumers: 5,
                                               prefetchCount: 2);

            producer
              .ShowSummaryProperties()
              .CreateProducers()
              .WaitingProducers()
              .ShowSummaryProperties(showEndProcessInfo: true);

            consumers
              .CreateConsumers()
              .StartConsumer();

            Console.Read();
        }
    }
}
