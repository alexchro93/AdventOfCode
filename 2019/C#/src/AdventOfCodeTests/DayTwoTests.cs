using System.Collections;
using AdventOfCode;
using NUnit.Framework;

namespace AdventOfCodeTests
{
   [TestFixture]
   [Category("DayTwo")]
   public class DayTwoTests
   {
      private class TestData
      {
         [TestCaseSource(typeof(TestData), nameof(ProblemOneData))]
         public int[] ProblemOne_ValidInput_ReturnsCorrectResult(int[] inp) =>
            DayTwo.ProblemOne(inp);

         private static IEnumerable ProblemOneData
         {
            // ReSharper disable once UnusedMember.Local
            get
            {
               yield return new TestCaseData(new[] {1,0,0,0,99})
                  .Returns(new [] {2,0,0,0,99});
               yield return new TestCaseData(new[] {1,1,1,4,99,5,6,0,99})
                  .Returns(new [] {30,1,1,4,2,5,6,0,99});
            }
         }
      } 
   }
}
