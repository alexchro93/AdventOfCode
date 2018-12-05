using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Solutions
    {
        #region Day1
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
        #endregion

        #region Day2 
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
        #endregion

        #region Day3
        public static int DayThreeOne(Dictionary<int, List<Tuple<int, int>>> inp)
        {
            var fabric = new int[1000, 1000];
            var numOverlapped = 0;
            var coordinates = inp.Values
                                 .ToList()
                                 .SelectMany(x => x)
                                 .ToList();

            foreach(var coordinate in coordinates)
            {
                if (fabric[coordinate.Item1, coordinate.Item2] == 1)
                {
                    numOverlapped++;
                } 
                fabric[coordinate.Item1, coordinate.Item2]++;
            }

            return numOverlapped;
        }

        public static int DayThreeTwo(Dictionary<int, List<Tuple<int, int>>> inp)
        {
            var fabric = new int[1000, 1000];
            var idOverlaps = new Dictionary<int, bool>();

            foreach (var id in inp.Keys)
            {   
                if (inp.TryGetValue(id, out var coordinates))
                {
                    var overlappedIds = new List<int>() { id };

                    foreach (var coordinate in coordinates)
                    {
                        if (fabric[coordinate.Item1, coordinate.Item2] != 0)
                        {
                            overlappedIds.Add(fabric[coordinate.Item1, coordinate.Item2]);
                        }
                        else
                        {
                            fabric[coordinate.Item1, coordinate.Item2] = id;
                        }
                    }                   

                    if (overlappedIds.Count > 1)
                    {
                        overlappedIds.ForEach(x => idOverlaps[x] = true);
                    } 
                    else
                    {
                        idOverlaps[overlappedIds.First()] = false;
                    }
                }
            } 

            return idOverlaps.Where(x => x.Value == false).Single().Key;
        }
        #endregion
    
        #region Day4
        public enum Event
        {
            Begin,
            FallAsleep,
            WakeUp
        }

        public static int DayFourOne(Dictionary<int, List<(DateTime, Event)>> inp)
        {
            var possibleAns = new HashSet<(int, int, int)>();

            inp.ToList().ForEach(x => {
                var timesSawMinute = new int[60];
                var timeSpentSleeping = 0;
                var sleepStart = new DateTime();
                foreach (var entry in x.Value)
                {
                    switch (entry.Item2)
                    {
                        case Event.FallAsleep:
                            sleepStart = entry.Item1;
                            break;
                        case Event.WakeUp:
                            var minsSleeping = entry.Item1.Minute - sleepStart.Minute;
                            timeSpentSleeping += minsSleeping;
                            Enumerable.Range(sleepStart.Minute, minsSleeping)
                                      .ToList()
                                      .ForEach(i => timesSawMinute[i]++);
                            break;
                    }
                    possibleAns.Add((
                        x.Key,
                        timeSpentSleeping,
                        Array.IndexOf(timesSawMinute, timesSawMinute.Max())
                    ));
                }
            });

            var ans = possibleAns.Where(x => x.Item2 == possibleAns.Max(i => i.Item2)).First();
            return ans.Item1 * ans.Item3;
        }

        public static int DayFourTwo(Dictionary<int, List<(DateTime, Event)>> inp)
        {
            var possibleAns = new HashSet<(int, int, (int, int))>();

            inp.ToList().ForEach(x => {
                var timesSawMinute = new int[60];
                var timeSpentSleeping = 0;
                var sleepStart = new DateTime();

                foreach (var entry in x.Value)
                {
                    switch (entry.Item2)
                    {
                        case Event.FallAsleep:
                            sleepStart = entry.Item1;
                            break;
                        case Event.WakeUp:
                            var minsSleeping = entry.Item1.Minute - sleepStart.Minute;
                            timeSpentSleeping += minsSleeping;
                            Enumerable.Range(sleepStart.Minute, minsSleeping)
                                      .ToList()
                                      .ForEach(i => timesSawMinute[i]++);
                            break;
                    }
                    possibleAns.Add((
                        x.Key,
                        timeSpentSleeping,
                        (Array.IndexOf(timesSawMinute, timesSawMinute.Max()), timesSawMinute.Max())
                    ));
                }
            });

            var ans = possibleAns.Where(x => x.Item3.Item2 == possibleAns.Max(i => i.Item3.Item2)).First();
            return ans.Item1 * ans.Item3.Item1;
        }
        #endregion
    }
}
