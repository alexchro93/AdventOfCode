namespace AdventOfCode.Solutions

open System.Linq

module DayTwo = 
    type Line = 
        {   Min: int;
            Max: int;
            Chr: char;
            Psd: string }

    let One (x: Line list) : int =
        let validLine (line: Line) : bool =
            let cnt = line.Psd.Count(fun c -> c = line.Chr)
            cnt >= line.Min && cnt <= line.Max
        
        x |> List.filter validLine |> List.length

    let Two (x: Line list) : int =
        let validLine (line: Line) : bool = 
            let first = (line.Psd.Chars (line.Min - 1)) = line.Chr
            let second = (line.Psd.Chars (line.Max - 1)) = line.Chr 

            if (first && second) then false
            elif (first || second) then true
            else false

        x |> List.filter validLine |> List.length
            
