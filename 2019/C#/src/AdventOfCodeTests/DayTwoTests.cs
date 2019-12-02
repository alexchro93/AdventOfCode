using System.Collections;
using AdventOfCode;
using NUnit.Framework;

// ReSharper disable once UnusedMember.Local

namespace AdventOfCodeTests
{
   [TestFixture]
   [Category("DayTwo")]
   public class DayTwoTests
   {
      [TestCaseSource(typeof(TestData), nameof(TestData.ProblemOneData))]
      public int[] ProblemOne_ValidInput_ReturnsCorrectResult(int[] inp) =>
         DayTwo.ProblemOne(inp);
      
      private class TestData
      {
         public static IEnumerable ProblemOneData
         {
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
