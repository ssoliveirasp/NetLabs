using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LazyInitializationLabs.BL
{
    internal class LazyInitializerEnsureInitialized
    {
        static Data _data;
        static bool _initialized;

        static object _locker = new object();

        static void Initializer()
        {
            Console.WriteLine($"Task with id {Task.CurrentId}");

            LazyInitializer.EnsureInitialized(ref _data, ref _initialized, ref _locker, () =>
            {
                Console.WriteLine($"Task with id {Task.CurrentId} is Initializing data");
                // Returns value that will be assigned in the ref parameter.
                return new Data();
            });
        }

        public static void Execute()
        {
            Console.WriteLine($"{nameof(LazyInitializerEnsureInitialized)} Started");

            Parallel.For(1, 10, (i) => Initializer());

            Console.ReadLine();
        }
    }
}
