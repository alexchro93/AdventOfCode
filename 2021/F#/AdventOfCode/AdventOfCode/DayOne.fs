namespace AdventOfCode

module DayOne = 
    let one (x: int list) : int = 
        let rec cnt lst pre acc = 
            match lst with
                | x::xs when x > pre -> cnt xs x acc + 1
                | x::xs when x <= pre -> cnt xs x acc
                | _ -> acc
        cnt x (List.head x) 0

    let two (x: int list) : int =
        x |> List.windowed 3 |> List.map (fun x -> List.sum x) |> one