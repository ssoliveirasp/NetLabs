using BufferBlockLabs.BufferBlockLabs.Model;
using RoundRobin;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace BufferBlockLabs.BufferBlockLabs.BL
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
            Console.WriteLine($"Não existem mais mensagens a serem processadas.");
            Console.WriteLine("\n");
        }

        public void ShowSummaryInfo()
        {
            long qtdeProcessadas = default;

            foreach (KeyValuePair<int, ConsumerConnection> item in _ConsumersDictionary)
            {
                Console.WriteLine($"ConsumerId: {item.Key} Qtde Processadas: {item.Value.MessagesProcessed}");
                qtdeProcessadas = qtdeProcessadas + item.Value.MessagesProcessed;
            }

            Console.WriteLine($"Qtde Mensagens Processadas: {qtdeProcessadas.ToString()}");
        }

        private void SendMessageClient(BufferBlock<MessageQueue> messages)
        {
            _ConsumersDictionary.TryGetValue(_roundrobin.Next(), out ConsumerConnection consumer);

            messages.TryReceiveAll(out IList<MessageQueue> items);

            consumer.SendMessageClient(items);
        }

        private BufferBlock<MessageQueue> GetMessagesPerProducer()
        {
            var messages = new BufferBlock<MessageQueue>();

            //Obter items pelo prefetch
            for (long i = 0; i < _prefetchCount; i++)
            {
                _broken.Messages.TryReceive<MessageQueue>(out MessageQueue message);

                if (message != null)
                {
                    messages.Post(message);
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
