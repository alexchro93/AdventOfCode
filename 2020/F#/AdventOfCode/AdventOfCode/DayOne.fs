namespace AdventOfCode.Solutions

module DayOne = 
    let One (x: int list) : int =
        let res = [ for i in x do
                    for j in x do
                    if i + j = 2020 then i * j]
        res.Head

    let Two (x: int list) : int =
        let res = [ for i in x do
                    for j in x do
                    for z in x do
                    if i + j + z = 2020 then i * j * z ]
        res.Head

