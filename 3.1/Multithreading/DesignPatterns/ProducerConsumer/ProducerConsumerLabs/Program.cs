using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using TplProducerConsumerLabs.BlockingCollectionLabs.BL;

namespace ProducerConsumerLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            var producer = new ProducerQueue(maxProducers: 500, maxMessagesPerProducer: 5);

            producer
              .ShowSummaryProperties()
              .CreateProducers()
              .WaitingProducers()
              .ShowSummaryProperties();

            //Task consumer = taskFactory.StartNew(() =>
            //{
            //    while (!blockingCollection.IsCompleted)
            //    {
            //        try
            //        {
            //            int imageID = blockingCollection.Take();
            //            ProcessImage(imageID);
            //        }
            //        catch (Exception ex)
            //        {
            //            //Log exception 
            //        }
            //    }
            //});



            Console.Read();

        }

        public static int ReadImageFromDB()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Image is read");
            return 1;
        }

        public static void ProcessImage(int imageID)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Image is processed");

        }
    }
}
