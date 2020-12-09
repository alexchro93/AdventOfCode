namespace AdventOfCode.Solutions

module DayNine = 
    let makeSums (nums: uint64 list) =
        [ for i in nums  do
          for j in nums  do
          if i <> j then yield i + j ] |> List.distinct
                                       

    let produceRange (nums: uint64 list) (start: int) =
        if start + 1 >= nums.Length then
            List.empty
        else 
            [ for i in [start + 1 .. nums.Length - 1] do
              yield nums.[start .. i] ]

    let One (inp: uint64 list) (window: int) : uint64 =
        let contains i = 
            let sums = inp.[i - window .. i - 1] |> makeSums
            if sums |> List.contains inp.[i] then None else Some(inp.[i])
        let range = [window .. inp.Length - 1]
        range |> List.choose contains |> List.head
           

    let Two (inp: uint64 list) (window: int) : uint64 =
        let num = One inp window
        let rng = [0 .. inp.Length - 1] |> List.collect (fun i -> produceRange inp i)
                                        |> List.where (fun x -> (x |> List.sum) = num)
                                        |> List.head
        (rng |> List.max) + (rng |> List.min)

