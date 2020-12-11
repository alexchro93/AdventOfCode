namespace AdventOfCode.Solutions

/// Shout-out to https://www.reddit.com/r/adventofcode/comments/kacdbl/2020_day_10c_part_2_no_clue_how_to_begin/
/// for really helping me understand this problem. 

#nowarn "25"

module DayTen =
    let One jolts =
        let rec findDiff j (one, two, three) = 
            match j with 
            | [] | [_] -> (one, two, three)
            | x::xs when xs.Head - x = 1 -> findDiff xs (one + 1, two, three)
            | x::xs when xs.Head - x = 2 -> findDiff xs (one, two + 1, three)
            | x::xs when xs.Head - x = 3 -> findDiff xs (one, two, three + 1)

        let joltsS = 0 :: jolts |> List.sortDescending
        let joltsF = (joltsS.Head + 3) :: joltsS |> List.rev
        let (one, _, three) = findDiff joltsF (0,0,0)

        one * three

    let Two jolts = 
        let joltsS =  0 :: jolts |> List.sortDescending
        let joltsF = (joltsS.Head + 3) :: joltsS 
                        |> List.rev 
                        |> List.mapi (fun i e -> if i = 0 then (e, 1UL) else (e, 0UL))
                        |> Array.ofList
        let max = joltsF.Length - 1

        for i in 0 .. max do
            let (item, paths) = joltsF.[i]

            if (i + 1 <= max) then
                let (o, p) = joltsF.[i+1]
                if (o - item <= 3) 
                    then joltsF.[i+1] <- (o, p + paths)
                
            if (i + 2 <= max) then
                let (o, p) = joltsF.[i+2]
                if (o - item <= 3) then 
                    joltsF.[i+2] <- (o, p + paths)

            if (i + 3 <= max) then
                let (o, p) = joltsF.[i+3]
                if (o - item <= 3) then 
                    joltsF.[i+3] <- (o, p + paths)

        snd joltsF.[max]
