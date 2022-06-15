using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using PubSubBlockingCollectionLabs.BlockingCollectionLabs.Model;

namespace PubSubBlockingCollectionLabs.BlockingCollectionLabs.BL
{
    public class ConsumerConnection
    {
        private readonly BlockingCollection<MessageQueue> _blockingMessage = new BlockingCollection<MessageQueue>();
        private long _messageProcessed;
        public long MessagesProcessed { get => _messageProcessed; }
        public readonly int _id;

        public ConsumerConnection(int id)
        {
            _id = id;
        }

        //Receber as Mensagens
        public void StartSendMessagesClients()
        {
            while (true)
            {
               if (_blockingMessage.Count > 0)
                {
                    foreach (var item in _blockingMessage)
                    {
                        _blockingMessage.Take();
                    }
                }
            }
        }

        public void SendMessageClient(IEnumerable<MessageQueue> messages)
        {
            foreach (var item in messages)
            {
                _blockingMessage.Add(item);
                Interlocked.Increment(ref _messageProcessed);
            }         
        }
    }
}
