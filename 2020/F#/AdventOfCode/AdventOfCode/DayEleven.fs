namespace AdventOfCode.Solutions

///
/// The code takes a while to run, but it works. 
/// I really wanted to switch to C# today.
/// I may have gone overboard with the types and immutability.
///

module DayEleven =
    type Seat = 
        | Floor
        | Empty
        | Occupied
        | Unknown 

    module Seat = 
        let create x = 
            match x with 
            | s when s = '.' -> Floor
            | s when s = 'L' -> Empty
            | s when s = '#' -> Occupied
            | _ -> Unknown

    type Loc =  { Row: int; Col: int }

    type SeatMap = 
        { Seats: Map<Loc, Seat> 
          NumRow: int
          NumCol: int }

    module SeatMap = 
        let empty numRow numCol = 
            let seats = Map.ofSeq [ for i = 0 to (numRow - 1) do
                                    for j = 0 to (numCol - 1) do
                                    yield { Row = i; Col = j }, Empty ] 
            { Seats = seats; NumRow = numRow; NumCol = numCol }

        let create x =
            let numRow = Array.length x
            let numCol = Array.length x.[0]
            let seats = Map.ofSeq [ for i = 0 to (numRow - 1) do
                                    for j = 0 to (numCol - 1) do
                                    yield { Row = i; Col = j }, Seat.create x.[i].[j] ] 
            { Seats = seats; NumRow = numRow; NumCol = numCol }

        let equals map1 map2 =
            Map.forall (fun i s -> s = (Map.find i map2.Seats)) map1.Seats

        let countOccupied map =
            map.Seats |> Map.filter (fun i s -> s = Occupied) |> Map.count

        let valid loc map =
            (loc.Row >= 0 && loc.Row < map.NumRow) &&
            (loc.Col >= 0 && loc.Col < map.NumCol)

        let getSeat map loc =
            if not (valid loc map) then None
            else Some(Map.find loc map.Seats)

        let occupiedFst updLoc loc map =
            let rec findSeats curr =
                match (getSeat map curr) with
                | Some x when x = Floor -> findSeats (updLoc curr)
                | Some x when x = Occupied -> true
                | _ -> false
            findSeats (updLoc loc)

        let diagOccupied loc map =
            [ occupiedFst (fun l -> { l with Row = l.Row + 1 }) loc map;
              occupiedFst (fun l -> { l with Row = l.Row - 1 }) loc map;
              occupiedFst (fun l -> { l with Col = l.Col + 1 }) loc map;
              occupiedFst (fun l -> { l with Col = l.Col - 1 }) loc map;
              occupiedFst (fun l -> { l with Row = l.Row + 1; Col = l.Col + 1 }) loc map;
              occupiedFst (fun l -> { l with Row = l.Row - 1; Col = l.Col + 1 }) loc map;
              occupiedFst (fun l -> { l with Row = l.Row + 1; Col = l.Col - 1 }) loc map;
              occupiedFst (fun l -> { l with Row = l.Row - 1; Col = l.Col - 1 }) loc map; ]
            |> Seq.where (fun s -> s)
            |> Seq.length

        let adjOccupied loc map =
            [ { loc with Row = loc.Row + 1 } 
              { loc with Row = loc.Row - 1 } 
              { loc with Col = loc.Col + 1 } 
              { loc with Col = loc.Col - 1 } 
              { loc with Row = loc.Row + 1; Col = loc.Col + 1 } 
              { loc with Row = loc.Row - 1; Col = loc.Col + 1 } 
              { loc with Row = loc.Row + 1; Col = loc.Col - 1 } 
              { loc with Row = loc.Row - 1; Col = loc.Col - 1 } ] 
            |> Seq.choose (getSeat map)
            |> Seq.where (fun s -> s = Occupied)
            |> Seq.length

        let locations map = map.Seats |> Map.toList

        let updateOne map =
            let rec update curr prev = 
                match prev with
                | [] -> curr
                | (loc, s)::xs when s = Occupied && (adjOccupied loc map) >= 4 -> update ((loc, Empty) :: curr) xs
                | (loc, s)::xs when s = Empty && (adjOccupied loc map) = 0 -> update ((loc, Occupied) :: curr) xs
                | x::xs -> update (x :: curr) xs
            { map with Seats = update List.empty (locations map) |> Map.ofList }

        let updateTwo map =
            let rec update curr prev = 
                match prev with
                | [] -> curr
                | (loc, s)::xs when s = Occupied && (diagOccupied loc map) >= 5 -> update ((loc, Empty) :: curr) xs
                | (loc, s)::xs when s = Empty && (diagOccupied loc map) = 0 -> update ((loc, Occupied) :: curr) xs
                | x::xs -> update (x :: curr) xs
            { map with Seats = update List.empty (locations map) |> Map.ofList }
         
    let One seats =
        let rec run p c =
            match (SeatMap.equals p c) with
            | true -> SeatMap.countOccupied c
            | false -> run c (SeatMap.updateOne c)
        run (SeatMap.empty seats.NumRow seats.NumCol) seats

    let Two seats =
        let rec run p c =
            match (SeatMap.equals p c) with
            | true -> SeatMap.countOccupied c
            | false -> run c (SeatMap.updateTwo c)
        run (SeatMap.empty seats.NumRow seats.NumCol) seats

