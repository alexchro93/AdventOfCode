namespace AdventOfCode

module DaySeven =
    let one inp = 
        let range = [ 0 .. List.max inp ]
        inp |> List.map (fun i -> range |> List.map (fun x -> abs (i - x)))
            |> List.transpose
            |> List.map List.sum
            |> List.sortBy id
            |> List.head

    let two inp = 
        let cost i  = 
            let rec loop x acc = 
                if x > i then acc
                else loop (x + 1) (acc + x)
            loop 1 0
        let range = [ 0 .. List.max inp ]
        inp |> List.map (fun i -> range |> List.map (fun x -> cost (abs (i - x))))
            |> List.transpose
            |> List.map List.sum
            |> List.sortBy id
            |> List.head

(*

Good example from Reddit

open System.IO

let inputPath =
    Path.Combine(__SOURCE_DIRECTORY__, __SOURCE_FILE__.Replace(".fsx", ".txt"))

let input =
    inputPath
    |> File.ReadAllText
    |> fun s -> s.Split(',')
    |> Array.map int

// fuelConsumption is a function that takes two points
// and returns how much fuel is needed to get from one to the other
let minFuel (fuelConsumption: int -> int -> int) =
    [ Array.min input .. Array.max input ]
    |> Seq.map (fun meet -> Array.sumBy (fuelConsumption meet) input)
    |> Seq.min

let distance a b = abs (a - b)
let part1 = minFuel distance

let sumUpTo i = (1 + i) * i / 2
let part2 = minFuel (fun a b -> distance a b |> sumUpTo)

*)