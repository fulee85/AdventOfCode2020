using AdventOfCode2020.Common;
using AdventOfCode2020.Day03;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class Day03Tests
    {
        [Fact]
        public void SolverTest1()
        {
            ISolver solver = new Solver(new List<string> {
"..##.......",
"#...#...#..",
".#....#..#.",
"..#.#...#.#",
".#...##..#.",
"..#.##.....",
".#.#.#....#",
".#........#",
"#.##...#...",
"#...##....#",
".#..#...#.#"
            });
            solver.GetFirstSolution().Should().Be("7");
        }

        [Fact]
        public void SolverTest2()
        {
            ISolver solver = new Solver(new List<string> {
"..##.......",
"#...#...#..",
".#....#..#.",
"..#.#...#.#",
".#...##..#.",
"..#.##.....",
".#.#.#....#",
".#........#",
"#.##...#...",
"#...##....#",
".#..#...#.#"
            });
            solver.GetSecondSolution().Should().Be("336");
        }
    }
}
