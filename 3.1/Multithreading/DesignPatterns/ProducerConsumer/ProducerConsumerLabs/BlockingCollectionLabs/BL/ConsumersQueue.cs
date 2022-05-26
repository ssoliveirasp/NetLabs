using RoundRobin;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TplProducerConsumerLabs.BlockingCollectionLabs.Model;

namespace TplProducerConsumerLabs.BlockingCollectionLabs.BL
{
    public class ConsumersQueue
    {
        private readonly MessageBroken _broken;
        private readonly int _maxConsumers;
        private readonly int _prefetchCount;

        ConcurrentDictionary<int, ConsumerConnection> _ConsumersDictionary;
        RoundRobinList<int> _roundrobin;

        public bool CanceledOperation { get; set; } = false;

        public ConsumersQueue(MessageBroken broken, int maxConsumers, int prefetchCount)
        {
            _broken = broken;
            _maxConsumers = maxConsumers;
            _prefetchCount = prefetchCount;
            _ConsumersDictionary = new ConcurrentDictionary<int, ConsumerConnection>();
            _roundrobin = GetRoundRobinList();
        }

        public ConsumersQueue StartConsumer()
        {
            //Processo sendo executado sempre
            while (!CanceledOperation)
            {
                var messages = GetMessagesPerProducer();

                if (messages.Count > 0)
                {
                    SendMessageClient(messages);
                }
                else
                {
                    StopConsumerMessages();
                    break;
                }
            }

            return this;
        }

        private void StopConsumerMessages()
        {
            Thread.Sleep(2000);

            long qtdeProcessadas = default;

            foreach (KeyValuePair<int, ConsumerConnection> item in _ConsumersDictionary)
            {
                Console.WriteLine($"ConsumerId: {item.Key} Qtde Processadas: {item.Value.MessagesProcessed}");
                qtdeProcessadas = qtdeProcessadas + item.Value.MessagesProcessed;
            }

            Console.WriteLine($"Qtde Mensagens Processadas: {qtdeProcessadas.ToString()}");
        }

        private void SendMessageClient(BlockingCollection<MessageQueue> messages)
        {
            _ConsumersDictionary.TryGetValue(_roundrobin.Next(), out ConsumerConnection consumer);

            consumer.SendMessageClient(messages);
        }

        private BlockingCollection<MessageQueue> GetMessagesPerProducer()
        {
            var messages = new BlockingCollection<MessageQueue>();

            //Obter items pelo prefetch
            for (long i = 0; i < _prefetchCount; i++)
            {
                _broken.Messages.TryTake(out MessageQueue message);

                if (message != null)
                {
                    messages.TryAdd(message);
                }
            }

            return messages;
        }
        private RoundRobinList<int> GetRoundRobinList()
        {
            var roundList = new List<int>();

            for (int i = 1; i < _maxConsumers; i++)
            {
                roundList.Add(i);
            }

            return new RoundRobinList<int>(roundList);
        }

        public ConsumersQueue CreateConsumers()
        {
            var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);

            while (_ConsumersDictionary.Count < _maxConsumers)
            {
                var consumerID = _ConsumersDictionary.Count + 1;
                var consumerCon = new ConsumerConnection(consumerID);

                Task producer = taskFactory.StartNew(() => { consumerCon.StartSendMessagesClients(); });

                _ConsumersDictionary.TryAdd(consumerID, consumerCon);
            }

            return this;
        }
    }
}
