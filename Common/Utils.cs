using System;
using System.Collections.Generic;

namespace Common
{
    public static class LinqHelpers
    {
        public static IEnumerable<T> SkipExceptions<T>(this IEnumerable<T> values)
        {
            using (var enumerator = values.GetEnumerator())
            {
                bool next = true;
                while (next)
                {
                    try
                    {
                        next = enumerator.MoveNext();
                    }
                    catch
                    {
                        continue;
                    }

                    if (next) yield return enumerator.Current;
                }
            }
        }
        
        public static IEnumerable<T> TakeWhileInclusive<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach(var item in source)
            {
                if(predicate(item)) 
                {
                    yield return item;
                }
                else
                {
                    yield return item;
                    yield break;
                }
            }
        }

        public static IEnumerable<T> SkipWithLastItem<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var found = false;
            var lastItem = default(T);
            foreach (var item in source)
            {
                if (!found)
                {
                    if (predicate(item))
                    {
                        lastItem = item;
                        continue;
                    }
                    
                    found = true;
                    if (lastItem != null)
                        yield return lastItem;
                }
                yield return item;
            }
        }
    }
}