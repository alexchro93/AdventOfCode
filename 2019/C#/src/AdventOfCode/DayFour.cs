using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
   public static class DayFour
   {
      public static int ProblemOne(List<string> inp)
         => inp.Where(i => i.Length == 6)
            .Select(x => x.Select(c => (int) char.GetNumericValue(c)).ToList())
            .Where(ContainsTwoAdj)
            .Where(IsIncreasingVal) 
            .Count();
      
      public static int ProblemTwo(List<string> inp)
         => inp.Where(i => i.Length == 6)
            .Select(x => x.Select(c => (int) char.GetNumericValue(c)).ToList())
            .Where(ContainsOnlyTwoAdj)
            .Where(IsIncreasingVal) 
            .Count();
      
      private static bool ContainsTwoAdj(List<int> inp)
      {
         var prev = inp[0];
         for (var i = 1; i < inp.Count; i++)
         {
            if (inp[i] == prev) return true;
            prev = inp[i];
         }
         return false;
      }

      private static bool ContainsOnlyTwoAdj(List<int> inp)
      {
         var counts = new Dictionary<int, int>();
         var prev = inp[0];
         for (var i = 1; i < inp.Count; i++)
         {
            if (inp[i] == prev)
            {
               if (counts.ContainsKey(prev))
                  counts[prev]++;
               else
                  counts[prev] = 1;
            }
            prev = inp[i];
         }
         return counts.Values.Any(c => c == 1);
      }
      
      private static bool IsIncreasingVal(List<int> inp)
      {
         var prev = inp[0];
         for (var i = 1; i < inp.Count; i++)
         {
            if (inp[i] < prev) return false;
            prev = inp[i];
         }
         return true;
      }
   }
}
