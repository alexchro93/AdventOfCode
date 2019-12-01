using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AdventOfCode.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Finds all elements in first which don't equal
        /// the corresponding position-similar element in second
        /// </summary>
        /// <param name="first">First enumerable</param>
        /// <param name="second">Second enumerable</param>
        /// <typeparam name="TSource">Underlying type of input enumerables</typeparam>
        /// <returns></returns>
        public static IEnumerable<(TSource value, int index)> OrderedExcept<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            var firstArr = first.ToArray();
            var secondArr = second.ToArray();

            var retElements = new List<(TSource, int)>();
            
            for (var i = 0; i < firstArr.Length; i++)
            {
                if (i >= secondArr.Length || 
                    !firstArr[i].Equals(secondArr[i]))
                    retElements.Add((firstArr[i], i));
            }

            return retElements;
        }
    }
}