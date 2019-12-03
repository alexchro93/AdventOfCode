using System;
using AdventOfCode.Exceptions;

namespace AdventOfCode
{
   public static class DayTwo
   {
      public static int[] ProblemOne(
         int[] inp, int? noun = null, int? verb = null)
      {
         var result = new int[inp.Length];
         Array.Copy(inp, result, inp.Length);

         if (noun.HasValue) result[1] = noun.Value;
         if (verb.HasValue) result[2] = verb.Value;
         
         for (var i = 0; i < inp.Length; i += 4)
         {
            if (result[i] == 99) break;
            
            var op = result[i];
            var opOneIndex = result[i + 1];
            var opTwoIndex = result[i + 2];
            var resultIndex = result[i + 3];
            
            if (op == 1)
               result[resultIndex] = result[opOneIndex] + result[opTwoIndex];
            if (op == 2) 
               result[resultIndex] = result[opOneIndex] * result[opTwoIndex];
         }
         
         return result;
      }

      public static int ProblemTwo(int[] inp, int target)
      {
         for (var noun = 0; noun < 99; noun++)
         {
            for (var verb = 0; verb < 99; verb++)
            {
               var result = ProblemOne(inp, noun, verb);
               if (result[0] == target)
                  return 100 * noun + verb;
            }
         }
         throw new ProblemNotSolvedException(
            $"D2P2: couldn't find noun or verb for target -  {target}");
      }
   }
}
