using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class InputProvider
    {
        private static readonly string _rootDir = 
            Directory.GetCurrentDirectory() + "/../../../data/";

        private static readonly string _dayOnePath = 
            _rootDir + "DayOne.txt";

        private static readonly string _dayTwoPath = 
            _rootDir + "DayTwo.txt";
        
        private static readonly string _dayThreePath = 
            _rootDir + "DayThree.txt";
        
        static InputProvider()
        {
            Debug.Assert(Directory.Exists(_rootDir), 
                $"Test data directory not available: {_rootDir}");
            Debug.Assert(File.Exists(_dayOnePath), 
                $"Day one test data not available: {_dayOnePath}");
            Debug.Assert(File.Exists(_dayTwoPath), 
                $"Day two test data not available: {_dayTwoPath}");
            Debug.Assert(File.Exists(_dayThreePath), 
                $"Day three test data not available: {_dayThreePath}");
        }

        public static int[] DayOne() =>
            File.ReadAllLines(_dayOnePath)
                .Select(int.Parse)
                .ToArray();

        public static int[] DayTwo()
        {
           var rawInp = File.ReadAllLines(_dayTwoPath)
              .SelectMany(s => s.Split(","))
              .Select(int.Parse)
              .ToArray();

           return rawInp;
        }

        public static (List<string> pOne, List<string> pTwo) DayThree()
        {
           var lines = File.ReadAllLines(_dayThreePath)
              .Select(s => s.Split(",").ToList())
              .ToList();

           return (lines[0], lines[1]);
        }

        public static List<string> DayFour()
        {
           var inp = new List<string>(919123 - 387638);
           for (var i = 387638; i <= 919123; i++)
              inp.Add(i.ToString());
           return inp;
        }
    }
}
