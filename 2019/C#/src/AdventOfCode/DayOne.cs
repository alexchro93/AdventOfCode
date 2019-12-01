using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
   public static class DayOne
   {
      public static int ProblemOne(IEnumerable<int> inp)
         => inp.Sum(w => w / 3 - 2);

      public static int ProblemTwo(IEnumerable<int> inp)
      {
         int CalcWeight(int w)
         {
            var requiredFuel = w / 3 - 2;
            if (requiredFuel <= 0) return 0;
            return requiredFuel + CalcWeight(requiredFuel);
         }
         return inp.Sum(CalcWeight);
      }
   }
}
