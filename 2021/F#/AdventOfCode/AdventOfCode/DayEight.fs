namespace AdventOfCode

open System.Linq

module DayEight =
    let lengthsOne = dict [(2, 1); (3, 7); (4, 4); (7, 8)]

    let one (inp: string list list) =
        inp |> List.collect (fun l -> l |> List.map (fun x -> x.Length))
            |> List.where (fun i -> lengthsOne.ContainsKey i)
            |> List.length

    // I was on the right track to a solution, but ended up taking something from Reddit
    // https://www.reddit.com/r/adventofcode/comments/rbj87a/comment/hnoyy04/?utm_source=share&utm_medium=web2x&context=3
    let two (inp: (string list * string list) list) = 
        let solveEntry (p, o) = 
            let l = seq { for x in p -> String.length x, x } |> Map.ofSeq
            let mutable ret = ""
            for x in o do
                match String.length x, Seq.length (l[4].Intersect(x)), Seq.length (l[2].Intersect(x)) with
                    | (2, _, _) -> ret <- ret + "1"
                    | (3, _, _) -> ret <- ret + "7"
                    | (4, _, _) -> ret <- ret + "4"
                    | (7, _, _) -> ret <- ret + "8"
                    | (5, 2, _) -> ret <- ret + "2"
                    | (5, 3, 1) -> ret <- ret + "5"
                    | (5, 3, 2) -> ret <- ret + "3"
                    | (6, 4, _) -> ret <- ret + "9"
                    | (6, 3, 1) -> ret <- ret + "6"
                    | (6, 3, 2) -> ret <- ret + "0"
                    | _ -> ()
            int ret
        inp |> List.map solveEntry |> List.sum
