using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Inputs
    {
       public static int[] GetDayOneInput()
       {
            var inputFilePath = "./input/DayOne.txt";
            var textInp = File.ReadAllLines(inputFilePath);
            return textInp.Select(x => Int32.Parse(x)).ToArray();
       }
    
        public static string[] GetDayTwoInput()
        {
            var inputFilePath = "./input/DayTwo.txt";
            return File.ReadAllLines(inputFilePath);
        }
    }
}