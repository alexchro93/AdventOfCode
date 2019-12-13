using System;
using System.Collections.Generic;
using AdventOfCode.Exceptions;

namespace AdventOfCode.Intcode
{
    /// <summary>
    /// Borrowed from https://github.com/encse/adventofcode/blob/master/2019/Day09/Solution.cs
    /// </summary>
    public class RelativeComputer
    {
        private readonly int[] _modeMask = { 0, 100, 1000, 10000 };
        private readonly long[] _mem;
        private long _ip;
        private long _r;

        public RelativeComputer(long[] intcode, params int[] initialInp)
        {
            _mem = new long[1024 * 1024];
            Array.Copy(intcode, _mem, intcode.Length);
            foreach (var i in initialInp)
                Input.Enqueue(i);
        }

        private enum Opcode
        {
            Add = 1,
            Mul = 2,
            In = 3,
            Out = 4,
            Jnz = 5,
            Jz = 6,
            Lt = 7,
            Eq = 8,
            StR = 9,
            Hlt = 99,
        }

        public Queue<long> Input { get; } = new Queue<long>();
        public Queue<long> Output { get; } = new Queue<long>();

        public bool DoNext()
        {
            long Addr(int i)
            {
                var mode = _mem[_ip] / _modeMask[i] % 10;
                return mode switch
                {
                    0 => _mem[_ip + i],
                    1 => _ip + i,
                    2 => _r + _mem[_ip + i],
                    _ => throw new ArgumentException()
                };
            }
            long Arg(int i) => _mem[Addr(i)];

            var opcode = (Opcode)(_mem[_ip] % 100);

            switch (opcode)
            {
                case Opcode.Add: _mem[Addr(3)] = Arg(1) + Arg(2); _ip += 4; break;
                case Opcode.Mul: _mem[Addr(3)] = Arg(1) * Arg(2); _ip += 4; break;
                case Opcode.In:
                    if (Input.TryDequeue(out var inp))
                    {
                        _mem[Addr(1)] = inp; _ip += 2;
                    }
                    break;
                case Opcode.Out: Output.Enqueue(Arg(1)); _ip += 2; break;
                case Opcode.Jnz: _ip = Arg(1) != 0 ? Arg(2) : _ip + 3; break;
                case Opcode.Jz: _ip = Arg(1) == 0 ? Arg(2) : _ip + 3; break;
                case Opcode.Lt: _mem[Addr(3)] = Arg(1) < Arg(2) ? 1 : 0; _ip += 4; break;
                case Opcode.Eq: _mem[Addr(3)] = Arg(1) == Arg(2) ? 1 : 0; _ip += 4; break;
                case Opcode.StR: _r += Arg(1); _ip += 2; break;
                case Opcode.Hlt: return false;
                default: throw new ProblemNotSolvedException("invalid opcode");
            }

            return true;
        }
    }
}
