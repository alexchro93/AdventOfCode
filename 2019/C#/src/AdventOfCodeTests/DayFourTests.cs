using System.Collections;
using System.Collections.Generic;
using AdventOfCode;
using NUnit.Framework;

// ReSharper disable UnusedMember.Local

namespace AdventOfCodeTests
{
   [TestFixture]
   [Category("DayFour")]
   public class DayFourTests
   {
      [TestCaseSource(typeof(TestData), nameof(TestData.ProblemOneData))]
      public int ProblemOne_ValidInput_ReturnsCorrectResult(
         List<string> inp)
            => DayFour.ProblemOne(inp);

      [TestCaseSource(typeof(TestData), nameof(TestData.ProblemTwoData))]
      public int ProblemTwo_ValidInput_ReturnsCorrectResult(
         List<string> inp)
            => DayFour.ProblemTwo(inp);
        
      private class TestData
      {
         public static IEnumerable ProblemOneData
         {
            get
            {
               yield return new TestCaseData(
                     new List<string> { "111111", "223450", "123789"})
                  .Returns(1);
            }
         }
         
         public static IEnumerable ProblemTwoData
         {
            get
            {
               yield return new TestCaseData(
                     new List<string> { "112233", "123444", "111122"})
                  .Returns(2);
            }
         }
      } 
   }
}
