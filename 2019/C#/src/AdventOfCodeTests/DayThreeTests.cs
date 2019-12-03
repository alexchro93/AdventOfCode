using System.Collections;
using System.Collections.Generic;
using AdventOfCode;
using NUnit.Framework;

// ReSharper disable UnusedMember.Local

namespace AdventOfCodeTests
{
   [TestFixture]
   [Category("DayThree")]
   public class DayThreeTests
   {
      [TestCaseSource(typeof(TestData), nameof(TestData.ProblemOneData))]
      public int ProblemOne_ValidInput_ReturnsCorrectResult(
         List<string> pOne, List<string> pTwo) 
            => DayThree.ProblemOne(pOne, pTwo);

      [TestCaseSource(typeof(TestData), nameof(TestData.ProblemTwoData))]
      public int ProblemTwo_ValidInput_ReturnsCorrectResult(
         List<string> pOne, List<string> pTwo)
            => DayThree.ProblemTwo(pOne, pTwo);
        
      private class TestData
      {
         public static IEnumerable ProblemOneData
         {
            get
            {
               yield return new TestCaseData(
                     new List<string> {"R75","D30","R83","U83","L12","D49","R71","U7","L72"},
                     new List<string> {"U62","R66","U55","R34","D71","R55","D58","R83"})
                  .Returns(159);
            }
         }
         
         public static IEnumerable ProblemTwoData
         {
            get
            {
               yield return new TestCaseData(
                     new List<string> {"R75","D30","R83","U83","L12","D49","R71","U7","L72"},
                     new List<string> {"U62","R66","U55","R34","D71","R55","D58","R83"})
                  .Returns(610);
            }
         }
      } 
   }
}
