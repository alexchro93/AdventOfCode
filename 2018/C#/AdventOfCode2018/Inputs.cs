using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static AdventOfCode2018.Solutions;

namespace AdventOfCode2018
{
    public static class Inputs
    {
       public static int[] GetDayOneInput()
       {
            var inputFilePath = "./input/DayOne.txt";
            var textInp = File.ReadAllLines(inputFilePath);
            return textInp.Select(x => Int32.Parse(x)).ToArray();
       }
    
        public static string[] GetDayTwoInput()
        {
            var inputFilePath = "./input/DayTwo.txt";
            return File.ReadAllLines(inputFilePath);
        }

        public static Dictionary<int, List<Tuple<int, int>>> GetDayThreeInput(string[] rawInp)
        {
            var inputs = new Dictionary<int, List<Tuple<int, int>>>();

            foreach (var inpLine in rawInp)
            {
                var splitInp = inpLine.Split();
                var startIndices = splitInp[2].TrimEnd(':').Split(',');
                var distances = splitInp[3].Split('x');

                var id = Int32.Parse(splitInp[0].Substring(1));
                var startWidth = Int32.Parse(startIndices[0]);
                var startHeight = Int32.Parse(startIndices[1]);
                var width = Int32.Parse(distances[0]);
                var height = Int32.Parse(distances[1]);

                for (int i = startWidth; i < startWidth + width; i++)
                {
                    for (int j = startHeight; j < startHeight + height; j++)
                    {
                        if (inputs.TryGetValue(id, out var coordinates))
                        {
                            coordinates.Add(new Tuple<int, int>(i, j));
                        }
                        else
                        {
                            coordinates = new List<Tuple<int, int>>()
                            {
                                new Tuple<int, int>(i, j)
                            };
                            inputs.Add(id, coordinates);
                        }
                    }
                }
            }

            return inputs;
        }

        public static Dictionary<int, List<Tuple<int, int>>> GetDayThreeInput()
        {
            var inputFilePath = "./input/DayThree.txt";
            return GetDayThreeInput(File.ReadAllLines(inputFilePath));
        }

        public static Dictionary<int, List<(DateTime, Event)>> GetDayFourInput(string[] rawInp)
        {
            var orderedInput = rawInp
                .Select(x => {
                    var date = DateTime.Parse(x.Substring(1, 16));
                    var rest = x.Substring(19);

                    return new { date, rest }; 
                }).OrderBy(x => x.date).ToList();
        
            var inputs = new Dictionary<int, List<(DateTime, Event)>>();
            var guardId = 0;
            var eventType = Event.Begin;

            foreach (var entry in orderedInput)
            {
                var inpComponents = entry.rest.Split();
                if (inpComponents[0].Equals("Guard"))
                {
                    guardId = Int32.Parse(inpComponents[1].Substring(1));
                    eventType = Event.Begin;
                }
                else if (inpComponents[0].Equals("falls"))
                {
                    eventType = Event.FallAsleep;
                }
                else if (inpComponents[0].Equals("wakes"))
                {
                    eventType = Event.WakeUp;
                }

                if (inputs.TryGetValue(guardId, out var events))
                {
                    events.Add((entry.date, eventType));
                }
                else
                {
                    events = new List<(DateTime, Event)>()
                    {
                        (entry.date, eventType)
                    };
                    inputs.Add(guardId, events);
                }
            }

            return inputs;
        }
    
        public static Dictionary<int, List<(DateTime, Event)>> GetDayFourInput()
        {
            var inputFilePath = "./input/DayFour.txt";
            return GetDayFourInput(File.ReadAllLines(inputFilePath));
        }
    }
}