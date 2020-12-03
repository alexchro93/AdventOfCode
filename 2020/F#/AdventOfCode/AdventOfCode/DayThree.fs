namespace AdventOfCode.Solutions

open System.Linq;

module DayThree =
    type Slope = 
        { Right: int;
          Down: int }

    let One (lines: string list) (slope: Slope) : uint =
        let choose (row: int) (line: string) : unit option =
            if row <> 0 && row % slope.Down = 0 then
                let col = (row / slope.Down * slope.Right) % line.Count()
                if line.Chars col = '#' then Some(()) else None
            else
                None

        lines |> List.mapi choose
              |> List.choose id
              |> List.length
              |> uint

    let Two (lines: string list) (slopes: Slope list) : uint = 
        let trees = slopes |> List.map (fun s -> One lines s)
        trees |> List.fold (fun acc c -> acc * c) 1u

