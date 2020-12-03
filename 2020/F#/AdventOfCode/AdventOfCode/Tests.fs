﻿namespace AdventOfCode.Tests

open AdventOfCode
open NUnit.Framework

[<TestFixture>]
type Tests() =
  
    // Day One Part One

    static member OneOneInp = [
        TestCaseData([
            1721;
            979;
            366;
            299;
            675;
            1456]).Returns(514579)
    ]

    [<TestCaseSource("OneOneInp")>]
    member __.DayOneOne(x) = Solutions.DayOne.One x

    // Day One Part Two
    
    static member OneTwoInp = [
        TestCaseData([
            1721;
            979;
            366;
            299;
            675;
            1456]).Returns(241861950)
    ]

    [<TestCaseSource("OneTwoInp")>]
    member __.DayOneTwo(x) = Solutions.DayOne.Two x

    // Day Two Part One

    static member TwoOneInp = [
        TestCaseData([
            { Min = 1; Max = 3; Chr = 'a'; Psd = "abcde"; };
            { Min = 1; Max = 3; Chr = 'b'; Psd = "cdefg"; };
            { Min = 2; Max = 9; Chr = 'c'; Psd = "ccccccccc"; }
        ] : Solutions.DayTwo.Line list).Returns(2)
    ]

    [<TestCaseSource("TwoOneInp")>]
    member __.DayTwoOne(x) = Solutions.DayTwo.One x

    // Day Two Part Two

    static member TwoTwoInp = [
        TestCaseData([
            { Min = 1; Max = 3; Chr = 'a'; Psd = "abcde"; };
            { Min = 1; Max = 3; Chr = 'b'; Psd = "cdefg"; };
            { Min = 2; Max = 9; Chr = 'c'; Psd = "ccccccccc"; }
        ] : Solutions.DayTwo.Line list).Returns(1)
    ]

    [<TestCaseSource("TwoTwoInp")>]
    member __.DayTwoTwo(x) = Solutions.DayTwo.Two x


    // Day Three Part One

    static member ThreeOneInp = [
        TestCaseData([
            "..##.......";
            "#...#...#..";
            ".#....#..#.";
            "..#.#...#.#";
            ".#...##..#.";
            "..#.##.....";
            ".#.#.#....#";
            ".#........#";
            "#.##...#...";
            "#...##....#";
            ".#..#...#.#" 
        ])
    ]

    [<TestCaseSource("ThreeOneInp")>]
    member __.DayThreeOne(x) = 
        // Arrange
        let slope : Solutions.DayThree.Slope = { Right = 3; Down = 1 }

        // Act
        let ans = Solutions.DayThree.One x slope
        
        // Assert
        Assert.AreEqual(7u, ans)

    // Day Three Part Two

    [<TestCaseSource("ThreeOneInp")>]
    member __.DayThreeTwo(x) = 
        // Arrange
        let slopes : Solutions.DayThree.Slope list = 
            [ { Right = 1; Down = 1 };
              { Right = 3; Down = 1 };
              { Right = 5; Down = 1 };
              { Right = 7; Down = 1 };
              { Right = 1; Down = 2 } ]

        // Act
        let ans = Solutions.DayThree.Two x slopes

        // Assert
        Assert.AreEqual(336u, ans)

