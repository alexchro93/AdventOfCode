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
            
            return textInp.Select(x => { 
                var sign = x[0];
                if (sign == '+')
                {
                    return Int32.Parse(x.Substring(1));
                } 
                else if (sign == '-') 
                {
                    return Int32.Parse(x.Substring(1)) * -1;
                }
                else 
                {
                    throw new ArgumentException();
                }
             }).ToArray();
       }
    }
}