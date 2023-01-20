using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.Threading;

namespace LazyInitializationLabs.BL
{
    class DataWrapper
    {
        public DataWrapper()
        {
            CreateDataWrapper(false);
        }

        public DataWrapper(bool error = false)
        {
            CreateDataWrapper(error);
        }

        public void CreateDataWrapper(bool error = false)
        {
            try
            {
                CachedData = error ? GetDataFromDatabaseError(): GetDataFromDatabase();
                Console.WriteLine($"[{nameof(DataWrapper)}] Object initialized");
            }
            catch (Exception e)
            {
                Console.WriteLine($"[{nameof(DataWrapper)}] Object initialized Error Error: {e.Message}");
            }
        }
        public Data CachedData { get; set; }
        private Data GetDataFromDatabase()
        {
            //Dummy Delay
            Thread.Sleep(5000);
            return new Data();
        }

        private Data GetDataFromDatabaseError()
        {
            //Dummy Delay
            Thread.Sleep(5000);
            throw new Exception("Error");
         //   return new Data();
        }
    }
}
