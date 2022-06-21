using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace loadbalancingPartitioner
{
    internal static class ListExtensions
    {
        /// <summary>
        /// https://stackoverflow.com/questions/11463734/split-a-list-into-smaller-lists-of-n-size
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static List<IEnumerable<T>> ChuckBy<T>(this IEnumerable<T> source, long size)
        {
            if (size < 0)
                size = 1;

            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / size)
                .Select(x => x.Select((v => v.Value)))
                .ToList();
        }
    }
}
