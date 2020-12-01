//
// Imports
//

#load "Solutions.fs"

//
// References
//

open System.IO
open AdventOfCode.Solutions

//
// Helpers
//

let readLines path = File.ReadAllLines path |> Array.toList

//
// Raw Input
//

let rawOne = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayOne.txt") |> readLines 
let inpOne = rawOne |> List.map System.Int32.Parse

//
// Day One
//

let ansOneOne = DayOne.One inpOne
let ansOneTwo = DayOne.Two inpOne

