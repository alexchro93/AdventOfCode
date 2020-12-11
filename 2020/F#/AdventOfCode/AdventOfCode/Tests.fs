namespace AdventOfCode.Tests

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

    // Day Nine Part One

    static member NineOneInp = [
        TestCaseData([
            35UL;
            20UL;
            15UL;
            25UL;
            47UL;
            40UL;
            62UL;
            55UL;
            65UL;
            95UL;
            102UL;
            117UL;
            150UL;
            182UL;
            127UL;
            219UL;
            299UL;
            277UL;
            309UL;
            576UL;
        ] : uint64 list).Returns(127)
    ]

    [<TestCaseSource("NineOneInp")>]
     member __.DayNineOne(x) = Solutions.DayNine.One x 5

    // Day Nine Part Two

    static member NineTwoInp = [
        TestCaseData([
            35UL;
            20UL;
            15UL;
            25UL;
            47UL;
            40UL;
            62UL;
            55UL;
            65UL;
            95UL;
            102UL;
            117UL;
            150UL;
            182UL;
            127UL;
            219UL;
            299UL;
            277UL;
            309UL;
            576UL;
        ] : uint64 list).Returns(62)
    ]

    [<TestCaseSource("NineTwoInp")>]
    member __.DayNineTwo(x) = Solutions.DayNine.Two x 5

    // Day Ten Part One

    static member TenTwoOne = [
        TestCaseData([
            16;
            10;
            15;
            5;
            1;
            11;
            7;
            19;
            6;
            12;
            4;
        ]).Returns(22)
    ]

    [<TestCaseSource("TenTwoInp")>]
    member __.DayTenOne(x) = Solutions.DayTen.Two x

    // Day Ten Part Two

    static member TenTwoInp = [
        TestCaseData([
            16;
            10;
            15;
            5;
            1;
            11;
            7;
            19;
            6;
            12;
            4;
        ]).Returns(8)
    ]

    [<TestCaseSource("TenTwoInp")>]
    member __.DayTenTwo(x) = Solutions.DayTen.Two x
