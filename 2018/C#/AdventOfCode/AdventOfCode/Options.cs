using CommandLine;

namespace AdventOfCode
{
    public class Options
    {
        [Option('d', "day", Required = true, HelpText = "Day for which problem should be solved. [1 - 25]")]
        public Day Day { get; set; }
        
        [Option('p', "problem", Required = true, HelpText = "Problem that should be solved. [1, 2]")]
        public Problem Problem { get; set; }
    }
}