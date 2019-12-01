using System;
using System.Reflection;
using CommandLine;

namespace AdventOfCode
{
   class Program
   {
      public enum Day
      {
         One = 1
      }

      public enum Problem
      {
         One = 1,
         Two = 2
      }

      static void Main(string[] args)
         => Parser.Default.ParseArguments<Options>(args)
            .WithParsed(o =>
            {
               var methodName = "Day";

               switch (o.Day)
               {
                  case Day.One:
                     methodName += nameof(Day.One);
                     break;
               }

               switch (o.Problem)
               {
                  case Problem.One:
                     methodName += nameof(Problem.One);
                     break;
                  case Problem.Two:
                     methodName += nameof(Problem.Two);
                     break;
               }

               typeof(Program)
                  .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static)
                  ?.Invoke(null, null);
            });

      private static void DayOneOne()
      {
         var inp = InputProvider.DayOne();
         var result = DayOne.ProblemOne(inp);
         Console.WriteLine($"Day One Problem One Result - {result}");
      }

      private static void DayOneTwo()
      {
         var inp = InputProvider.DayOne();
         var result = DayOne.ProblemTwo(inp);
         Console.WriteLine($"Day One Problem Two Result - {result}");
      }

      public class Options
      {
         [Option('d', "day", Required = true, HelpText = "Day to solve problem")]
         public Day Day { get; set; }

         [Option('p', "problem", Required = true, HelpText = "1 (Problem One) or 2 (Problem 2")]
         public Problem Problem { get; set; }
      }
   }
}