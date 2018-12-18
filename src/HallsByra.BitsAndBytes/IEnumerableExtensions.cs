using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallsByra.BitsAndBytes
{
    internal static class IEnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int chunkSize)
        {
            var chunk = new List<T>(chunkSize);
            foreach (var x in source)
            {
                chunk.Add(x);
                if (chunk.Count == chunkSize)
                {
                    yield return chunk;
                    chunk = new List<T>(chunkSize);
                }
            }
            if (chunk.Any())
            {
                yield return chunk;
            }
        }

        public static void Each<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var element in source)
                action(element);
        }

        public static IEnumerable<T> PadRight<T>(this IEnumerable<T> source, int length)
        {
            int i = 0;
            foreach(var item in source.Take(length)) 
            {
                yield return item;
                i++;
            }
            for( ; i < length; i++)
                yield return default(T);
        }
    }
}
