using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Exceptions;

namespace AdventOfCode
{
   public static class DayThree
   {
      public static int ProblemOne(
         List<string> pOne, List<string> pTwo)
      {
         var coordsOne = GetCoordinates(pOne);
         var coordsTwo = GetCoordinates(pTwo);

         return coordsOne.Intersect(coordsTwo)
            .Select(c => Math.Abs(c.x) + Math.Abs(c.y))
            .Min();
      }

      public static int ProblemTwo(
         List<string> pOne, List<string> pTwo)
      {
         var coordsOne = GetCoordinates(pOne);
         var coordsTwo = GetCoordinates(pTwo);

         return coordsOne.Intersect(coordsTwo)
            .Select(c =>
            {
               var numOne = coordsOne.TakeWhile(cOne => cOne != c).Count();
               var numTwo = coordsTwo.TakeWhile(cTwo => cTwo != c).Count();
               return numOne + numTwo + 2; // include intersection
            })
            .Min();
      }

      private static List<(int x, int y)> GetCoordinates(List<string> inps)
      {
         var coordinates = new List<(int x, int y)>();
         var previous = (x: 0, y: 0);
         foreach (var inp in inps)
         {
            var dir = inp[0];
            var amt = int.Parse(inp.Substring(1));
            foreach (var unused in Enumerable.Range(0, amt))
            {
               (int x, int y) next;
               switch (dir)
               {
                  case 'U':
                     next = (previous.x, previous.y + 1);
                     break;
                  case 'D':
                     next = (previous.x, previous.y - 1);
                     break;
                  case 'L':
                     next = (previous.x - 1, previous.y);
                     break;
                  case 'R':
                     next = (previous.x + 1, previous.y);
                     break;
                  default:
                     throw new ProblemNotSolvedException($"D3P1: invalid direction {dir}");
               }
               coordinates.Add(next);
               previous = next;
            }
         }
         return coordinates;
      }
   }
}
