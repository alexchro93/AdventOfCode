namespace AdventOfCode.Solutions

#nowarn "25"

module DayFive = 
    let seatId (x: string) =
        let rec calcId chars row col =
            match chars with
            | [] -> (row * 8) + col
            | c::cs when c = 'F' -> calcId cs (row <<< 1) col
            | c::cs when c = 'B' -> calcId cs ((row <<< 1) ||| 1) col
            | c::cs when c = 'L' -> calcId cs row (col <<< 1)
            | c::cs when c = 'R' -> calcId cs row ((col <<< 1) ||| 1)
        calcId (Seq.toList x) 0 0

    let One x = x |> List.map seatId |> List.max

    let Two x = 
        let rec findId ids max = 
            match ids with 
            | c::cs when c = max -> -1
            | c::cs when cs.Head - c = 2 -> c + 1
            | c::cs -> findId cs max

        let ids = x |> List.map seatId |> List.sort
        let max = ids |> List.last

        findId ids max


