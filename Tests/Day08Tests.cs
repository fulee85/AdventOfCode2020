using AdventOfCode2020.Common;
using AdventOfCode2020.Day08;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Day08Tests
    {
        [Fact]
        public void PartOneTest()
        {
            ISolver solver = new Solver(
@"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6".Split(Environment.NewLine).Select(s => new Instruction(s)));
            solver.GetFirstSolution().Should().Be("5");
        }

        [Fact]
        public void PartTwoTest()
        {
            ISolver solver = new Solver(
@"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6".Split(Environment.NewLine).Select(s => new Instruction(s)));
            solver.GetSecondSolution().Should().Be("8");
        }
    }
}
