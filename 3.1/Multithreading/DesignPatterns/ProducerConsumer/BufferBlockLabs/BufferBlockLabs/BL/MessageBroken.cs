using BufferBlockLabs.BufferBlockLabs.Model;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace BufferBlockLabs.BufferBlockLabs.BL
{
    public class MessageBroken
    {
        readonly BufferBlock<MessageQueue> _blockingMessage;

        public BufferBlock<MessageQueue> Messages { get => _blockingMessage; }

        public MessageBroken()
        {
            _blockingMessage = new BufferBlock<MessageQueue>();
        }

        public double SendMessageQueue(MessageQueue message)
        {
            return SendMessageQueue(_blockingMessage, message);
        }

        private double SendMessageQueue(ITargetBlock<MessageQueue> buffer, MessageQueue message)
        {
            buffer.Post<MessageQueue>(message);

            Console.ResetColor();
            Console.WriteLine($"Message sent Code: {message.Code} TaskId: {Task.CurrentId} CurrentTotalMessages: {_blockingMessage.Count}");
            Thread.Sleep(1000);

            return message.Code;

        }
    }
}
