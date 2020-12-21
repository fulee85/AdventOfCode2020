namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day14;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Day14Tests
    {
        private readonly List<string> testInput1 = new List<string>
        {
            "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
            "mem[8] = 11",
            "mem[7] = 101",
            "mem[8] = 0",
        };

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetPartOneSolution().Should().Be("165");
        }

        private readonly List<string> testInput2 = new List<string>
        {
            "mask = 000000000000000000000000000000X1001X",
            "mem[42] = 100",
            "mask = 00000000000000000000000000000000X0XX",
            "mem[26] = 1",
        };

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput2);
            solver.GetPartTwoSolution().Should().Be("208");
        }
    }
}
