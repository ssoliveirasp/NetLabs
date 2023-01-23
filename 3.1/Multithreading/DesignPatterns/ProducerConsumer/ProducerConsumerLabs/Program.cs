﻿using System;
using PubSubBlockingCollectionLabs.BlockingCollectionLabs.BL;

namespace PubSubBlockingCollectionLabs
{
    static class Program
    {
        static void Main()
        {
            var mbroken = new MessageBroken();

            var producer = new ProducerQueue(broken: mbroken,
                                             maxProducers: 5,
                                             maxMessagesPerProducer: 5);

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
