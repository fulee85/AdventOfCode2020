namespace AdventOfCode2020.Day20
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tile : PictureBase
    {
        private int dimension;
        private Dictionary<Side, string> sides;

        public Tile(List<string> tileInput)
        {
            Id = int.Parse(tileInput[0].Split(" ").Last()[..^1]);
            pixels = tileInput.Skip(1).Select(s => s.ToCharArray()).ToArray();
            if (pixels.Length != pixels[0].Length)
            {
                throw new Exception();
            }
            dimension = pixels.Length;
            RowCount = ColumnCount = pixels.Length;
            SetSides();
        }

        public char[][] GetPixels => pixels;

        private void SetSides()
        {
            var top = new string(pixels[0]);
            var right = new string(pixels.Select(s => s.Last()).ToArray());
            var bottom = new string(pixels[dimension - 1]);
            var left = new string(pixels.Select(s => s.First()).ToArray());
            sides = new Dictionary<Side, string> {
                { Side.Top , top },
                { Side.Right , right },
                { Side.Bottom , bottom },
                { Side.Left , left }
            };
        }

        public void RemoveEdges()
        {
            var newElements = new char[dimension - 2][];
            for (int row = 1; row < dimension - 1; row++)
            {
                newElements[row - 1] = new char[dimension - 2];
                for (int col = 1; col < dimension - 1; col++)
                {
                    newElements[row - 1][col - 1] = pixels[row][col];
                }
            }
            pixels = newElements;
            dimension -= 2;
            RowCount = ColumnCount = dimension;
        }

        internal char[] GetRow(int r)
        {
            return pixels[r];
        }

        public int Id { get; set; }
        public Dictionary<Side, string> Sides => sides;
        public int TileMatchCount => tileMatches.Count;

        public List<TileMatch> TileMatches => tileMatches;

        private List<TileMatch> tileMatches = new List<TileMatch>();

        public void AddTileMatch(TileMatch tileMatch) => tileMatches.Add(tileMatch);

        public static bool CheckTileMatch(Tile tile1, Tile tile2)
        {
            bool isAMatch = false;
            foreach (var side1 in tile1.Sides)
            {
                foreach (var side2 in tile2.Sides)
                {
                    if (side1.Value == side2.Value)
                    {
                        tile1.AddTileMatch(new TileMatch(side: side1.Key, otherTile: tile2));
                        tile2.AddTileMatch(new TileMatch(side: side2.Key, otherTile: tile1));
                        isAMatch = true;
                    }
                    else if (Reverse(side1.Value) == side2.Value)
                    {
                        tile1.AddTileMatch(new TileMatch(side: side1.Key, otherTile: tile2));
                        tile2.AddTileMatch(new TileMatch(side: side2.Key, otherTile: tile1));
                        isAMatch = true;
                    }
                }
            }
            return isAMatch;
        }

        public static string Reverse(string s)
        {
            return new string(s.Reverse().ToArray());
        }

        public override void RotateRight()
        {
            base.RotateRight();
            tileMatches.ForEach(tm => tm.RotateRight());
            SetSides();
        }

        public override void RotateLeft()
        {
            base.RotateLeft();
            tileMatches.ForEach(tm => tm.RotateLeft());
            SetSides();
        }

        public override void FlipVertical()
        {
            base.FlipVertical();
            tileMatches.ForEach(tm => tm.FlipVertical());
            SetSides();
        }

        public override void FlipHorisontal()
        {
            base.FlipHorisontal();
            tileMatches.ForEach(tm => tm.FlipHorisontal());
            SetSides();
        }
    }
}
