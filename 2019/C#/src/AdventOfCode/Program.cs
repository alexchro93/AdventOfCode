using System;
using System.Reflection;
using CommandLine;

// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace AdventOfCode
{
   internal class Program
   {
      public enum Day
      {
         One = 1,
      }

      public enum Problem
      {
         One = 1,
         Two = 2
      }

      private static void Main(string[] args)
         => Parser.Default.ParseArguments<Options>(args)
            .WithParsed(o =>
            {
               var methodName = $"Day{o.Day}{o.Problem}";
               var result = typeof(Program)
                  .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static)
                  ?.Invoke(null, null) ?? "not implemented";
               Console.WriteLine($"Day {o.Day} Problem {o.Problem} Result - {result}.");
            });

      private static int DayOneOne()
      {
         var inp = InputProvider.DayOne();
         return DayOne.ProblemOne(inp);
      }

      private static int DayOneTwo()
      {
         var inp = InputProvider.DayOne();
         return DayOne.ProblemTwo(inp);
      }

      public class Options
      {
         [Option('d', "day", Required = true, HelpText = "Day to solve problem [1, 25]")]
         public Day Day { get; set; }

         [Option('p', "problem", Required = true, HelpText = "Problem to solve [1, 2]")]
         public Problem Problem { get; set; }
      }
   }
}
