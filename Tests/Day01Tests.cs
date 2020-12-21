using AdventOfCode2020.Common;
using AdventOfCode2020.Day01;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class Day01Tests
    {
        [Fact]
        public void Test1()
        {
            ISolver solver = new Solver(new List<int>{ 1721,979,366,299,675,1456 });
            solver.GetPartOneSolution().Should().Be("514579");
        }

        [Fact]
        public void Test2()
        {
            ISolver solver = new Solver(new List<int> { 1721, 979, 366, 299, 675, 1456 });
            solver.GetPartTwoSolution().Should().Be("241861950");
        }
    }
}
