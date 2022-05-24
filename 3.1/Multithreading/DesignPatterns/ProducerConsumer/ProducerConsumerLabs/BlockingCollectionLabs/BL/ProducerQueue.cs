using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using TplProducerConsumerLabs.BlockingCollectionLabs.Model;

namespace TplProducerConsumerLabs.BlockingCollectionLabs.BL
{
    public class ProducerQueue
    {
        private const int maxProducers = 2;
        private const int maxMessages = 10;
        BlockingCollection<Task> blockingProducers;
        BlockingCollection<double> blockingMessage;
        TaskFactory taskFactory;

        public BlockingCollection<Task> Producers { get => blockingProducers; }
        public BlockingCollection<double> Messages { get => blockingMessage; }

        public ProducerQueue()
        {
            blockingProducers = new BlockingCollection<Task>(maxProducers);
            blockingMessage = new BlockingCollection<double>();
            taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
        }

        public BlockingCollection<Task> CreateProducers()
        {
            while (blockingProducers.Count < maxProducers)
            {
                Task producer = taskFactory.StartNew(() =>
                {
                    AddMessages();
                    CheckCompleteMessageAdding();
                });

                blockingProducers.Add(producer);
            }

            blockingProducers.CompleteAdding();

            return blockingProducers;
        }

        private void CheckCompleteMessageAdding()
        {
            if (blockingMessage.Count >= (maxMessages * maxProducers) && blockingMessage.IsAddingCompleted == false)
            {
                blockingMessage.CompleteAdding();
            }
        }

        private void AddMessages()
        {
            double items = 0;
            while (items < maxMessages)
            {
                double message = SendMessageQueue(this);
                blockingMessage.TryAdd(message);
                items++;
            }

            Console.WriteLine($"Finalizado TaskId: {Task.CurrentId.ToString()} TotalMessages: {blockingMessage.Count}");
        }

        public static double SendMessageQueue(ProducerQueue manager)
        {
            var message = new MessageQueue();
            Thread.Sleep(1000);
            Console.WriteLine($"Message sent Code: {message.Code.ToString()} ThreadId: {Task.CurrentId.ToString()} TotalMesages: {manager.blockingMessage.Count}");
            return message.Code;
        }
    }
}
