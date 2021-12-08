module AdventOfCode.Tests

open NUnit.Framework
open AdventOfCode

[<SetUp>]
let Setup () =
    ()

// Day Three Part Two

let OneOneInp = [
    TestCaseData([
        "00100";
        "11110";
        "10110";
        "10111";
        "10101";
        "01111";
        "00111";
        "11100";
        "10000";
        "11001";
        "00010";
        "01010";
    ]).Returns(230)
]

[<TestCaseSource("OneOneInp")>]
let DayThreeTwo x = DayThree.two x
    
