using System;
using LazyInitializationLabs.BL;

namespace LazyInitializationLabs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateLazySuccessInitialize();
            CreateLazyErrorInitialize();
            LazyThreadSafe.Execute();

            Console.ReadKey();
        }

        private static void CreateLazySuccessInitialize()
        {
            Console.WriteLine($"[{nameof(CreateLazySuccessInitialize)}] Creating Lazy object success");
            Lazy<DataWrapper> lazyDataWrapper = new Lazy<DataWrapper>();
            Console.WriteLine($"[{nameof(CreateLazySuccessInitialize)}] Lazy Object Created");
            Console.WriteLine($"[{nameof(CreateLazySuccessInitialize)}] Now we want to access data");
            var data = lazyDataWrapper.Value.CachedData;

            Console.WriteLine($"[{nameof(CreateLazySuccessInitialize)}] Finishing up IsValueCreated: {lazyDataWrapper.IsValueCreated}");
        }

        private static void CreateLazyErrorInitialize()
        {
            Console.WriteLine();
            Console.WriteLine($"[{nameof(CreateLazyErrorInitialize)}] Creating Lazy object success");
            Lazy<DataWrapper> lazyDataWrapper = new Lazy<DataWrapper>(()=> new DataWrapper(true));
            Console.WriteLine($"[{nameof(CreateLazyErrorInitialize)}] Lazy Object Created");
            Console.WriteLine($"[{nameof(CreateLazyErrorInitialize)}] Now we want to access data");
            var data = lazyDataWrapper.Value.CachedData;

            Console.WriteLine($"[{nameof(CreateLazyErrorInitialize)}] Finishing up IsValueCreated: {lazyDataWrapper.IsValueCreated}");
        }
    }
}
