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
         Two = 2,
         Three = 3,
         Four = 4,
         Five = 5,
         Six = 6,
         Seven = 7,
         Eight = 8
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
               Console.WriteLine($"Day {o.Day} Problem {o.Problem} Result - {result}");
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

      private static int DayTwoOne()
      {
         var inp = InputProvider.DayTwo();
         return DayTwo.ProblemOne(inp, 12, 2)[0];
      }
      
      private static int DayTwoTwo()
      {
         var inp = InputProvider.DayTwo();
         return DayTwo.ProblemTwo(inp, 19690720);
      }

      private static int DayThreeOne()
      {
         var inp = InputProvider.DayThree();
         return DayThree.ProblemOne(inp.Item1, inp.Item2);
      }
      
      private static int DayThreeTwo()
      {
         var inp = InputProvider.DayThree();
         return DayThree.ProblemTwo(inp.Item1, inp.Item2);
      }
      
      private static int DayFourOne()
      {
         var inp = InputProvider.DayFour();
         return DayFour.ProblemOne(inp);
      }
     
      private static int DayFourTwo()
      {
         var inp = InputProvider.DayFour();
         return DayFour.ProblemTwo(inp);
      }
      
      private static int DayFiveOne()
      {
         var inp = InputProvider.DayFive();
         return DayFive.ProblemOne(inp, 1);
      }
      
      private static int DayFiveTwo()
      {
         var inp = InputProvider.DayFive();
         return DayFive.ProblemOne(inp, 5);
      }
     
      private static int DaySixOne()
      {
         var inp = InputProvider.DaySix();
         return DaySix.ProblemOne(inp);
      }
      
      private static int DaySixTwo()
      {
         var inp = InputProvider.DaySix();
         return DaySix.ProblemTwo(inp);
      }
      
      private static int DaySevenOne()
      {
         var inp = InputProvider.DaySeven();
         return DaySeven.ProblemOne(inp);
      }
      
      private static int DaySevenTwo()
      {
         var inp = InputProvider.DaySeven();
         return DaySeven.ProblemTwo(inp);
      }

      private static int DayEightOne()
      {
         var inp = InputProvider.DayEight();
         return DayEight.ProblemOne(inp);
      }

      private static string DayEightTwo()
      {
         var inp = InputProvider.DayEight();
         return DayEight.ProblemTwo(inp);
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
