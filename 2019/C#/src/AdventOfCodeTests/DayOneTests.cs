using System.Collections;
using AdventOfCode;
using NUnit.Framework;

// ReSharper disable UnusedMember.Local

namespace AdventOfCodeTests
{
   [TestFixture]
   [Category("DayOne")]
   public class DayOneTests
   {
      [TestCaseSource(typeof(TestData), nameof(TestData.ProblemOneData))]
      public int ProblemOne_ValidInput_ReturnsCorrectResult(int[] inp)
         => DayOne.ProblemOne(inp);

      [TestCaseSource(typeof(TestData), nameof(TestData.ProblemTwoData))]
      public int ProblemTwo_ValidInput_ReturnsCorrectResult(int[] inp)
         => DayOne.ProblemTwo(inp);

      private class TestData
      {
         public static IEnumerable ProblemOneData
         {
            get
            {
               yield return new TestCaseData(new[] {12}).Returns(2);
               yield return new TestCaseData(new[] {14}).Returns(2);
               yield return new TestCaseData(new[] {1969}).Returns(654);
               yield return new TestCaseData(new[] {100756}).Returns(33583);
               yield return new TestCaseData(new[] {12, 14, 1969, 100756}).Returns(34241);
            }
         }

         public static IEnumerable ProblemTwoData
         {
            get
            {
               yield return new TestCaseData(new[] {12}).Returns(2);
               yield return new TestCaseData(new[] {14}).Returns(2);
               yield return new TestCaseData(new[] {1969}).Returns(966);
               yield return new TestCaseData(new[] {100756}).Returns(50346);
               yield return new TestCaseData(new[] {12, 14, 1969, 100756}).Returns(51316);
            }
         }
      }
   }
}
