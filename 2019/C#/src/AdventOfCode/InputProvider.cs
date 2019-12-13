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
        
        private static readonly string _dayFivePath = 
            _rootDir + "DayFive.txt";
        
        private static readonly string _daySixPath = 
            _rootDir + "DaySix.txt";
        
        private static readonly string _daySevenPath = 
            _rootDir + "DaySeven.txt";

        private static readonly string _dayEightPath = 
            _rootDir + "DayEight.txt";

        private static readonly string _dayNinePath = 
            _rootDir + "DayNine.txt";

        private static readonly string _dayTenPath = 
            _rootDir + "DayTen.txt";
        
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
            Debug.Assert(File.Exists(_dayFivePath), 
                $"Day five test data not available: {_dayFivePath}");
            Debug.Assert(File.Exists(_daySixPath), 
                $"Day six test data not available: {_daySixPath}");
            Debug.Assert(File.Exists(_daySevenPath), 
                $"Day seven test data not available: {_daySevenPath}");
            Debug.Assert(File.Exists(_dayEightPath), 
                $"Day eight test data not available: {_dayEightPath}");
            Debug.Assert(File.Exists(_dayNinePath), 
                $"Day nine test data not available: {_dayNinePath}");
            Debug.Assert(File.Exists(_dayTenPath), 
                $"Day ten test data not available: {_dayTenPath}");
        }

        public static int[] DayOne() =>
            File.ReadAllLines(_dayOnePath)
                .Select(int.Parse)
                .ToArray();

        public static int[] DayTwo() => 
           File.ReadAllLines(_dayTwoPath)
              .SelectMany(s => s.Split(","))
              .Select(int.Parse)
              .ToArray();

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

        public static int[] DayFive() => 
           File.ReadAllLines(_dayFivePath)
              .SelectMany(s => s.Split(","))
              .Select(int.Parse)
              .ToArray();

        public static List<(string, string)> DaySix() =>
           File.ReadAllLines(_daySixPath)
              .Select(s =>
              {
                 var split = s.Split(")");
                 return (split[0], split[1]);
              })
              .ToList();
        
        public static int[] DaySeven() =>
           File.ReadAllLines(_daySevenPath)
              .SelectMany(s => s.Split(","))
              .Select(int.Parse)
              .ToArray();

         public static int[] DayEight() =>
            File.ReadAllLines(_dayEightPath)
               .Aggregate((b, a) => b + a)
               .Select(c => (int) char.GetNumericValue(c))
               .ToArray();

         public static long[] DayNine() =>
            File.ReadAllLines(_dayNinePath)
               .SelectMany(x => x.Split(","))
               .Select(long.Parse)
               .ToArray();

         public static HashSet<(int x, int y)> DayTen()
         {
            var ret = new HashSet<(int x, int y)>();
            var lines = File.ReadAllLines(_dayTenPath);
            for (var i = 0; i < lines.Length; i++)
            {
               var chars = lines[i].ToCharArray();
               for (var j = 0; j < chars.Length; j++)
               {
                  if (chars[j] == '#') ret.Add((j, i));
               }
            }
            return ret;
         }
    }
}
