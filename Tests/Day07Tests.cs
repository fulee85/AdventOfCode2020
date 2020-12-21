using AdventOfCode2020.Common;
using AdventOfCode2020.Day07;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class Day07Tests
    {
        [Fact]
        public void BagRuleTest1()
        {
            var bagRule = new BagRule("light red bags contain 1 bright white bag, 2 muted yellow bags.");
            bagRule.ContainerBag.Should().Be("light-red");
            bagRule.ContainedBags.Should().Equal(new List<Bag> { new Bag(1,"bright-white"), new Bag(2, "muted-yellow") });
        }

        [Fact]
        public void SolverTest1()
        {
            ISolver solver = new Solver(
@"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.".Split(Environment.NewLine).Select(s => new BagRule(s)));
            solver.GetPartOneSolution().Should().Be("4");
        }

        [Fact]
        public void SolverTest2()
        {
            ISolver solver = new Solver(
@"shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.".Split(Environment.NewLine).Select(s => new BagRule(s)));
            solver.GetPartTwoSolution().Should().Be("126");
        }
    }
}
