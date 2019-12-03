using System;

namespace AdventOfCode.Exceptions
{
    internal class ProblemNotSolvedException : Exception
    {
       public ProblemNotSolvedException(string message) 
         : base(message) {}
    }
}
