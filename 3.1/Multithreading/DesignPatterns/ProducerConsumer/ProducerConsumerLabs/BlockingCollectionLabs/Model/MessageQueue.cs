using System;
using System.Collections.Generic;
using System.Text;

namespace TplProducerConsumerLabs.BlockingCollectionLabs.Model
{
    public class MessageQueue
    {
        public double Code { get; set; }
        public string Name { get; set; }

        public MessageQueue()
        {
            var r = new Random();

            Code = r.NextDouble();
            Name = $"Name {Code}";
        }
    }
}
