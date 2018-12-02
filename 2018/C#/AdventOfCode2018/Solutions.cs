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
            var seenFreq = new HashSet<int>()
            {
                {0}
            };
            var freq = 0;
            var i = 0;

            while(!ansFound)
            {
                freq += inp[i % inp.Length];
                if (seenFreq.Contains(freq))
                {
                    ansFound = true;;
                } 
                else
                {
                    seenFreq.Add(freq);
                }
                i++;
            }

            return freq;
        }
    
        public static int DayTwoOne(string[] inp)
        {
            var numTwo = 0;
            var numThree = 0;

            foreach (var boxId in inp)
            {
                numTwo += boxId
                    .ToCharArray()
                    .GroupBy(s => s)
                    .Where(s => s.Count() == 2)
                    .Count() > 0 ? 1 : 0;

                numThree += boxId
                    .ToCharArray()
                    .GroupBy(s => s)
                    .Where(s => s.Count() == 3)
                    .Count() > 0 ? 1 : 0;
            }

            return numTwo * numThree;
        }

        public static string DayTwoTwo(string[] inp)
        {
            for (var i = 0; i < inp.Count(); i++)
            {
                for (var j = i; j < inp.Count(); j++)
                {
                    var diffPos = new HashSet<int>();
                    for (var x = 0; x < inp[i].Length; x++)
                    {
                        if (inp[i][x] != inp[j][x]) diffPos.Add(x);
                    }

                    if (diffPos.Count() == 1) 
                        return inp[i].Remove(diffPos.First(), 1);
                }
            }

            return null;
        }
    }
}
