namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day16;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Day16Tests
    {
        private readonly List<string> testInput1 = new List<string>(       
@"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12".Split(Environment.NewLine));

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetFirstSolution().Should().Be("71");
        }

        private readonly List<string> testInput2 = new List<string>(
@"departure class: 0-1 or 4-19
departure row: 0-5 or 8-19
seat: 0-13 or 16-19

your ticket:
11,12,13

nearby tickets:
3,9,18
15,1,5
5,14,9".Split(Environment.NewLine));

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput2);
            solver.GetSecondSolution().Should().Be((11*12).ToString());
        }
    }
}
