using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace AdventOfCode
{
    public static class InputProvider
    {
        private static string _dayOneInpFilePath = "./Inputs/DayOne.txt";
        private static string _dayTwoInpFilePath = "./Inputs/DayTwo.txt";
        private static string _dayThreeInpFilePath = "./Inputs/DayThree.txt";
        
        public static IEnumerable<int> GetDayOneProblemOneInput() =>
            File.ReadAllLines(_dayOneInpFilePath).Select(int.Parse).AsEnumerable();

        public static IEnumerable<int> GetDayOneProblemTwoInput() => GetDayOneProblemOneInput();

        public static IEnumerable<string> GetDayTwoProblemOneInput() =>
            File.ReadAllLines(_dayTwoInpFilePath);

        public static IEnumerable<string> GetDayTwoProblemTwoInput() => GetDayTwoProblemOneInput();

        public static IEnumerable<((int startX, int startY), (int width, int height))> GetDayThreeProblemOneInput() =>
            File.ReadAllLines(_dayThreeInpFilePath)
                .Select(x => x.Replace(":", string.Empty))
                .Select(x =>
                {
                    var splitInp = x.Split(" ");
                    var start = splitInp[2].Split(",");
                    var lengths = splitInp[3].Split("x");

                    var startX = int.Parse(start[0]);
                    var startY = int.Parse(start[1]);
                    var width = int.Parse(lengths[0]);
                    var height = int.Parse(lengths[1]);

                    return ((startX, startY), (width, height));
                });

        public static IEnumerable<((int startX, int startY), (int width, int height))> GetDayThreeProblemTwoInput() =>
            GetDayThreeProblemOneInput();
    }
}