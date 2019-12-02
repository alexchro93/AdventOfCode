using System;

namespace AdventOfCode
{
   public static class DayTwo
   {
      public static int[] ProblemOne(int[] inp)
      {
         var result = new int[inp.Length];
         Array.Copy(inp, result, inp.Length);
         
         for (var i = 0; i < inp.Length; i += 4)
         {
            if (result[i] == 99) break;
            
            var op = result[i];
            var opOneIndex = result[i + 1];
            var opTwoIndex = result[i + 2];
            var resultIndex = result[i + 3];
            
            if (op == 1)
               result[resultIndex] = result[opOneIndex] + result[opTwoIndex];
            else if (op == 2) 
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
               inp[1] = noun;
               inp[2] = verb;
               var result = ProblemOne(inp);
               if (result[0] == target)
                  return 100 * noun + verb;
            }
         }

         return -1;
      }
   }
}
