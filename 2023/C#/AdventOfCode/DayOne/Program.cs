var input = File.ReadAllLines("input.txt");
// var input = File.ReadAllLines("test-input-1.txt");
// var input = File.ReadAllLines("test-input-2.txt");

// Part One

var sum = 0;

foreach (var line in input)
{
    var numbers = line.Where(char.IsDigit)
        .ToArray();
    if (numbers.Length > 0)
    {
        sum += int.Parse($"{numbers[0]}{numbers[^1]}");
    }
}

Console.WriteLine($"Answer One: {sum}");

// Part Two

sum = 0;

var numberVals = new Dictionary<string, int>()
{
    { "one", 1 },
    { "two", 2 },
    { "three", 3 },
    { "four", 4 },
    { "five", 5 },
    { "six", 6 },
    { "seven", 7 },
    { "eight", 8 },
    { "nine", 9 }
};

foreach (var line in input)
{
    var found = new List<int>();
    var partialLine = "";
    foreach (var c in line)
    {
        partialLine += c;
        if (TryGetNumber(partialLine, c, out var number))
        {
            found.Add(number);
        }
    }
    if (found.Count > 0)
    {
        sum += int.Parse($"{found[0]}{found[^1]}");
    }
}

Console.WriteLine($"Answer Two: {sum}");

bool TryGetNumber(string input, char c, out int number)
{
    number = 0;

    if (char.IsDigit(c))
    {
        number = int.Parse(c.ToString());
        return true;
    }
    else if (input.Length >= 3 && numberVals.TryGetValue(input[^3..], out number))
    {
        return true;
    }
    else if (input.Length >= 4 && numberVals.TryGetValue(input[^4..], out number))
    {
        return true;
    }
    else if (input.Length >= 5 && numberVals.TryGetValue(input[^5..], out number))
    {
        return true;
    }

    return false;
}
