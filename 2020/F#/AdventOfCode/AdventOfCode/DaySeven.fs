namespace AdventOfCode.Solutions

module DaySeven =
    let One (inp: Map<string, Map<string, int>>) (name: string) : int =
        let rec containsName (content: Map<string, int>) : bool =
            match content.IsEmpty with
            | true -> false
            | false -> match content.ContainsKey name with
                       | true -> true
                       | false -> content |> Map.filter (fun n _ -> containsName (inp.Item n)) |> Map.count > 0
        inp |> Map.filter (fun _ c -> containsName c) |> Map.count 

    let Two (inp: Map<string, Map<string, int>>) (name: string) : int =
        let rec countBags (content: Map<string, int>) : int =
            match content.IsEmpty with
            | true -> 0
            | false -> content |> Map.toList |> List.map (fun (n, i) -> i + (i * (countBags (inp.Item n)))) |> List.sum
        (inp.Item name) |> countBags

