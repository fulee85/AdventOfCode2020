namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day18;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Day18Tests
    {
        private readonly List<string> testInput = new List<string>
        {
            "2 * 3 + (4 * 5)",
            "5 + (8 * 3 + 9 + 3 * 4 * 3)",
            "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))",
            "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2",
        };

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput);
            solver.GetFirstSolution().Should().Be((26 + 437 + 12240 + 13632).ToString());
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput);
            solver.GetSecondSolution().Should().Be((693891).ToString());
        }
    }
}
