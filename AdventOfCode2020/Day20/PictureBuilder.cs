namespace AdventOfCode2020.Day20
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PictureBuilder
    {
        private readonly IEnumerable<Tile> cornerTiles;
        private readonly List<Tile> tiles;

        public PictureBuilder(IEnumerable<Tile> cornerTiles, List<Tile> tiles)
        {
            this.cornerTiles = cornerTiles;
            this.tiles = tiles;
        }

        public Picture Build()
        {
            var picture = new Picture(tiles.Count);
            var startingTile = FindStartingTile();
            var actualTile = startingTile;
            picture.AddTile(actualTile);
            var rightNextTile = actualTile.TileMatches.First(tm => tm.Side == Side.Right).OtherTile;
            while (!cornerTiles.Contains(rightNextTile))
            {
                TransformToMatchLeft(actualTile, rightNextTile);
                picture.AddTile(rightNextTile);
                actualTile = rightNextTile;
                rightNextTile = rightNextTile.TileMatches.First(tm => tm.Side == Side.Right).OtherTile;
            }
            TransformToMatchLeft(actualTile, rightNextTile);
            picture.AddTile(rightNextTile);
            // NEXT LINE
            while (!picture.Ready)
            {
                picture.StartRow();
                actualTile = startingTile;
                var bottomNextTile = actualTile.TileMatches.First(tm => tm.Side == Side.Bottom).OtherTile;
                TransformToMatchTop(actualTile, bottomNextTile);
                picture.AddTile(bottomNextTile);
                actualTile = bottomNextTile;
                startingTile = bottomNextTile;
                for (int i = 0; i < picture.TileRowCount - 1; i++)
                {
                    rightNextTile = actualTile.TileMatches.First(tm => tm.Side == Side.Right).OtherTile;
                    TransformToMatchLeft(actualTile, rightNextTile);
                    picture.AddTile(rightNextTile);
                    actualTile = rightNextTile;
                }
            }

            return picture;
        }

        private void TransformToMatchTop(Tile actualTile, Tile bottomNextTile)
        {
            var match = bottomNextTile.TileMatches.First(tm => tm.OtherTile == actualTile);
            if (match.Side == Side.Right)
            {
                bottomNextTile.RotateLeft();
            }
            else if (match.Side == Side.Bottom)
            {
                bottomNextTile.FlipHorisontal();
            }
            else if (match.Side == Side.Left)
            {
                bottomNextTile.RotateRight();
            }
            if (actualTile.Sides[Side.Bottom] != bottomNextTile.Sides[Side.Top])
            {
                bottomNextTile.FlipVertical();
                if (actualTile.Sides[Side.Bottom] != bottomNextTile.Sides[Side.Top])
                {
                    throw new Exception();
                }
            }
        }

        private void TransformToMatchLeft(Tile actualTile, Tile rightMatchTile)
        {
            var match = rightMatchTile.TileMatches.First(tm => tm.OtherTile == actualTile);
            if (match.Side == Side.Right)
            {
                rightMatchTile.FlipVertical();
            }
            else if (match.Side == Side.Top)
            {
                rightMatchTile.RotateLeft();
            }
            else if (match.Side == Side.Bottom)
            {
                rightMatchTile.RotateRight();
            }
            if (actualTile.Sides[Side.Right] != rightMatchTile.Sides[Side.Left])
            {
                rightMatchTile.FlipHorisontal();
                if (actualTile.Sides[Side.Right] != rightMatchTile.Sides[Side.Left])
                {
                    throw new Exception();
                }
            }
        }



        // We start to connect tiles from the top left corner
        private Tile FindStartingTile()
        {
            var startingTile = Find();
            while (startingTile is null)
            {
                cornerTiles.ForEach(t => t.RotateRight());
                startingTile = Find();
            }
            return startingTile;

            Tile Find() => cornerTiles.FirstOrDefault(t => t.TileMatches.Select(tm => tm.Side).Contains(Side.Right) &&
            t.TileMatches.Select(tm => tm.Side).Contains(Side.Bottom));
        }
    }
}
