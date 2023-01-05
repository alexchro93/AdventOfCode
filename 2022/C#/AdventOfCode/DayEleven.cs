namespace AdventOfCode
{
   internal class Monkey
   {
      public Monkey(string[] setup)
      {
         Id = int.Parse(setup[0].Substring(7, 1));
         Items = new Queue<long>(
            setup[1].Substring(18).Split(", ").Select(long.Parse));
         Operation = setup[2].Replace("  Operation: new = old ", "").Split(" ") switch
         {
            ["+", var arg1] when arg1 == "old" => old => old + old,
            ["+", var arg1] => old => old + int.Parse(arg1),
            ["*", var arg1] when arg1 == "old" => old => old * old,
            ["*", var arg1] => old => old * int.Parse(arg1)
         };
         Mod = long.Parse(setup[3].Replace("  Test: divisible by ", ""));
         DestTrue = int.Parse(setup[4].Replace("    If true: throw to monkey ", ""));
         DestFalse = int.Parse(setup[5].Replace("    If false: throw to monkey ", ""));
      }

      public int Id { get; init; }

      public Queue<long> Items { get; init; }

      public Func<long, long> Operation { get; init; }

      public long Mod { get; init; }

      public int DestTrue { get; init; }

      public int DestFalse { get; init; }
   }

   internal static class DayEleven
   {
      public static long One(List<Monkey> input)
      {
         return Solve(input, 20, i => i / 3);
      }

      public static long Two(List<Monkey> input)
      {
         // I would have never figured this part out on my own...
         // Thanks to https://www.reddit.com/r/adventofcode/ for the hints

         var agg = input.Aggregate(1L, (a, i) => a * i.Mod);

         // Now, solve...

         return Solve(input, 10_000, i => i % agg);
      }

      private static long Solve(
         List<Monkey> input,
         int numIter,
         Func<long, long> update)
      {
         var numberInspections = Enumerable.Repeat(0L, input.Count).ToList();

         foreach (var _ in Enumerable.Range(0, numIter))
         {
            foreach (var m in input)
            {
               numberInspections[m.Id] += m.Items.Count;
               while (m.Items.TryDequeue(out var item))
               {
                  var newWorry = update(m.Operation(item));
                  var dest = newWorry % m.Mod == 0 ? m.DestTrue : m.DestFalse;
                  input[dest].Items.Enqueue(newWorry);
               }
            }
         }

         return numberInspections
            .OrderByDescending(x => x)
            .Take(2)
            .Aggregate(1L, (a, i) => a * i);
      }
   }
}
