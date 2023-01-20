using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PubSubBlockingCollectionLabs.BlockingCollectionLabs.Model;
using RoundRobin;

namespace PubSubBlockingCollectionLabs.BlockingCollectionLabs.BL
{
    public class ConsumersQueue
    {
        private readonly MessageBroken _broken;
        private readonly int _maxConsumers;
        private readonly int _prefetchCount;

        readonly ConcurrentDictionary<int, ConsumerConnection> _ConsumersDictionary;
        readonly RoundRobinList<int> _roundrobin;

        public bool CanceledOperation { get; set; } = false;

        public ConsumersQueue(MessageBroken broken, int maxConsumers, int prefetchCount)
        {
            _broken = broken;
            _maxConsumers = maxConsumers;
            _prefetchCount = prefetchCount;
            _ConsumersDictionary = new ConcurrentDictionary<int, ConsumerConnection>();
            _roundrobin = GetRoundRobinList(maxConsumers);
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

            Console.WriteLine("\n");
            Console.WriteLine($"[{nameof(ConsumersQueue)}] Não existem mais mensagens a serem processadas.");
            Console.WriteLine("\n");
        }

        public void ShowSummaryInfo()
        {
            long qtdeProcessadas = default;

            foreach (KeyValuePair<int, ConsumerConnection> item in _ConsumersDictionary)
            {
                Console.WriteLine($"ConsumerId: {item.Key} Qtde Processadas: {item.Value.MessagesProcessed}");
                qtdeProcessadas += item.Value.MessagesProcessed;
            }

            Console.WriteLine($"Qtde Mensagens Processadas: {qtdeProcessadas}");
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
        private RoundRobinList<int> GetRoundRobinList(int maxConsumers)
        {
            var roundList = new List<int>();

            for (int i = 1; i <= maxConsumers; i++)
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
                var consumerConn = new ConsumerConnection(consumerID);

                Task producer = taskFactory.StartNew(() => { consumerConn.StartSendMessagesClients(); });

                _ConsumersDictionary.TryAdd(consumerID, consumerConn);
            }

            return this;
        }
    }
}
