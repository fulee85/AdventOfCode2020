namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day22;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Day22Tests
    {
        private readonly List<string> testInput1 = new List<string>(
@"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10".Split(Environment.NewLine));

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetPartOneSolution().Should().Be("306");
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetPartTwoSolution().Should().Be("291");
        }
    }
}
