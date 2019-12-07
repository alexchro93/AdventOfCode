using System.Collections;
using AdventOfCode;
using NUnit.Framework;

// ReSharper disable UnusedMember.Local

namespace AdventOfCodeTests
{
   [TestFixture]
   [Category("DayFive")]
   public class DayFiveTests
   {
      [TestCaseSource(typeof(TestData), nameof(TestData.ProblemOneData))]
      public int ProblemOne_ValidInput_ReturnsCorrectResult(
         int[] intcode, int inp)
            => DayFive.ProblemOne(intcode, inp);
        
      [TestCaseSource(typeof(TestData), nameof(TestData.ProblemTwoData))]
      public int ProblemTwo_ValidInput_ReturnsCorrectResult(
         int[] intcode, int inp)
            => DayFive.ProblemTwo(intcode, inp);
      
      private class TestData
      {
         public static IEnumerable ProblemOneData
         {
            get
            {
               yield return new TestCaseData(new[] {3, 0, 4, 0, 99}, 2).Returns(2);
               yield return new TestCaseData(new[] {1002, 4, 3, 4, 1, 0, 4, 0, 99}, 6).Returns(6);
            }
         }
         
         public static IEnumerable ProblemTwoData
         {
            get
            {
               yield return new TestCaseData(new[] {3,9,8,9,10,9,4,9,99,-1,8}, 7).Returns(0);
               yield return new TestCaseData(new[] {3,9,8,9,10,9,4,9,99,-1,8}, 8).Returns(1);
               yield return new TestCaseData(new[] {3,9,7,9,10,9,4,9,99,-1,8}, 7).Returns(1);
               yield return new TestCaseData(new[] {3,9,7,9,10,9,4,9,99,-1,8}, 8).Returns(0);
               yield return new TestCaseData(new[] {3,3,1108,-1,8,3,4,3,99}, 7).Returns(0);
               yield return new TestCaseData(new[] {3,3,1108,-1,8,3,4,3,99}, 8).Returns(1);
               yield return new TestCaseData(new[] {3,3,1107,-1,8,3,4,3,99}, 7).Returns(1);
               yield return new TestCaseData(new[] {3,3,1107,-1,8,3,4,3,99}, 8).Returns(0);
               yield return new TestCaseData(new[] {3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9}, 0).Returns(0);
               yield return new TestCaseData(new[] {3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9}, 1).Returns(1);
               yield return new TestCaseData(new[] {3,3,1105,-1,9,1101,0,0,12,4,12,99,1}, 0).Returns(0);
               yield return new TestCaseData(new[] {3,3,1105,-1,9,1101,0,0,12,4,12,99,1}, 1).Returns(1);
               yield return new TestCaseData(new[] {
                  3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                  1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                  999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99}, 8).Returns(1000);
               yield return new TestCaseData(new[] {
                  3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                  1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                  999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99}, 9).Returns(1001);
            }
         }
      }    
   }
}
