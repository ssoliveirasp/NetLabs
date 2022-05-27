using BufferBlockLabs.BufferBlockLabs.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace BufferBlockLabs.BufferBlockLabs.BL
{
    public class ConsumerConnection
    {
        private BufferBlock<MessageQueue> _bufferMessages = new BufferBlock<MessageQueue>();
        private long _messageProcessed;
        public long MessagesProcessed { get => _messageProcessed; }
        public readonly int _id;

        public ConsumerConnection(int id)
        {
            _id = id;
        }

        //Envia as Mensagens
        public void StartSendMessagesClients()
        {
            while (true)
            {
               if (_bufferMessages.Count > 0)
                {
                    _bufferMessages.TryReceiveAll(out var messages);
                }
            }
        }

        public void SendMessageClient(IEnumerable<MessageQueue> messages)
        {
            foreach (var item in messages)
            {
                _bufferMessages.Post<MessageQueue>(item);
                Interlocked.Increment(ref _messageProcessed);
            }         
        }
    }
}
