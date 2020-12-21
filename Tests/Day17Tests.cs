namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day17;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Day17Tests
    {
        private readonly List<string> testInput = new List<string>
        {
            ".#.",
            "..#",
            "###",
        };

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput);
            solver.GetPartOneSolution().Should().Be("112");
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput);
            solver.GetPartTwoSolution().Should().Be("848");
        }
    }
}
