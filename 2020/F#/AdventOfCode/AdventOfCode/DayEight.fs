namespace AdventOfCode.Solutions

module DayEight =
    type Inst  = { Id: int; Op: string; Arg: int }

    let prgUpd inst nInst prg =
        prg |> List.map (fun i -> if i = inst then nInst else i)

    let rec doPrg (acc: int) (pos: int) (seen: Set<Inst>) (insts: Inst list) : bool * int = 
        if pos >= insts.Length then
            true, acc
        else
            match insts.Item pos with 
            | i when (Set.contains i seen) -> false, acc
            | i when i.Op = "acc" -> doPrg (acc + i.Arg) (pos + 1) (Set.add i seen) insts
            | i when i.Op = "jmp" -> doPrg acc (pos + i.Arg) (Set.add i seen) insts
            | i when i.Op = "nop" -> doPrg acc (pos + 1) (Set.add i seen) insts

    let One (prg: Inst list) : int =
        snd (doPrg 0 0 Set.empty prg)

    let Two (prg: Inst list) : int =
        prg |> List.choose (fun inst -> match inst with
                                        | jmp when jmp.Op = "jmp" -> Some(prgUpd jmp { jmp with Op = "nop"} prg)
                                        | nop when nop.Op = "nop" -> Some(prgUpd nop { nop with Op = "jmp"} prg)
                                        | _ -> None)
            |> List.map (fun p -> doPrg 0 0 Set.empty p)
            |> List.choose (fun i -> if fst i then Some(snd i) else None)
            |> List.head
