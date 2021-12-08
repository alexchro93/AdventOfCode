namespace AdventOfCode

module DayTwo =
    let one (inp: (string * int) list) : int =
        let rec solve cmds h d =
            match cmds with
            | (c, v)::xs when c = "forward" -> solve xs (h + v) d
            | (c, v)::xs when c = "down" -> solve xs h (d + v)
            | (c, v)::xs when c = "up" -> solve xs h (d - v)
            | _ -> h * d
        solve inp 0 0

    let two (inp: (string * int) list) : int =
        let rec solve cmds h d a =
            match cmds with
            | (c, v)::xs when c = "forward" -> solve xs (h + v) (d + a * v) a
            | (c, v)::xs when c = "down" -> solve xs h d (a + v)
            | (c, v)::xs when c = "up" -> solve xs h d (a - v)
            | _ -> h * d
        solve inp 0 0 0


            
