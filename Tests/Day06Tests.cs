using AdventOfCode2020.Common;
using AdventOfCode2020.Day06;
using FluentAssertions;
using System;
using Xunit;

namespace Tests
{
    public class Day06Tests
    {
        [Fact]
        public void SolverTest1()
        {
            ISolver solver = new Solver(
@"abc

a
b
c

ab
ac

a
a
a
a

b".Split(Environment.NewLine));
            solver.GetPartOneSolution().Should().Be("11");
        }

        [Fact]
        public void SolverTest2()
        {
            ISolver solver = new Solver(
@"abc

a
b
c

ab
ac

a
a
a
a

b".Split(Environment.NewLine));
            solver.GetPartTwoSolution().Should().Be("6");
        }
    }
}
