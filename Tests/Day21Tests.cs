namespace Tests
{

    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day21;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;
    using System.Linq;

    public class Day21Tests
    {
        private readonly List<Food> testInput1 = 
@"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
trh fvjkl sbzzf mxmxvkd (contains dairy)
sqjhc fvjkl (contains soy)
sqjhc mxmxvkd sbzzf (contains fish)".Split(Environment.NewLine).Select(l => new Food(l)).ToList();

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetPartOneSolution().Should().Be("5");
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetPartTwoSolution().Should().Be("mxmxvkd,sqjhc,fvjkl");
        }
    }
}
