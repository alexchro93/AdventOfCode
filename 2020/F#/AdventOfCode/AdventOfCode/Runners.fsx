//
// Imports
//

#load "DayOne.fs"
#load "DayTwo.fs"

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

let getTwo (x: string) : DayTwo.Line =
    let m = Regex.Match(x, @"(?<Min>\d+)-(?<Max>\d+)\s{1}(?<Chr>\w{1})[:]{1}\s{1}(?<Psd>\w+)")
    { Min = (m.Groups.Item "Min").Value |> int;
      Max = (m.Groups.Item "Max").Value |> int;
      Chr = (m.Groups.Item "Chr").Value |> char;
      Psd = (m.Groups.Item "Psd").Value }

//
// Raw Input
//

let rawOne = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayOne.txt") |> readLines 
let inpOne = rawOne |> List.map System.Int32.Parse

let rawTwo = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayTwo.txt") |> readLines 
let inpTwo = rawTwo |> List.map getTwo

//
// Day One
//

let ansOneOne = DayOne.One inpOne
let ansOneTwo = DayOne.Two inpOne

//
// Day Two
//

let ansTwoOne = DayTwo.One inpTwo
let ansTwoTwo = DayTwo.Two inpTwo
