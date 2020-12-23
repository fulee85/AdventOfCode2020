namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day23;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Day23Tests
    {
        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver("389125467");
            solver.GetPartOneSolution().Should().Be("67384529");
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver("389125467");
            solver.GetPartTwoSolution().Should().Be("149245887792");
        }

    }
}
