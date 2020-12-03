//
// Imports
//

#load "DayOne.fs"
#load "DayTwo.fs"
#load "DayThree.fs"

//
// References
//

open System.IO
open System.Text.RegularExpressions;
open AdventOfCode.Solutions

//
// Helpers
//

let readLines path = File.ReadAllLines path |> Array.toList

//
// Day One
//

let rawOne = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayOne.txt") |> readLines 
let inpOne = rawOne |> List.map System.Int32.Parse

let ansOneOne = DayOne.One inpOne
let ansOneTwo = DayOne.Two inpOne

//
// Day Two
//

let getTwo (x: string) : DayTwo.Line =
    let m = Regex.Match(x, @"(?<Min>\d+)-(?<Max>\d+)\s{1}(?<Chr>\w{1})[:]{1}\s{1}(?<Psd>\w+)")
    { Min = (m.Groups.Item "Min").Value |> int;
      Max = (m.Groups.Item "Max").Value |> int;
      Chr = (m.Groups.Item "Chr").Value |> char;
      Psd = (m.Groups.Item "Psd").Value }

let rawTwo = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayTwo.txt") |> readLines 
let inpTwo = rawTwo |> List.map getTwo

let ansTwoOne = DayTwo.One inpTwo
let ansTwoTwo = DayTwo.Two inpTwo

//
// Day Three
//

let slopes : DayThree.Slope list = 
    [ { Right = 1; Down = 1 };
      { Right = 3; Down = 1 };
      { Right = 5; Down = 1 };
      { Right = 7; Down = 1 };
      { Right = 1; Down = 2 } ]

let rawThree = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayThree.txt") |> readLines 
let inpThree = rawThree 

let ansThreeOne = DayThree.One inpThree (slopes.Item 1)
let ansThreeTwo = DayThree.Two inpThree slopes

