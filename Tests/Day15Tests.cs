namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day15;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Day15Tests
    {
        [Theory]
        [InlineData("0,3,6", "436")]
        [InlineData("1,3,2", "1")]
        [InlineData("2,1,3", "10")]
        [InlineData("1,2,3", "27")]
        [InlineData("2,3,1", "78")]
        public void PartOneTest1(string input, string expectedResult)
        {
            ISolver solver = new Solver(input);
            solver.GetFirstSolution().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("0,3,6", "175594")]
        [InlineData("1,3,2", "2578")]
        [InlineData("2,1,3", "3544142")]
        [InlineData("1,2,3", "261214")]
        [InlineData("2,3,1", "6895259")]
        [InlineData("3,2,1", "18")]
        [InlineData("3,1,2", "362")]
        public void PartTwoTest1(string input, string expectedResult)
        {
            ISolver solver = new Solver(input);
            solver.GetSecondSolution().Should().Be(expectedResult);
        }
    }
}
