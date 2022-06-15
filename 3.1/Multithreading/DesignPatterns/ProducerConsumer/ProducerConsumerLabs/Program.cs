using System;
using PubSubBlockingCollectionLabs.BlockingCollectionLabs.BL;

namespace PubSubBlockingCollectionLabs
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
              .StartConsumer()
              .ShowSummaryInfo();

            Console.Read();
        }
    }
}
