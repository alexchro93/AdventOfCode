using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

namespace AdventOfCode2018
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Check input
            if (args.Length != 2) 
            {
                Console.WriteLine("invalid number of arguments");
                System.Environment.Exit(1);
            }

            // Get program input
            var day = args[0];
            var puzzle = args[1];

            // Get puzzle solution function
            var methodName = GetMethodNameForDayAndPuzzle(day, puzzle);
            var type = typeof(Program);
            var methodInfo = type.GetMethod(methodName);

            // Solve puzzle
            methodInfo.Invoke(null, null);
        }

        public static void DayOneOne()
        {
            // Get Input
            var inp = Inputs.GetDayOneInput();

             // Solve puzzle
             var solution = Solutions.DayOneOne(inp);

             // Display Solution
             Console.WriteLine($"Day One One Solution: {solution}");
        }

        public static void DayOneTwo()
        {
            // Get Input
            var inp = Inputs.GetDayOneInput();

             // Solve puzzle
             var solution = Solutions.DayOneTwo(inp);

             // Display Solution
             Console.WriteLine($"Day One Two Solution: {solution}");
        }

        public static void DayTwoOne()
        {
            // Get Input
            var inp = Inputs.GetDayTwoInput();

             // Solve puzzle
             var solution = Solutions.DayTwoOne(inp);

             // Display Solution
             Console.WriteLine($"Day Two One Solution: {solution}");
        }

        public static void DayTwoTwo()
        {
            // Get Input
            var inp = Inputs.GetDayTwoInput();

             // Solve puzzle
             var solution = Solutions.DayTwoTwo(inp);

             // Display Solution
             Console.WriteLine($"Day Two Two Solution: {solution}");
        }

        private static string GetMethodNameForDayAndPuzzle(string day, string puzzle)
        {
            var methodName = "Day";

            switch(day)
            {
                case "1":
                    methodName = $"{methodName}One";
                    break;
                case "2":
                    methodName = $"{methodName}Two";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch(puzzle)
            {
                case "1":
                    methodName = $"{methodName}One";
                    break;
                case "2":
                    methodName = $"{methodName}Two";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return methodName;
        }
    }
}