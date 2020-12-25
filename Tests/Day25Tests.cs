namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day25;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Day25Tests
    {
        private readonly List<string> testInput1 = new List<string>(
@"5764801
17807724".Split(Environment.NewLine));

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetPartOneSolution().Should().Be("14897079");
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetPartTwoSolution().Should().Be("");
        }
    }
}
