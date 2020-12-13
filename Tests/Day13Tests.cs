namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day13;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Day13Tests
    {
        private readonly List<string> testInput = new List<string>
        {
            "939",
            "7,13,x,x,59,x,31,19"
        };

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput);
            solver.GetFirstSolution().Should().Be("295");
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput);
            solver.GetSecondSolution().Should().Be("1068781");
        }
    }
}
