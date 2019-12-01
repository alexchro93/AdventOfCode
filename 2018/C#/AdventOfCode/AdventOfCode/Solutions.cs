using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Extensions;

namespace AdventOfCode
{
    public static class Solutions
    {
        public static string DayOneProblemOne(Func<IEnumerable<int>> getInput) =>
            getInput().Sum().ToString();

        public static string DayOneProblemTwo(Func<IEnumerable<int>> getInput)
        {
            var inputs = new Span<int>(getInput().ToArray());
            var seenFrequencies = new HashSet<int>(new [] { 0 });

            var currentFreq = 0;
            var nextFreq = 0;
            var inpIndex = 0;
            var seenTwice = false;

            while (!seenTwice)
            {
                nextFreq = currentFreq + inputs[inpIndex % inputs.Length];

                if (seenFrequencies.Contains(nextFreq))
                {
                    seenTwice = true;
                }
                else
                {
                    seenFrequencies.Add(nextFreq);
                    currentFreq = nextFreq;
                }

                inpIndex++;
            }

            return nextFreq.ToString();
        }

        public static string DayTwoProblemOne(Func<IEnumerable<string>> getInput)
        {
            var numTwo = 0;
            var numThree = 0;

            foreach (var inp in getInput())
            {
                numTwo += inp.GroupBy(x => x).Count(b => b.Count() == 2) > 0 ? 1 : 0;
                numThree += inp.GroupBy(x => x).Count(b => b.Count() == 3) > 0 ? 1 : 0;
            }
            
            return (numTwo * numThree).ToString();
        }

        public static string DayTwoProblemTwo(Func<IEnumerable<string>> getInput)
        {
            var inputs = getInput().ToArray();

            for (var i = 0; i < inputs.Length; i++)
            {
                var inpI = inputs[i];
                
                for (var j = i; j < inputs.Length; j++)
                {
                    var inpJ = inputs[j];
                    
                    var diffI = inpI.OrderedExcept(inpJ).ToArray();
                    if (diffI.Length != 1) continue;

                    return inpI.Remove(diffI[0].index, 1);
                }
            }

            return string.Empty;
        }

        public static string DayThreeProblemOne(
            Func<IEnumerable<((int startX, int startY), (int width, int height))>> getInput)
        {
            IEnumerable<(int x, int y)> GetPoints((int startX, int startY) start, (int width, int height) lengths) 
            {
                var points = new List<(int x, int y)>();
                
                for (var i = 0; i < lengths.width; i++)
                {
                    for (var j = 0; j < lengths.height; j++)
                    {
                        points.Add((start.startX + i, start.startY + j));
                    }
                }

                return points;
            };

            var numOverlapping = getInput()
                .SelectMany(x => GetPoints(x.Item1, x.Item2))
                .GroupBy(x => x)
                .Count(x => x.Count() >= 2);

            return numOverlapping.ToString();
        }

        public static string DayThreeProblemTwo(
            Func<IEnumerable<((int startX, int startY), (int width, int height))>> getInput)
        {
            throw new NotImplementedException();
        }
    }
}