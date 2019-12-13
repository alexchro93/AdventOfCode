using AdventOfCode.Intcode;

namespace AdventOfCode
{
    public static class DayNine
   {
      public static long ProblemOne(long[] inp)
      {
         var computer = new RelativeComputer(inp, 1);
         while (computer.DoNext()) { }
         return computer.Output.Dequeue();
      }

      public static long ProblemTwo(long[] inp)
      {
         var computer = new RelativeComputer(inp, 2);
         while (computer.DoNext()) { }
         return computer.Output.Dequeue();
      }
   }
}
