using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode;
using NUnit.Framework;
// ReSharper disable StringLiteralTypo

namespace AdventOfCodeTests
{
    public class Tests
    {
        [TestCase("+1 +1 +1", "3")]
        [TestCase("+1 +1 -2", "0")]
        [TestCase("-1 -2 -3", "-6")]
        public void TestDayOneProblemOne(string inp, string expectedResult)
        {
            // Act
            var actualAnswer = Solutions.DayOneProblemOne(() => inp.Split(" ").Select(int.Parse));

            // Assert
            Assert.That(actualAnswer, Is.EqualTo(expectedResult));
        }

        [TestCase("+1 -1", "0")]
        [TestCase("+3 +3 +4 -2 -4", "10")]
        [TestCase("-6 +3 +8 +5 -6", "5")]
        [TestCase("+7 +7 -2 -7 -4", "14")]
        public void TestDayOneProblemTwo(string inp, string expectedResult)
        {
           // Act
            var actualAnswer = Solutions.DayOneProblemTwo(() => inp.Split(" ").Select(int.Parse));
           
           // Assert
           Assert.That(actualAnswer, Is.EqualTo(expectedResult));
        }

        [TestCase(new[] { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" }, "12")]
        public void TestDayTwoProblemOne(IEnumerable<string> inp, string expectedResult)
        {
            // Act
            var actualAnswer = Solutions.DayTwoProblemOne(() => inp);

            // Assert
            Assert.That(actualAnswer, Is.EqualTo(expectedResult));
        }

        [TestCase(new[] {"abcdef", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz"}, "fgij")]
        public void TestDayTwoProblemTwo(IEnumerable<string> inp, string expectedResult)
        {
            // Act
            var actualAnswer = Solutions.DayTwoProblemTwo(() => inp);

            // Assert
            Assert.That(actualAnswer, Is.EqualTo(expectedResult));
        }

        [TestCase(new[] {"1 3 4 4", "3 1 4 4", "5 5 2 2"}, "4")]
        public void TestDayThreeProblemOne(IEnumerable<string> inp, string expectedAnswer)
        {
            // Act
            var actualAnswer = Solutions.DayThreeProblemOne(() => inp.Select(x =>
            {
                var splitInps = x.Split(" ");
                return (
                    (int.Parse(splitInps[0]), int.Parse(splitInps[1])),
                    (int.Parse(splitInps[3]), int.Parse(splitInps[3])));
            }));
            
            // Assert
            Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
        }
    }
}