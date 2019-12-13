using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Exceptions;

namespace AdventOfCode
{
   public static class DayTen
   {
      public static int ProblemOne(HashSet<(int x, int y)> inp)
         => inp.Select(p => 
               inp.Where(i => i != p) 
                  .Select(i => (Slope(p, i), Quad((i.x - p.x, i.y - p.y))))
                  .Distinct()
                  .Count()).Max();

      private static double Slope((int x, int y) p1, (int x, int y) p2)
          => Math.Atan2((p2.y - p1.y), (p2.x - p1.x));

      private static int Quad((int x, int y) p)
      {
         if (p.x >= 0 && p.y > 0) return 1;
         if (p.x > 0 && p.y <= 0) return 4;
         if (p.x <= 0 && p.y < 0) return 3;
         if (p.x < 0 && p.y >= 0) return 2;
         throw new ProblemNotSolvedException("couldn't find quad");
      }
   }
}
