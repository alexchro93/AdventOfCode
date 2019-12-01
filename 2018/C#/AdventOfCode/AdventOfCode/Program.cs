using System;
using CommandLine;
using LaYumba.Functional;

namespace AdventOfCode
{
   using static F;
    
    public static class Program
    {
        public static void Main(string[] args) =>
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(opts =>
                    SolveProblemForDay(opts.Day, opts.Problem)
                        .Match(
                            None: () => Console.WriteLine("Unable to get solution."),
                            Some: solution => Console.WriteLine($"Solution: {solution}.")));

        private static Option<string> SolveProblemForDay(Day day, Problem problem)
        {
            switch (day)
            {
               case Day.One :
                   return problem == Problem.One ? 
                       Solutions.DayOneProblemOne(InputProvider.GetDayOneProblemOneInput) : 
                       Solutions.DayOneProblemTwo(InputProvider.GetDayOneProblemTwoInput);
               case Day.Two :
                   return problem == Problem.One ? 
                        Solutions.DayTwoProblemOne(InputProvider.GetDayTwoProblemOneInput) :
                        Solutions.DayTwoProblemTwo(InputProvider.GetDayTwoProblemTwoInput);
               case Day.Three :
                   return problem == Problem.One
                       ? Solutions.DayThreeProblemOne(InputProvider.GetDayThreeProblemOneInput)
                       : Solutions.DayThreeProblemTwo(InputProvider.GetDayThreeProblemTwoInput);
               default:
                   return None;
            }
        }
   }
}