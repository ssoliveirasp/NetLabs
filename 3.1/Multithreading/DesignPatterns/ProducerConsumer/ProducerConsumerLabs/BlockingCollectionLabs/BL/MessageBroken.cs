using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TplProducerConsumerLabs.BlockingCollectionLabs.Model;

namespace TplProducerConsumerLabs.BlockingCollectionLabs.BL
{
    public class MessageBroken
    {
        BlockingCollection<MessageQueue> _blockingMessage;

        public BlockingCollection<MessageQueue> Messages { get => _blockingMessage; }

        public MessageBroken()
        {
            _blockingMessage = new BlockingCollection<MessageQueue>();
        }

        public double SendMessageQueue(MessageQueue message)
        {
            _blockingMessage.TryAdd(message);
            Console.ResetColor();
            Console.WriteLine($"Message sent Code: {message.Code.ToString()} TaskId: {Task.CurrentId.ToString()} CurrentTotalMessages: {_blockingMessage.Count.ToString()}");
            Thread.Sleep(1000);
            return message.Code;
        }
    }
}
