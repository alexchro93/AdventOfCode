#load "DayOne.fs"
#load "DayTwo.fs"
#load "DayThree.fs"
#load "DayFour.fs"
#load "DayFive.fs"
#load "DaySix.fs"
#load "DaySeven.fs"
#load "DayEight.fs"

#r "nuget: FSharpx.Extras" 

open System.IO
open AdventOfCode
open FSharpx

//
// Helpers
//

let readLines path = File.ReadAllLines path |> Array.toList

// 
// Day One
//

let rawOne = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayOne.txt") |> readLines 
let inpOne = rawOne |> List.map System.Int32.Parse

let ansOneOne = DayOne.one inpOne
let ansTwoOne = DayOne.two inpOne

// 
// Day Two
//

let rawTwo = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayTwo.txt") |> readLines 
let inpTwo = rawTwo |> List.map (fun i -> 
                                    let x = i |> String.splitChar [|' '|]
                                    x[0], int x[1] )

let ansOneTwo = DayTwo.one inpTwo
let ansTwoTwo = DayTwo.two inpTwo

//
// Day Three
//

let rawThree = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayThree.txt") |> readLines

let ansThreeOne = DayThree.one rawThree
let ansThreeTwo = DayThree.two rawThree

//
// Day Four
//

let rawFour = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayFour.txt") |> readLines

let drawnNumbers = rawFour.Head |> String.splitChar [|','|] |> Array.toList |> List.map int
let boards = 
    let getNums s =
        s |> String.splitChar [|' '|] 
          |> Array.where (fun i -> i <> "") 
          |> Array.toList 
          |> List.map (fun i -> Bingo.NotMarked(value = int i))
    rawFour.Tail 
        |> List.chunkBySize 6 
        |> List.map (fun i -> i.Tail |> List.map getNums |> List.collect (fun i -> i))
        |> List.map (fun i -> { Bingo.Board.Numbers = i; Bingo.Board.NumRows = 5; Bingo.Board.NumCols =5 })

DayFour.one drawnNumbers boards
DayFour.two drawnNumbers boards

//
// Day Five
//

let rawFive = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayFive.txt") |> readLines
let inpFive = rawFive |> List.map(fun l -> let strP = l.Split([|"->"|], System.StringSplitOptions.None) 
                                           let points = strP |> Array.collect (fun p -> p |> String.splitChar [| ',' |]) 
                                                             |> Array.map (fun p -> int p)
                                           { DayFive.Line.Start = { DayFive.Point.X = points[0]; DayFive.Point.Y = points[1] };
                                             DayFive.Line.End = { DayFive.Point.X = points[2]; DayFive.Point.Y = points[3] }})

DayFive.one inpFive
DayFive.two inpFive

//
// Day Six
//

let rawSix = Path.Combine(__SOURCE_DIRECTORY__, "Input\DaySix.txt") |> readLines
let inpSix = rawSix.Head |> String.splitChar [|','|] |> Array.toList |> List.map int

let map = inpSix |> List.map (fun i -> (i, i)) 
                 |> List.countBy id 
                 |> List.map (fun (k, v) -> k, uint64 v) 
                 |> Map.ofList

DaySix.one map
DaySix.two map

//
// Day Seven
//

let rawSeven = Path.Combine(__SOURCE_DIRECTORY__, "Input\DaySeven.txt") |> readLines
let inpSeven = rawSeven.Head |> String.splitChar [|','|] |> Array.toList |> List.map int

DaySeven.one inpSeven
DaySeven.two inpSeven

//
// Day Eight
//

let rawEight = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayEight.txt") |> readLines
let inpEight = rawEight |> List.map ( fun l -> 
                                        let parts = l |> String.splitChar [|'|'|] 
                                        parts[0].Trim().Split([|' '|]) |> Array.toList, parts[1].Trim().Split([|' '|]) |> Array.toList )

DayEight.one (inpEight |> List.map snd)
DayEight.two inpEight
