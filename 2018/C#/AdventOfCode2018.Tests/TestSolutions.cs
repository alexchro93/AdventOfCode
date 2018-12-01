using System.Net;
using AdventOfCode2018;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestSolutions
    {
        #region DayOneOne
        [Test]
        [TestCase(new int[] { 1, 1, 1 }, 3)]
        [TestCase(new int[] { 1, 1, -2 }, 0)]
        [TestCase(new int[] { -1, -2, -3 }, -6)]
        public void DayOneOne_SampleInput_ReturnsResult(int[] inp, int expectedAns)
        {
            // Act
            var actualAns = Solutions.DayOneOne(inp);

            // Assert
            Assert.AreEqual(expectedAns, actualAns);
        }
        #endregion

        #region DayOneTwo
        [Test]
        [TestCase(new int[] { 3, 3, 4, -2, -4}, 10)]
        [TestCase(new int[] { -6, 3, 8, 5, -6 }, 5)]
        [TestCase(new int[] { 7, 7, -2, -7, -4}, 14)]
        public void DayOneTwo_SampleInput_ReturnsResult(int[] inp, int expectedAns)
        {
            // Act
            var actualAns = Solutions.DayOneTwo(inp);

            // Assert
            Assert.AreEqual(expectedAns, actualAns);
        }
        #endregion
    }
}