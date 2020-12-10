namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day10;
    using FluentAssertions;
    using System.Collections.Generic;
    using Xunit;

    public class Day10Tests
    {
        private List<int> testInput1 = new List<int> { 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4 };
        private List<int> testInput2 = new List<int> { 28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4, 2, 34, 10, 3 };

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetFirstSolution().Should().Be("35");
        }

        [Fact]
        public void PartOneTest2()
        {
            ISolver solver = new Solver(testInput2);
            solver.GetFirstSolution().Should().Be("220");
        }

        [Fact]
        public void PartTwoTest0()
        {
            ISolver solver = new Solver(new[] { 1,4,5,6,7});
            solver.GetSecondSolution().Should().Be("4");
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetSecondSolution().Should().Be("8");
        }

        [Fact]
        public void PartTwoTest2()
        {
            ISolver solver = new Solver(testInput2);
            solver.GetSecondSolution().Should().Be("19208");
        }
    }
}
