namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day12;
    using AdventOfCode2020.Day12.Instructions;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class Day12Tests
    {
        private readonly List<string> testInput = new List<string>
        {
            "F10",
            "N3",
            "F7",
            "R90",
            "F11"
        };

        [Fact]
        public void DirectionTest1()
        {
            var dir = new DirectionVector(1, 0);
            dir.RotateBy(90);
            dir.X.Should().Be(0);
            dir.Y.Should().Be(1);
        }

        [Fact]
        public void DirectionTest2()
        {
            var dir = new DirectionVector(1, 0);
            dir.RotateBy(-90);
            dir.X.Should().Be(0);
            dir.Y.Should().Be(-1);
        }

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput);
            solver.GetPartOneSolution().Should().Be("25");
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput);
            solver.GetPartTwoSolution().Should().Be("286");
        }
    }
}
