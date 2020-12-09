namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day09;
    using FluentAssertions;
    using System;
    using Xunit;

    public class Day09Tests
    {
        private long[] testInput = new long[] { 35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576 };

        [Fact]
        public void PartOneTest()
        {
            ISolver solver = new Solver(testInput, 5);
            solver.GetFirstSolution().Should().Be("127");
        }

        [Fact]
        public void PartTwoTest()
        {
            ISolver solver = new Solver(testInput, 5);
            solver.GetSecondSolution().Should().Be("62");
        }
    }
}
