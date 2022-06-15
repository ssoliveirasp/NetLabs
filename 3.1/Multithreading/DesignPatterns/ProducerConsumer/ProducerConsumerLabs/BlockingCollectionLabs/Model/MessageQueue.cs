using System;

namespace PubSubBlockingCollectionLabs.BlockingCollectionLabs.Model
{
    public class MessageQueue
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public MessageQueue()
        {
            var r = new Random();

            Code = r.Next(10000, 90000);
            Name = $"Name {Code}";
        }
    }
}
