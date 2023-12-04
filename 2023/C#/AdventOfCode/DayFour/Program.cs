var input = File.ReadAllLines("input.txt");
// var input = File.ReadAllLines("test-input.txt");

// Day One

var ansOne = 0;

foreach (var line in input)
{
    var numbers = line.Substring(line.IndexOf(':') + 1)
        .Split('|');
    var winning = numbers[0]
        .Trim([' ', ':'])
        .Split(' ')
        .Where(s => s.Length > 0)
        .Select(s => int.Parse(s.Trim()))
        .ToList();
    var mine = numbers[1]
        .Trim()
        .Split(' ')
        .Where(s => s.Length > 0)
        .Select(s => int.Parse(s.Trim()))
        .ToList();
    var numMatch = winning
        .Intersect(mine)
        .Count();
    if (numMatch > 0) ansOne += (int) Math.Pow(2, numMatch - 1);
}

Console.WriteLine($"Part One: {ansOne}");

// Day Two

var cardCounts = Enumerable.Range(0, input.Length)
    .ToDictionary(i => i, i => 1);

for (var x = 0; x < input.Length; x++)
{
    var line = input[x];
    var numbers = line[(line.IndexOf(':') + 1)..]
        .Split('|');
    var winning = numbers[0]
        .Trim([' ', ':'])
        .Split(' ')
        .Where(s => s.Length > 0)
        .Select(s => int.Parse(s.Trim()))
        .ToList();
    var mine = numbers[1]
        .Trim()
        .Split(' ')
        .Where(s => s.Length > 0)
        .Select(s => int.Parse(s.Trim()))
        .ToList();
    var numMatch = winning
        .Intersect(mine)
        .Count();
    foreach (var i in Enumerable.Range(1, numMatch))
    {
        if (cardCounts.ContainsKey(x + i)) cardCounts[x + i] += 1 * cardCounts[x];
    }
}

var ansTwo = cardCounts.Values.Sum();

Console.WriteLine($"Part Two: {ansTwo}");
