namespace AdventOfCode
{
   public record Computer(int Clock, int X);

   public abstract class Inst
   {
      public bool Done { get; internal set; } = false;

      public abstract Computer Run(Computer computer);

      public static Inst GetInst(string[] s) => s switch
      {
         ["noop"] => new Noop(),
         ["addx", var arg1] => new AddX() { Arg1 = int.Parse(arg1) },
         _ => throw new ArgumentException("invalid input")
      };
   }

   public class Noop : Inst
   {
      public override Computer Run(Computer computer)
      {
         Done = true;
         return computer;
      }
   }

   public class AddX : Inst
   {
      private int _run = 0;

      public int Arg1 { get; init; } 

      public override Computer Run(Computer computer)
      {
         if (_run == 1)
         {
            computer = computer with { X = computer.X + Arg1 };
            Done = true;
         }
         _run++;
         return computer;
      }
   }

   internal static class DayTen
   {
      public static int One(List<string> input)
      {
         var targets = new List<int>() { 20, 60, 100, 140, 180, 220 };
         var computer = new Computer(0, 1);
         var strength = 0;

         foreach (var i in input)
         {
            var inst = Inst.GetInst(i.Split(" "));

            while (!inst.Done)
            {
               // set the current cycle

               computer = computer with { Clock = computer.Clock + 1 };

               // check for strength

               if (targets.Contains(computer.Clock))
               {
                  strength += computer.Clock * computer.X;
               }

               // run instruction

               computer = inst.Run(computer);
            }
         }

         return strength;
      }

      public static string Two(List<string> input)
      {
         var ret = Enumerable.Repeat('.', 240).ToArray();
         var computer = new Computer(0, 1);

         foreach (var i in input)
         {
            var inst = Inst.GetInst(i.Split(" "));

            while (!inst.Done)
            {
               // set the current cycle

               computer = computer with { Clock = computer.Clock + 1 };

               // check for strength

               var pos = (computer.Clock - 1) % 40;
               if ((new List<int> { computer.X - 1, computer.X, computer.X + 1 }).Contains(pos))
               {
                  ret[computer.Clock - 1] = '#';
               }

               // run instruction

               computer = inst.Run(computer);
            }
         }

         return new string(ret);
      }
   }
}
