namespace AdventOfCode

module DaySix = 
    let rec loop i acc = 
        if i = 0 then
            acc |> Map.values |> Seq.sum
        else 
            let upd1 = acc |> Map.fold ( fun s (_, c) t -> 
                                            let newK = if c = 0 then (0, 6) else (c, c - 1)
                                            let newV = 
                                                match s |> Map.tryFind newK with 
                                                    | Some(x) -> x + t
                                                    | None -> t
                                            s |> Map.add newK newV ) Map.empty<(int * int), uint64>
            let upd2 = 
                match upd1 |> Map.tryFind (0, 6) with 
                    | Some(x) -> upd1 |> Map.add (8,8) x 
                    | None -> upd1
            loop (i - 1) upd2

    let one inp = loop 80 inp

    let two inp = loop 256 inp