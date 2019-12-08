using System.Linq;
using System.Text;
using MoreLinq;

namespace AdventOfCode
{
    public static class DayEight
   {
      public static int ProblemOne(int[] inp) 
      {
         var minLayer = inp.Batch(6 * 25)
            .Select(x => x.ToArray())
            .Aggregate((min, x) => min.Count(i => i == 0) < x.Count(i => i == 0) ? min : x);

         return minLayer.Count(i => i == 1) * minLayer.Count(i => i == 2);
      }

      public static string ProblemTwo(int[] inp)
      {
         var layers = inp.Batch(6 * 25)
            .Select(x => x.ToArray());

         var ans = new int[6,25];

         for (var r = 0; r < 6; r++)
            for (var c = 0; c < 25; c++)
               ans[r, c] = 2;

         foreach (var layer in layers)         
            for (var r = 0; r < 6; r++)
               for (var c = 0; c < 25; c++)
                  if (ans[r,c] == 2) 
                     ans[r,c] = layer[25 * r + c];

         return PrettyPrintImage(ans);
      }

      public static string PrettyPrintImage(int[,] matrix)
      {
         var sb = new StringBuilder("\n\n");
         for (var r = 0; r < matrix.GetLength(0); r++)
         {
            for (var c = 0; c < matrix.GetLength(1); c++)
            {
               if (matrix[r,c] == 0) sb.Append(" ");
               else sb.Append(matrix[r,c]);
            }
            sb.AppendLine();
         }
         return sb.ToString();
      }
   }
}
