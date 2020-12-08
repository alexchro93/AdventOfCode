//
// Imports
//

#load "DayOne.fs"
#load "DayTwo.fs"
#load "DayThree.fs"
#load "DayFour.fs"
#load "DayFive.fs"
#load "DaySix.fs"
#load "DaySeven.fs"
#load "DayEight.fs"

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

//
// Day Four
//

let comb (map: Map<string, string>) (s: string) : Map<string, string> =
    let inp = 
        s.Split [| ' ' |] 
        |> Array.toList
        |> List.map (fun (x: string) -> x.Split [| ':' |]) 
        |> List.map (fun x -> x.[0], x.[1])
    let rec add (map: Map<string, string>) lst = 
        match lst with
        | [] -> map
        | s::xs -> add (map.Add s) xs
    add map inp

let rawFour = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayFour.txt") |> readLines 
let inpFour = 
    [ let mutable i = 0
      for x in rawFour do
      if x = "" then i <- i + 1 else yield i, x ]
    |> List.groupBy fst
    |> List.map snd
    |> List.map (List.map snd)
    |> List.map (List.fold comb Map.empty<string, string>)

let ansFourOne = DayFour.One inpFour
let ansFourTwo = DayFour.Two inpFour

//
// Day Five
//

let rawFive = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayFive.txt") |> readLines 
let inpFive = rawFive

let ansFiveOne = DayFive.One inpFive
let ansFiveTwo = DayFive.Two inpFive

// 
// Day Six
// 

let rawSix = Path.Combine(__SOURCE_DIRECTORY__, "Input\DaySix.txt") |> readLines 
let inpSix =
    [ let mutable i = 0
      for x in rawSix do
      if x = "" then i <- i + 1 else yield i, x ]
    |> List.groupBy fst
    |> List.map snd
    |> List.map (List.fold (fun acc x -> (snd x)::acc ) [])

let ansSixOne = DaySix.One inpSix
let ansSixTwo = DaySix.Two inpSix

// 
// Day Seven
// 

let crtItem (inp: string) : string * string list =
    let m = Regex.Match(inp, @"^(?<Name>.+ bag)s contain (?<Content>.+)$")
    let name = (m.Groups.Item "Name").Value
    let content = (m.Groups.Item "Content").Value
                    .TrimEnd('.')
                    .Split([| ", " |], System.StringSplitOptions.None)
                    |> Array.toList
    name, content 

let crtCnt (inp: string * string list) : string * Map<string, int> =
    let cnt = (snd inp) |> List.map (fun i -> Regex.Match(i, @"^(?<Amt>\d+) (?<Name>.+[^s])s?$"))
                        |> List.where (fun i -> i.Success)
                        |> List.map (fun i -> (i.Groups.Item "Name").Value, (i.Groups.Item "Amt").Value |> int)
                        |> Map.ofList
    (fst inp), cnt

let rawSeven = Path.Combine(__SOURCE_DIRECTORY__, "Input\DaySeven.txt") |> readLines 
let inpSeven = rawSeven |> List.map crtItem 
                        |> List.map crtCnt
                        |> Map.ofList

let ansSevenOne = DaySeven.One inpSeven "shiny gold bag"
let ansSevenTwo = DaySeven.Two inpSeven "shiny gold bag"

// 
// Day Eight
// 

let rawEight = Path.Combine(__SOURCE_DIRECTORY__, "Input\DayEight.txt") |> readLines 
let inpEight = rawEight 
                |> List.map (fun i -> i.Split(' '))
                |> List.mapi(fun id prts -> { Id = id; Op = prts.[0]; Arg = prts.[1] |> int } : DayEight.Inst )

let ansEightOne = DayEight.One inpEight
let ansEightTwo = DayEight.Two inpEight
