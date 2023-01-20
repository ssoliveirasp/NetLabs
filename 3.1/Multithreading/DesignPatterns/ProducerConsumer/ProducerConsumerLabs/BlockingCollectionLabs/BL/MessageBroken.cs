using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using PubSubBlockingCollectionLabs.BlockingCollectionLabs.Model;

namespace PubSubBlockingCollectionLabs.BlockingCollectionLabs.BL
{
    public class MessageBroken
    {
        readonly BlockingCollection<MessageQueue> _blockingMessage;

        public BlockingCollection<MessageQueue> Messages { get => _blockingMessage; }

        public MessageBroken()
        {
            _blockingMessage = new BlockingCollection<MessageQueue>();
        }

        public double SendMessageQueue(MessageQueue message)
        {
            _blockingMessage.TryAdd(message);
            Console.ResetColor();
            Console.WriteLine($"Message sent Code: {message.Code} TaskId: {Task.CurrentId} CurrentTotalMessages: {_blockingMessage.Count}");
            Thread.Sleep(1000);
            return message.Code;
        }
    }
}
