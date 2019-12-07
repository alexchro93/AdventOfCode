using System.Collections;
using System.Collections.Generic;
using AdventOfCode;
using NUnit.Framework;

// ReSharper disable UnusedMember.Local

namespace AdventOfCodeTests
{
   [TestFixture]
   [Category("DaySix")]
   public class DaySixTests
   {
      [TestCaseSource(typeof(TestData), nameof(TestData.ProblemOneData))]
      public int ProblemOne_ValidInput_ReturnsCorrectResult(
         List<(string, string)> inp)
            => DaySix.ProblemOne(inp);

      private class TestData
      {
         public static IEnumerable ProblemOneData
         {
            get
            {
               yield return new TestCaseData(new List<(string, string)>
               {
                  ("COM", "B"),
                  ("B", "C"),
                  ("C", "D"),
                  ("D", "E"),
                  ("E", "F"),
                  ("B", "G"),
                  ("G", "H"),
                  ("D", "I"),
                  ("E", "J"),
                  ("J", "K"),
                  ("K", "L"),
               }).Returns(42);
            }
         }
      }
   }
}
