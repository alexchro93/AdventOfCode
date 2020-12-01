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
