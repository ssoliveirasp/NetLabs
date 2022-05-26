using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using TplProducerConsumerLabs.BlockingCollectionLabs.Model;

namespace TplProducerConsumerLabs.BlockingCollectionLabs.BL
{
    public class ProducerQueue
    {
        private readonly MessageBroken _broken;
        private readonly int _maxProducers;
        private readonly int _maxMessagesPerProducer;
        private long _messagesCount;
        

        public long LimitMessages { get => (_maxMessagesPerProducer * _maxProducers); }
        public bool IsAddingCompleted { get => (_messagesCount >= LimitMessages); }
        public int MaxProducers { get => _maxProducers; }

        public ProducerQueue(MessageBroken broken,int maxProducers = 2, int maxMessagesPerProducer = 10)
        {
            _broken = broken;
            _maxProducers = maxProducers;
            _maxMessagesPerProducer = maxMessagesPerProducer;
        }

        public ProducerQueue CreateProducers()
        {
            var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
            var blockingProducers = new BlockingCollection<Task>(_maxProducers);

            while (blockingProducers.Count < _maxProducers)
            {
                Task producer = taskFactory.StartNew(() => { AddMessagesPerProducer(); });

                blockingProducers.Add(producer);
            }

            blockingProducers.CompleteAdding();

            return this;
        }

        private void AddMessagesPerProducer()
        {
            long messagesCountProducer = 0;

            while (messagesCountProducer < _maxMessagesPerProducer)
            {
                var message = new MessageQueue();

                _broken.SendMessageQueue(message);

                Interlocked.Increment(ref messagesCountProducer);
                Interlocked.Increment(ref _messagesCount);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Finalized TaskId: {Task.CurrentId.ToString()} TotalMessages: {messagesCountProducer}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public ProducerQueue WaitingProducers()
        {
            while (this.IsAddingCompleted == false) { Thread.Sleep(1000); }

            Thread.Sleep(2000);

            return this;
        }

        public ProducerQueue ShowSummaryProperties(bool showEndProcessInfo = false)
        {
            Console.ResetColor();
            Console.WriteLine($"Producers              - Count: {_maxProducers.ToString()}");
            Console.WriteLine($"Max Messages Producers - Count: {_maxMessagesPerProducer.ToString()}");

            if (showEndProcessInfo)
            {
                Console.WriteLine($"Limit Messages         - Count: {LimitMessages.ToString()}");
                Console.WriteLine($"Messages Created       - Count: {_messagesCount.ToString()}");
            }
            return this;
        }
    }
}
