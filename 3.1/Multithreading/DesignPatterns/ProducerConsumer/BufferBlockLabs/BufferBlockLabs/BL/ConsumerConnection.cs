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
        private readonly BufferBlock<MessageQueue> _bufferMessages;
        private long _messageProcessed;
        public long MessagesProcessed { get => _messageProcessed; }
        public readonly int Id;

        public ConsumerConnection(int id)
        {
            Id = id;
            _bufferMessages = new BufferBlock<MessageQueue>();
        }

        //Envia as Mensagens
        public void StartSendMessagesClients()
        {
            while (true)
            {
                if (_bufferMessages.Count > 0)
                {
                    _ = _bufferMessages.TryReceiveAll(out var messages);

                    Console.WriteLine($"Messages: {messages.Count}");
                }

                Thread.Sleep(3000);
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
