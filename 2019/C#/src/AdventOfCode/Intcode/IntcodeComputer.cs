using System;

namespace AdventOfCode.Intcode
{
   public class IntcodeComputer
   { 
      private int _inpLoc;
      private bool _complete;

      public IntcodeComputer(int[] intcode, params int[] inp)
      {
         Intcode = new int[intcode.Length];
         Array.Copy(intcode, Intcode, intcode.Length);
         Input = inp;
      }

      public int[] Intcode { get; }
      public int ProgramCounter { get; private set; }
      public int[] Input { get; } 
      public int Output { get; private set; }
      public bool Complete => _complete || ProgramCounter >= Intcode.Length;

      public void DoNextInst()
      {
         if (Complete) return;
         
         var inst = GetInstruction();
         var op = inst.Substring(3);

         // check done
         if (op == "99")
         {
            _complete = true;
            return;
         }
         
         // instructions requiring one param 
         var pOne = Intcode[ProgramCounter + 1];
         
         switch (op)
         {
            case "03":
               InputInst(pOne);
               return;
            case "04":
               OutputInst(pOne);
               return;
         }

         // instructions requiring two params
         var pOneMode = inst[2];
         pOne = pOneMode == '0'
            ? Intcode[Intcode[ProgramCounter + 1]]
            : Intcode[ProgramCounter + 1];
         var pTwoMode = inst[1];
         var pTwo = pTwoMode == '0'
            ? Intcode[Intcode[ProgramCounter + 2]]
            : Intcode[ProgramCounter + 2];

         switch (op)
         {
            case "05":
               Jump(pOne, pTwo, v => v != 0);
               return;
            case "06":
               Jump(pOne, pTwo, v => v == 0);
               return;
         }

         // instructions requiring three params
         var pThree = Intcode[ProgramCounter + 3];

         switch (op)
         {
            case "01":
               AddInst(pOne, pTwo, pThree);
               return;
            case "02":
               MultiplyInst(pOne, pTwo, pThree);
               return;
            case "07":
               CompareStore(pOne, pTwo, pThree, (f, s) => f < s);
               return;
            case "08":
               CompareStore(pOne, pTwo, pThree, (f, s) => f == s);
               return;
         }
      }

      private void InputInst(int pOne)
      {
         Intcode[pOne] = Input[_inpLoc++];
         ProgramCounter += 2;
      }

      private void OutputInst(int pOne)
      {
         Output = Intcode[pOne];
         ProgramCounter += 2;
      }
      
      private void AddInst(int pOne, int pTwo, int pThree)
      {
         Intcode[pThree] = pOne + pTwo;
         ProgramCounter += 4;
      }
      
      private void MultiplyInst(int pOne, int pTwo, int pThree)
      {
         Intcode[pThree] = pOne * pTwo;
         ProgramCounter += 4;
      }

      private void Jump(
         int pOne, int pTwo, Func<int, bool> comp)
      {
         if (comp(pOne)) ProgramCounter = pTwo;
         else ProgramCounter += 3;
      }

      private void CompareStore(
         int pOne, int pTwo, int pThree, Func<int, int, bool> comp)
      {
         if (comp(pOne, pTwo)) Intcode[pThree] = 1;
         else Intcode[pThree] = 0;
         ProgramCounter += 4;
      }
      
      private string GetInstruction()
         => Intcode[ProgramCounter]
            .ToString()
            .PadLeft(5, '0');
   }
}
