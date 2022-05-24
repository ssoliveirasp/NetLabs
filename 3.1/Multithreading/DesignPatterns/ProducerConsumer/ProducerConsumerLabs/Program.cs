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
            var manager = new ProducerQueue();

            manager.CreateProducers();

            //int maxColl = 10;
            //var blockingCollection = new BlockingCollection<int>(maxColl);
            //var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning,
            //TaskContinuationOptions.None);

            //Task producer = taskFactory.StartNew(() =>
            //{
            //    if (blockingCollection.Count <= maxColl)
            //    {
            //        int imageID = ReadImageFromDB();
            //        blockingCollection.Add(imageID);
            //        blockingCollection.CompleteAdding();
            //    }
            //});


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

            Console.WriteLine($"Producers - Count:{manager.Producers.Count}");

            while(manager.Messages.IsAddingCompleted == false) { }

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
