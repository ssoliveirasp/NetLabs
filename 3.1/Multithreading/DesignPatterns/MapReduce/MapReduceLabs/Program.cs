using System;
using System.Collections.Generic;
using System.Linq;

namespace MapReduceLabs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MapReduceTest();
        }

        private static void MapReduceTest()
        {
            //Maps only positive number from list
            Func<int, IEnumerable<int>> mapPositiveNumbers = number =>
            {
                IList<int> positiveNumbers = new List<int>();
                if (number > 0)
                    positiveNumbers.Add(number);
                return positiveNumbers;
            };

            // Group results together
            Func<int, int> groupNumbers = value => value;
            //Reduce function that counts the occurence of each number
            Func<IGrouping<int, int>, IEnumerable<KeyValuePair<int, int>>> reduceNumbers =
                grouping => new[] { new KeyValuePair<int, int>(grouping.Key, grouping.Count()) };

            // Generate a list of random numbers between -10 and 10
            IList<int> sourceData = new List<int>();
            var rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                sourceData.Add(rand.Next(-10, 10));
            }

            // Use MapReduce function
            var result = sourceData.AsParallel().MapReduce(
                mapPositiveNumbers,
                groupNumbers,
                reduceNumbers);
            // process the results
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} found {item.Value} times");
            }

        }
    }
}
