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

        #region DayTwoOne
        [Test]
        [TestCase(new string[] 
        { 
            "abcdef", 
            "bababc",
            "abbcde",
            "abcccd",
            "aabcdd",
            "abcdee",
            "ababab"
        }, 12)]
        public void DayTwoOne_SampleInput_ReturnResult(string[] inp, int expectedAns)
        {
            // Act
            var actualAns = Solutions.DayTwoOne(inp);
            
            // Assert
            Assert.AreEqual(expectedAns, actualAns);
        }
        #endregion

        #region DayTwoTwo
        [Test]
        [TestCase(new string[] 
        { 
            "abcde",
            "fghij",
            "klmno",
            "pqrst",
            "fguij",
            "axcye",
            "wvxyz"
        }, "fgij")]
        public void DayTwoTwo_SampleInput_ReturnResult(string[] inp, string expectedAns)
        {
            // Act
            var actualAns = Solutions.DayTwoTwo(inp);
            
            // Assert
            Assert.AreEqual(expectedAns, actualAns); 
        }
        #endregion
    
        #region DayThreeOne
        [Test]
        [TestCase(new string[] 
        {
            "#1 @ 1,3: 4x4",
            "#2 @ 3,1: 4x4",
            "#3 @ 5,5: 2x2"
        }, 4)]
        public void DayThreeOne_SampleInput_ReturnResult(string[] inp, int expectedAns)
        {
            // Arrange
            var puzzleInp = Inputs.GetDayThreeInput(inp);

            // Act
            var actualAns = Solutions.DayThreeOne(puzzleInp);

            // Assert
            Assert.AreEqual(expectedAns, actualAns);
        }

        [Test]
        [TestCase(new string[] 
        {
            "#1 @ 1,3: 4x4",
            "#2 @ 3,1: 4x4",
            "#3 @ 5,5: 2x2"
        }, 3)]
        public void DayThreeTwo_SampleInput_ReturnResult(string[] inp, int expectedAns)
        {
            // Arrange
            var puzzleInp = Inputs.GetDayThreeInput(inp);

            // Act
            var actualAns = Solutions.DayThreeTwo(puzzleInp);

            // Assert
            Assert.AreEqual(expectedAns, actualAns);
        }
        #endregion
    }
}