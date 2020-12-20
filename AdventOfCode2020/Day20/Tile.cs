namespace AdventOfCode2020.Day20
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tile
    {
        private char[][] pixels;
        private List<string> sides;

        public Tile(List<string> tileInput)
        {
            Id = int.Parse(tileInput[0].Split(" ").Last()[..^1]);
            pixels = tileInput.Skip(1).Select(s => s.ToCharArray()).ToArray();
            if (pixels.Length != 10 && pixels[0].Length != 10)
            {
                throw new Exception();
            }
            SetSides();
        }

        private void SetSides()
        {
            var top = new string(pixels[0]);
            var right = new string(pixels.Select(s => s.Last()).ToArray());
            var bottom = new string(pixels[9]);
            var left = new string(pixels.Select(s => s.First()).ToArray());
            sides = new List<string> { top, right, bottom, left };
        }

        public int Id { get; set; }
        public List<string> Sides => sides;

        public static int GetSideMatchCount(Tile tile1, Tile tile2)
        {
            var matchCount = 0;
            foreach (var side1 in tile1.Sides)
            {
                foreach (var side2 in tile2.Sides)
                {
                    if (side1 == side2 || Reverse(side1) == side2)
                    {
                        matchCount++;
                    }
                }
            }
            return matchCount;
        }

        public static string Reverse(string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
}
