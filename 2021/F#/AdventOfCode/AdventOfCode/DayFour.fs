namespace AdventOfCode

module Bingo =
    type Number =
        | NotMarked of value  : int
        | Marked of value : int

    let marked n = 
        match n with 
            | Marked _ -> true
            | NotMarked _ -> false

    let notMarked n = 
        match n with 
            | Marked _ -> false
            | NotMarked _ -> true

    type Board = 
        { Numbers: Number list; NumRows: int; NumCols: int }

    let tryFindIndex n b =
        b.Numbers |> List.tryFindIndex (fun i -> i = n)

    let replaceAt i n b = 
        { b with Numbers = b.Numbers |> List.updateAt i (Marked(value = n)) }

    let rows b =
        b.Numbers |> List.chunkBySize b.NumRows

    let cols b =
        b |> rows |> List.transpose

    let isBingo (b: Board) : bool = 
        b |> rows |> List.exists (fun i -> i |> List.forall marked) ||
        b |> cols |> List.exists (fun i -> i |> List.forall marked)

    let sumNotMarked b =
        b.Numbers |> List.sumBy (fun i -> match i with 
                                            | Marked _ -> 0
                                            | NotMarked v -> v)

module DayFour =
    let one (nums: int list) (boards: Bingo.Board list) = 
        let rec solve (n: int list) (b: Bingo.Board list) =
            let head = n |> List.head
            let newBoards = b |> List.map (fun i -> 
                                            let idx = i |> Bingo.tryFindIndex (Bingo.NotMarked(value = head))
                                            match idx with 
                                                | Some x -> i |> Bingo.replaceAt x head
                                                | None -> i)
            let bingo = newBoards |> List.where (fun i -> i |> Bingo.isBingo)
            match bingo with 
                | [] -> solve n.Tail newBoards
                | x::xs -> head * (x |> Bingo.sumNotMarked)
        solve nums boards

    let two (nums: int list) (boards: Bingo.Board list) = 
        let rec solve (n: int list) (b: Bingo.Board list) (boardAcc: Bingo.Board list) (numAcc: int)=
            if (n |> List.isEmpty) then
                numAcc * (boardAcc.Head |> Bingo.sumNotMarked)
            else 
                let head = n |> List.head
                let updatedBoards = b |> List.map (fun i -> 
                                                    let idx = i |> Bingo.tryFindIndex (Bingo.NotMarked(value = head))
                                                    match idx with 
                                                        | Some x -> i |> Bingo.replaceAt x head
                                                        | None -> i)
                let bingo = updatedBoards |> List.where (fun i -> i |> Bingo.isBingo)
                let newBoards = updatedBoards |> List.where (fun b -> not (bingo |> List.contains b))
                solve n.Tail newBoards (List.append bingo boardAcc) (if bingo.Length > 0 then head else numAcc)
        solve nums boards [] 0