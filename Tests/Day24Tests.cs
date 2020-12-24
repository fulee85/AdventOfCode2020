namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day24;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class Day24Tests
    {
        private readonly List<Instruction> testInput1 = new List<Instruction>(
@"sesenwnenenewseeswwswswwnenewsewsw
neeenesenwnwwswnenewnwwsewnenwseswesw
seswneswswsenwwnwse
nwnwneseeswswnenewneswwnewseswneseene
swweswneswnenwsewnwneneseenw
eesenwseswswnenwswnwnwsewwnwsene
sewnenenenesenwsewnenwwwse
wenwwweseeeweswwwnwwe
wsweesenenewnwwnwsenewsenwwsesesenwne
neeswseenwwswnwswswnw
nenwswwsewswnenenewsenwsenwnesesenew
enewnwewneswsewnwswenweswnenwsenwsw
sweneswneswneneenwnewenewwneswswnese
swwesenesewenwneswnwwneseswwne
enesenwswwswneneswsenwnewswseenwsese
wnwnesenesenenwwnenwsewesewsesesew
nenewswnwewswnenesenwnesewesw
eneswnwswnwsenenwnwnwwseeswneewsenese
neswnwewnwnwseenwseesewsenwsweewe
wseweeenwnesenwwwswnew".Split(Environment.NewLine).Select(l => new Instruction(l)));

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetPartOneSolution().Should().Be("10");
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetPartTwoSolution().Should().Be("2208");
        }
    }
}
