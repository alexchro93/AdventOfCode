namespace AdventOfCode

open System

module DayThree = 
    let charToInt (c: char) = int c - int '0'

    let matrix (inp: string list) = inp |> List.map (fun x -> x.ToCharArray() |> Seq.map charToInt |> Seq.toList)

    let transpose (inp: int list list) = inp |> List.transpose

    let column col inp = inp |> List.item col

    let one (inp: string list) =
        inp |> matrix
            |> transpose
            |> List.map (fun l -> if (List.sum l * 2) > List.length l then ("1", "0") else ("0", "1"))
            |> List.fold (fun (gamma, epsilon) (g, e) -> gamma + g, epsilon + e) (String.Empty, String.Empty)
            |> fun (gamma, epsilon) -> Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2)

    let two (inp: string list) =
        let t = inp |> matrix |> transpose

        let oxygen i c = 
            let col = i |> matrix |>transpose |> column c
            let sum = col |> List.sum
            if (sum * 2) >= List.length col then "1" else "0"  

        let co2 i c = 
            let col =  i |> matrix |>transpose |> column c
            let sum = col |> List.sum
            if (sum * 2) >= List.length col then "0" else "1" 

        let rec solve (lst: string list) (x: string) (col: int) (findBit: string list -> int -> string): string =
            match lst with
                | [r] -> r
                | _ -> 
                    let n = x + (findBit lst col)
                    solve (lst |> List.where (fun l -> l.StartsWith(n))) n (col + 1) findBit

        let o = solve inp "" 0 oxygen
        let c = solve inp "" 0 co2

        Convert.ToInt32(o, 2) * Convert.ToInt32(c, 2)
        