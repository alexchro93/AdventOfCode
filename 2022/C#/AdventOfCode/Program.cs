/*
 *  Day One
 */

using AdventOfCode;

var rawOne = File.ReadAllLines("Input/DayOne.txt");
var inpOne = rawOne.Select(i => int.TryParse(i, out var res) ? res : int.MinValue).ToList();

var ansOneOne = DayOne.One(inpOne);
var ansOneTwo = DayOne.Two(inpOne);

Console.WriteLine($"Day One One: {ansOneOne}");
Console.WriteLine($"Day One Two: {ansOneTwo}");

/*
 * Day Two
 */

static Hand GetHand(string s) => s switch
{
    "A" => Hand.Rock,
    "B" => Hand.Paper,
    "C" => Hand.Scissors,
    "X" => Hand.Rock,
    "Y" => Hand.Paper,
    "Z" => Hand.Scissors
};

var rawTwo = File.ReadAllLines("Input/DayTwo.txt");
var inpTwo = rawTwo
    .Select(i =>
        {
            var line = i.Split(" ");
            return (GetHand(line[0]), GetHand(line[1]));
        })
    .ToList();

var ansTwoOne = DayTwo.One(inpTwo);
var ansTwoTwo = DayTwo.Two(inpTwo);

Console.WriteLine($"Day Two One: {ansTwoOne}");
Console.WriteLine($"Day Two Two: {ansTwoTwo}");

/*
 * Day Three
 */

var rawThree = File.ReadAllLines("Input/DayThree.txt");

var ansThreeOne = DayThree.One(rawThree);
var ansThreeTwo = DayThree.Two(rawThree);

Console.WriteLine($"Day Three One: {ansThreeOne}");
Console.WriteLine($"Day Three Two: {ansThreeTwo}");

/*
 * Day Four
 */

var rawFour = File.ReadAllLines("Input/DayFour.txt");
var inpFour = rawFour.Select(i =>
{
    var x = i.Split(",");
    var one = x[0].Split("-");
    var two = x[1].Split("-");

    return ((int.Parse(one[0]), int.Parse(one[1])), (int.Parse(two[0]), int.Parse(two[1])));

})
.ToList();

var ansFourOne = DayFour.One(inpFour);
var ansFourTwo = DayFour.Two(inpFour);

Console.WriteLine($"Day Four One: {ansFourOne}");
Console.WriteLine($"Day Four Two: {ansFourTwo}");

/*
 * Day Five - Get Input
 */

var rawFiveA = File.ReadAllLines("Input/DayFive-A.txt");
var temp = Enumerable.Range(0, 10).Select(_ => new List<char>()).ToList();
foreach (var line in rawFiveA)
{
    var chunks = line.Chunk(4).ToArray();
    for (var i = 0; i < chunks.Length; i++)
    {
        if (chunks[i][1] == ' ') continue;
        temp[i + 1].Insert(0, chunks[i][1]);
    }
}

var stacksOne = temp.Select(i => new Stack<char>(i)).ToList();
var stacksTwo = temp.Select(i => new Stack<char>(i)).ToList();

/*
 * Day Five - Find Answers
 */

var rawFiveB = File.ReadAllLines("Input/DayFive-B.txt").ToList();

var ansFiveOne = DayFive.One(stacksOne, rawFiveB);
var ansFiveTwo = DayFive.Two(stacksTwo, rawFiveB);

Console.WriteLine($"Day Five One: {ansFiveOne}");
Console.WriteLine($"Day Five Two: {ansFiveTwo}");

/*
 * Day Dix
 */

var rawSix = File.ReadAllLines("Input/DaySix.Txt").First();

var ansSixOne = DaySix.One(rawSix);
var ansSixTwo = DaySix.Two(rawSix);

Console.WriteLine($"Day Six One: {ansSixOne}");
Console.WriteLine($"Day Six Two: {ansSixTwo}");

/*
 * Day Seven
 */

var rawSeven = File.ReadAllLines("Input/DaySeven.txt").ToList();

var ansSevenOne = DaySeven.One(rawSeven);
var ansSevenTwo = DaySeven.Two(rawSeven);

Console.WriteLine($"Day Seven One: {ansSevenOne}");
Console.WriteLine($"Day Seven Two: {ansSevenTwo}");

/*
 * Day Ten
 */

var rawTen = File.ReadAllLines("Input/DayTen.txt").ToList();

var ansTenOne = DayTen.One(rawTen);
var ansTenTwo = DayTen.Two(rawTen);

Console.WriteLine($"Day Ten One: {ansTenOne}");
Console.WriteLine($"Day Ten Two: {ansTenTwo.Length}");
for (var i = 0; i < 6; i++)
{
   Console.WriteLine($"{ansTenTwo.Substring(i * 40, 40)}");
}

/*
 * Day Eleven
 */

var rawEleven = File.ReadAllLines("Input/DayEleven.txt")
   .ToList();
var inpElevenOne = rawEleven.Chunk(7)
   .Select(c => new Monkey(c))
   .ToList();
var inpElevenTwo = rawEleven.Chunk(7)
   .Select(c => new Monkey(c))
   .ToList();

var ansElevenOne = DayEleven.One(inpElevenOne);
var ansElevenTwo = DayEleven.Two(inpElevenTwo);

Console.WriteLine($"Day Eleven One: {ansElevenOne}");
Console.WriteLine($"Day Eleven Two: {ansElevenTwo}");
