var input = File.ReadAllLines("input.txt");
// var input = File.ReadAllLines("test-input.txt");

// Day One

var ansOne = 0;

for (var y = 0; y < input.Length; y++)
{
    var line = input[y];
    var currentNum = string.Empty;
    var isAdjacent = false;

    for (var x = 0; x < line.Length; x++)
    {
        var currentChar = input[y][x];

        if (!char.IsDigit(currentChar))
        {
            if (isAdjacent && currentNum != string.Empty) ansOne += int.Parse(currentNum);

            currentNum = string.Empty;
            isAdjacent = false;
        }
        else
        {
            bool IsSpecial(char c) =>
                !char.IsDigit(c) && c != '.';

            char? left = x - 1 >= 0 ? line[x - 1] : null;
            char? right = x + 1 < line.Length ? line[x + 1] : null;
            char? down = y - 1 >= 0 ? input[y - 1][x] : null;
            char? up = y + 1  < input.Length ? input[y + 1][x] : null;

            char? upRight = x + 1 < line.Length && y + 1 < input.Length ? input[y + 1][x + 1] : null;
            char? downRight = x + 1 < line.Length && y - 1 >= 0 ? input[y - 1][x + 1] : null;
            char? upLeft = x - 1 >= 0 && y + 1 < input.Length ? input[y + 1][x - 1] : null;
            char? downLeft = x - 1 >= 0 && y - 1 >= 0 ? input[y - 1][x - 1] : null;

            isAdjacent |=
                (left.HasValue && IsSpecial(left.Value)) ||
                (right.HasValue && IsSpecial(right.Value)) ||
                (up.HasValue && IsSpecial(up.Value)) ||
                (down.HasValue && IsSpecial(down.Value)) ||
                (upRight.HasValue && IsSpecial(upRight.Value)) ||
                (downRight.HasValue && IsSpecial(downRight.Value)) ||
                (upLeft.HasValue && IsSpecial(upLeft.Value)) ||
                (downLeft.HasValue && IsSpecial(downLeft.Value));

            currentNum += currentChar;
        }
    }

    // Need to check numbers at end of line
    if (isAdjacent && currentNum != string.Empty) ansOne += int.Parse(currentNum);
}

Console.WriteLine($"Part One: {ansOne}");

// Day Two

var allGears = new Dictionary<(int X, int Y), List<int>>();

for (var y = 0; y < input.Length; y++)
{
    var line = input[y];
    var currentNum = string.Empty;
    var isAdjacent = false;
    var gears = new HashSet<(int X, int Y)>();

    for (var x = 0; x < line.Length; x++)
    {
        var currentChar = input[y][x];

        if (!char.IsDigit(currentChar))
        {
            if (isAdjacent && currentNum != string.Empty)
            {
                foreach (var g in gears)
                {
                    if (allGears.TryGetValue(g, out var list))
                    {
                        list.Add(int.Parse(currentNum));
                    }
                    else
                    {
                        allGears.Add(g, [ int.Parse(currentNum) ]);
                    }
                }
            }

            currentNum = string.Empty;
            isAdjacent = false;
            gears = [];
        }
        else
        {
            bool IsSpecial(char c) =>
                c == '*';

            var initialLength = gears.Count;

            if (x - 1 >= 0 && IsSpecial(line[x - 1])) gears.Add((x - 1, y));
            if (x + 1 < line.Length && IsSpecial(line[x + 1])) gears.Add((x + 1, y));
            if (y - 1 >= 0 && IsSpecial(input[y - 1][x])) gears.Add((x, y - 1));
            if (y + 1  < input.Length && IsSpecial(input[y + 1][x])) gears.Add((x, y + 1));
            if (x + 1 < line.Length && y + 1 < input.Length && IsSpecial(input[y + 1][x + 1])) gears.Add((x + 1, y + 1));
            if (x + 1 < line.Length && y - 1 >= 0 && IsSpecial(input[y - 1][x + 1])) gears.Add((x + 1, y - 1));
            if (x - 1 >= 0 && y + 1 < input.Length && IsSpecial(input[y + 1][x - 1])) gears.Add((x - 1, y + 1));
            if (x - 1 >= 0 && y - 1 >= 0 && IsSpecial(input[y - 1][x - 1])) gears.Add((x - 1, y - 1));

            currentNum += currentChar;
            isAdjacent |= gears.Count > initialLength;
        }
    }

    // Need to check numbers at end of line
    if (isAdjacent && currentNum != string.Empty)
    {
        foreach (var g in gears)
        {
            if (allGears.TryGetValue(g, out var list))
            {
                list.Add(int.Parse(currentNum));
            }
            else
            {
                allGears.Add(g, new List<int> { int.Parse(currentNum) });
            }
        }
    }
}

var ansTwo = allGears
    .Where(x => x.Value.Count == 2)
    .Sum(x => x.Value[0] * x.Value[1]);

Console.WriteLine($"Part Two: {ansTwo}");
