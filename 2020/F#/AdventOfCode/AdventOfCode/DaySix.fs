namespace AdventOfCode.Solutions

open System.Linq

module DaySix =
    let One (x: string list list) : int =
        x |> List.map (List.fold (+) "")
          |> List.map (fun e -> e.Distinct()) 
          |> List.map (fun e -> e.Count())
          |> List.sum

    let Two (x: string list list) : int =
        x |> List.map (List.reduce (fun acc e -> System.String.Concat(e.Intersect(acc))))
          |> List.map (fun e -> e.Count())
          |> List.sum
        
