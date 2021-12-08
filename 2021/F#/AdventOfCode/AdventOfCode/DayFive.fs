namespace AdventOfCode

module DayFive = 
    type Point = 
        { X: int; Y: int }

    type Line = 
        { Start: Point; End: Point }

    let slope l = 
        (l.End.Y - l.Start.Y) / (l.End.X - l.Start.X)

    let intercept l s = 
        l.Start.Y - s * l.Start.X
        
    let vertical l =
        l.Start.X = l.End.X

    let horizontal l =
        l.Start.Y = l.End.Y

    let fix l = 
        if (vertical l && l.End.Y < l.Start.Y) || ( l.End.X < l.Start.X ) then
            { l with Start = l.End; End = l.Start }
        else 
            l
            
    let points l = 
        let adj = 
            if vertical l then 
                (fun p -> { p with Y = p.Y + 1 })
            else if horizontal l then
                (fun p -> { p with X = p.X + 1 })
            else 
                let s = slope l
                let i = intercept l s
                (fun p -> { p with X = p.X + 1; Y = s * (p.X + 1) + i})
            
        let rec loop p acc=
            if p = l.End then
                p::acc
            else 
                loop (adj p) (p::acc)

        loop l.Start []

    let one (inp: Line list) =
        inp |> List.where (fun l -> l |> vertical || l |> horizontal)
            |> List.map fix
            |> List.collect (fun l -> l |> points)
            |> List.countBy id
            |> List.where (fun (_, c) -> c >= 2)
            |> List.length

    let two (inp: Line list) =
        inp |> List.map fix
            |> List.collect (fun l -> l |> points)
            |> List.countBy id
            |> List.where (fun (_, c) -> c >= 2)
            |> List.length
        