namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day20;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Day20Tests
    {
        [Fact]
        public void RotateRightTest()
        {
            var input = new List<string>
            {
                "Tile 2311:",
                "123",
                "456",
                "789"
            };
            Tile tile = new Tile(input);
            tile.RotateRight();
            var pixels = tile.GetPixels;
            var expectedResult = new char[3][]
            {
                "741".ToCharArray(),
                "852".ToCharArray(),
                "963".ToCharArray()
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pixels[i][j].Should().Be(expectedResult[i][j]);
                }
            }
        }

        [Fact]
        public void RotateLeftTest()
        {
            var input = new List<string>
            {
                "Tile 2311:",
                "123",
                "456",
                "789"
            };
            Tile tile = new Tile(input);
            tile.RotateLeft();
            var pixels = tile.GetPixels;
            var expectedResult = new char[3][]
            {
                "369".ToCharArray(),
                "258".ToCharArray(),
                "147".ToCharArray()
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pixels[i][j].Should().Be(expectedResult[i][j]);
                }
            }
        }

        [Fact]
        public void VeriticalFlipTest()
        {
            var input = new List<string>
            {
                "Tile 2311:",
                "123",
                "456",
                "789"
            };
            Tile tile = new Tile(input);
            tile.FlipVertical();
            var pixels = tile.GetPixels;
            var expectedResult = new char[3][]
            {
                "321".ToCharArray(),
                "654".ToCharArray(),
                "987".ToCharArray()
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pixels[i][j].Should().Be(expectedResult[i][j]);
                }
            }
        }

        [Fact]
        public void HorisontalFlipTest()
        {
            var input = new List<string>
            {
                "Tile 2311:",
                "123",
                "456",
                "789"
            };
            Tile tile = new Tile(input);
            tile.FlipHorisontal();
            var pixels = tile.GetPixels;
            var expectedResult = new char[3][]
            {
                "789".ToCharArray(),
                "456".ToCharArray(),
                "123".ToCharArray()
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pixels[i][j].Should().Be(expectedResult[i][j]);
                }
            }
        }

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput);
            solver.GetFirstSolution().Should().Be("20899048083289");
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput);
            solver.GetSecondSolution().Should().Be("273");
        }

        private readonly List<string> testInput = new List<string>(
@"Tile 2311:
..##.#..#.
##..#.....
#...##..#.
####.#...#
##.##.###.
##...#.###
.#.#.#..##
..#....#..
###...#.#.
..###..###

Tile 1951:
#.##...##.
#.####...#
.....#..##
#...######
.##.#....#
.###.#####
###.##.##.
.###....#.
..#.#..#.#
#...##.#..

Tile 1171:
####...##.
#..##.#..#
##.#..#.#.
.###.####.
..###.####
.##....##.
.#...####.
#.##.####.
####..#...
.....##...

Tile 1427:
###.##.#..
.#..#.##..
.#.##.#..#
#.#.#.##.#
....#...##
...##..##.
...#.#####
.#.####.#.
..#..###.#
..##.#..#.

Tile 1489:
##.#.#....
..##...#..
.##..##...
..#...#...
#####...#.
#..#.#.#.#
...#.#.#..
##.#...##.
..##.##.##
###.##.#..

Tile 2473:
#....####.
#..#.##...
#.##..#...
######.#.#
.#...#.#.#
.#########
.###.#..#.
########.#
##...##.#.
..###.#.#.

Tile 2971:
..#.#....#
#...###...
#.#.###...
##.##..#..
.#####..##
.#..####.#
#..#.#..#.
..####.###
..#.#.###.
...#.#.#.#

Tile 2729:
...#.#.#.#
####.#....
..#.#.....
....#..#.#
.##..##.#.
.#.####...
####.#.#..
##.####...
##..#.##..
#.##...##.

Tile 3079:
#.#.#####.
.#..######
..#.......
######....
####.#..#.
.#...#.##.
#.#####.##
..#.###...
..#.......
..#.###...".Split(Environment.NewLine));
    }
}
