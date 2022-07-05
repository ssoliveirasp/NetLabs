﻿using System;
using System.Collections.Generic;
using System.Linq;


public static class PatternExtensions
{
    public static ParallelQuery<TResult> MapReduce<TSource, TMapped, TKey, TResult>(
        this ParallelQuery<TSource> source,
        Func<TSource, IEnumerable<TMapped>> map,
        Func<TMapped, TKey> keySelector,
        Func<IGrouping<TKey, TMapped>, IEnumerable<TResult>> reduce)
    {
        return source.SelectMany(map)
            .GroupBy(keySelector)
            .SelectMany(reduce);
    }
}