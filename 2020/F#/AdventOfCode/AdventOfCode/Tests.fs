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

