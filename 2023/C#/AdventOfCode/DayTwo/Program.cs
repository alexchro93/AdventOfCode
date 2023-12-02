var input = File.ReadAllLines("input.txt");
// var input = File.ReadAllLines("test-input-1.txt");
// var input = File.ReadAllLines("test-input-2.txt");

// Part One

var maxValues = new Dictionary<string, int>
{
    { "blue", 14 },
    { "red", 12 },
    { "green", 13 }
};

var sum = 0;

foreach (var (line, game) in input.Select((l, i) => (l, i + 1)))
{
    var sets = line.Substring(startIndex: line.IndexOf(value: ':') + 1)
        .Split(";")
        .ToList();

    var possible = true;

    foreach (var s in sets)
    {
        if (!possible) continue;

        var cubes = s
            .TrimStart(' ')
            .Split(',')
            .Select(x =>
            {
                var vals = x.TrimStart(' ').Split(' ');
                return (int.Parse(vals[0]), vals[1]);
            })
            .ToList();

        foreach (var c in cubes)
        {
            if (maxValues.TryGetValue(c.Item2, out var maxVal) &&
                c.Item1 > maxVal)
            {
                possible = false;
            }
        }
    }

    if (possible) sum += game;
}

Console.WriteLine($"Part One: {sum}");

// Day Two

sum = 0;

foreach (var (line, game) in input.Select((l, i) => (l, i + 1)))
{
    var sets = line.Substring(startIndex: line.IndexOf(value: ':') + 1)
        .Split(";")
        .ToList();

    var minBlue = 0;
    var minGreen = 0;
    var minRed = 0;

    foreach (var s in sets)
    {
        var cubes = s
            .TrimStart(' ')
            .Split(',')
            .Select(x =>
            {
                var vals = x.TrimStart(' ').Split(' ');
                return (Number: int.Parse(vals[0]), Color: vals[1]);
            })
            .ToList();

        foreach (var c in cubes)
        {
            if (c.Color == "green") minGreen = minGreen <= 0 ? c.Number : Math.Max(minGreen, c.Number);
            if (c.Color == "red") minRed = minRed <= 0 ? c.Number : Math.Max(minRed, c.Number);
            if (c.Color == "blue") minBlue = minBlue <= 0 ? c.Number : Math.Max(minBlue, c.Number);
        }
    }
    
    sum += minBlue * minRed * minGreen;
}

Console.WriteLine($"Part Two: {sum}");
