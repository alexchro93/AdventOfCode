/*
 *  Day One
 */

using AdventOfCode;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

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
 * Day Eight
 */

var rawEight = File.ReadAllLines("Input/DayEight.txt");
var inpEight = rawEight.Select(l => l.Select(c => c - '0').ToList()).ToList();

var ansEightOne = DayEight.One(inpEight);
var ansEightTwo = DayEight.Two(inpEight);

Console.WriteLine($"Day Eight One: {ansEightOne}");
Console.WriteLine($"Day Eight Two: {ansEightTwo}");

/*
 * Day Nine
 */

var rawNine = File.ReadAllLines("Input/DayNine.txt");
var inpNine = rawNine.Select(l =>
{
    var parts = l.Split(" ");
    return (l[0], int.Parse(parts[1]));
})
.ToList();

var ansNineOne = DayNine.One(inpNine);
var ansNineTwo = DayNine.Two(inpNine);

Console.WriteLine($"Day Nine One: {ansNineOne}");
Console.WriteLine($"Day Nine Two: {ansNineTwo}");

/*
 * Day Twelve
 */

var rawTwelve = File.ReadAllLines("Input/DayTwelve.txt");
var inpTwelve = rawTwelve
    .Select(i => i.ToList())
    .ToList();

var ansTwelveOne = DayTwelve.One(inpTwelve);
var ansTwelveTwo = DayTwelve.Two(inpTwelve);

Console.WriteLine($"Day Twelve One: {ansTwelveOne}");
Console.WriteLine($"Day Twelve Two: {ansTwelveTwo}");
