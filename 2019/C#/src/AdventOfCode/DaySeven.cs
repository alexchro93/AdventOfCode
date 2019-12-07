using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Intcode;

namespace AdventOfCode
{
   public static class DaySeven
   {
      public static int ProblemOne(int[] intcode)
      {
         var maxOutput = 0;
         var phaseSettings = Enumerable.Range(0, 44444)
            .Select(i => i.ToString().PadLeft(5, '0'))
            .Where(i => i.Distinct().Count() == 5)
            .Where(i => !i.Any(x => (int) char.GetNumericValue(x) > 4))
            .ToList();

         foreach (var s in phaseSettings)
         {
            var output = 0;
            
            for (var t = 0; t < 5; t++)
            {
               var input = (int) char.GetNumericValue(s[t]);
               var computer = new IntcodeComputer(intcode, input, output);
               while (!computer.Complete)
                  computer.DoNextInst();
               output = computer.Output;
            }

            if (output > maxOutput)
               maxOutput = output;
         }

         return maxOutput;
      }

      public static int ProblemTwo(int[] intcode)
      {
         var maxOutput = 0;
         var phaseSettings = Enumerable.Range(55555, 44444)
            .Select(i => i.ToString().PadLeft(5, '0'))
            .Where(i => i.Distinct().Count() == 5)
            .Where(i => !i.Any(x => (int) char.GetNumericValue(x) < 5))
            .ToList();

         foreach (var s in phaseSettings)
         {
            var computers = s.Select(
                  c => new BlockingIntcodeComputer(intcode, (int) char.GetNumericValue(c)))
               .ToList();
            computers[0].Input.Add(0);
            var tasks = new Task[5];
            
            for (var i = 0; i < 5; i++)
            {
               var c = computers[i];
               var cNex = computers[(i + 1) % 5];
               c.OutputProduced += o => cNex.Input.Add(o);
               var t = Task.Run(() =>
               {
                  while (!c.Complete)
                     c.DoNextInst();
               });
               tasks[i] = t;
            }
            
            Task.WaitAll(tasks);
            
            if (computers[4].Output > maxOutput)
               maxOutput = computers[4].Output;
         }

         return maxOutput;
      }
   }
}
