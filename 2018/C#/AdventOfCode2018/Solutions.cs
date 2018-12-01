using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Solutions
    {
        public static int DayOneOne(int[] inp) => inp.Sum();

        public static int DayOneTwo(int[] inp) 
        {
            var ansFound = false;
            var seenFreq = new Dictionary<int, bool>()
            {
                {0, true}
            };
            var freq = 0;
            var i = 0;

            while(!ansFound)
            {
                freq += inp[i % inp.Length];
                if (seenFreq.TryGetValue(freq, out bool seen))
                {
                    ansFound = seen;
                } 
                else
                {
                    seenFreq.Add(freq, true);
                }
                i++;
            }

            return freq;
        }
    }
}
