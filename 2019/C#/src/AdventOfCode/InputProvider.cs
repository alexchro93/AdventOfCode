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

        static InputProvider()
        {
            Debug.Assert(Directory.Exists(_rootDir), 
                $"Test data directory not available: {_rootDir}");
            Debug.Assert(File.Exists(_dayOnePath), 
                $"Day one test data not available: {_dayOnePath}");
        }

        public static int[] DayOne() =>
            File.ReadAllLines(_dayOnePath)
                .Select(int.Parse)
                .ToArray();
    }
}
