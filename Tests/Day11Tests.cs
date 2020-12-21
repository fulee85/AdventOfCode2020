namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day11;
    using FluentAssertions;
    using System.Collections.Generic;
    using Xunit;

    public class Day11Tests
    {
        private readonly List<string> testInput = new List<string>
        {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        };

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput);
            solver.GetPartOneSolution().Should().Be("37");
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput);
            solver.GetPartTwoSolution().Should().Be("26");
        }
    }
}
