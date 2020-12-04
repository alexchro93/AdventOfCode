namespace AdventOfCode.Solutions

open System.Text.RegularExpressions;

module DayFour =
    let reqFields = ["byr"; "iyr"; "eyr"; "hgt"; "hcl"; "ecl"; "pid"]

    let reqEcl = ["amb"; "blu"; "brn"; "gry"; "grn"; "hzl"; "oth"]

    let getKeys (map: Map<'a,'b>) = 
        map |> Map.toList |> List.map fst

    let validYear s l u =
        let m = Regex.Match(s, @"\d{4}")
        match m.Success with
        | false -> false
        | true -> match (m.Value |> int) with
                  | x when x >= l && x <= u -> true
                  | _ -> false

    let validByr byr = validYear byr 1920 2002 

    let validIyr iyr = validYear iyr 2010 2020

    let validEyr eyr = validYear eyr 2020 2030

    let validHgt hgt = 
        let m = Regex.Match(hgt, @"(?<H>\d+)(?<U>\w+)")
        if m.Success then
            let h = (m.Groups.Item "H").Value |> int
            let u = (m.Groups.Item "U").Value
            match (h, u) with
            | (cms, "cm") -> cms >= 150 && cms <= 193
            | (ins, "in") -> ins >= 59 && ins <= 76
            | _ -> false
        else
            false

    let validHcl hcl =
        Regex.Match(hcl, @"^#[0-9a-f]{6}$").Success

    let validEcl ecl = 
        List.contains ecl reqEcl

    let validPid pid =
        Regex.Match(pid, @"^\d{9}$").Success

    let validFieldCnt (map: Map<string, string>) =
        (reqFields |> List.except (map |> getKeys)).Length = 0

    let validFieldVal (map: Map<string, string>) =
        let validKey key = 
            match key with
            | "byr" -> validByr (map.Item "byr")
            | "iyr" -> validIyr (map.Item "iyr")
            | "eyr" -> validEyr (map.Item "eyr")
            | "hgt" -> validHgt (map.Item "hgt")
            | "hcl" -> validHcl (map.Item "hcl")
            | "ecl" -> validEcl (map.Item "ecl")
            | "pid" -> validPid (map.Item "pid")
            | _ -> true
        map |> getKeys |> List.map validKey |> List.fold  (fun acc x -> x && acc) true

    let One (inp: Map<string, string> list) = 
        inp |> List.filter validFieldCnt |> List.length

    let Two (inp: Map<string, string> list) = 
        inp |> List.filter validFieldCnt |> List.filter validFieldVal |> List.length

