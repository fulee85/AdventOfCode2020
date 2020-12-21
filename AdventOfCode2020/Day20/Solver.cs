namespace AdventOfCode2020.Day20
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solver : ISolver
    {
        private readonly List<Tile> tiles = new List<Tile>();
        public Solver(IEnumerable<string> input)
        {
            var tileInput = new List<string>(); 
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    tiles.Add(new Tile(tileInput));
                    tileInput = new List<string>();
                }
                else
                {
                    tileInput.Add(line);
                }
            }
            if (tileInput.IsNotEmpty())
            {
                tiles.Add(new Tile(tileInput));
            }
        }

        public string GetPartOneSolution()
        {
            InitializeTileConnections();
            return GetCornerTiles().Aggregate(1M, (a, t) => a * t.Id).ToString();
        }

        public string GetPartTwoSolution()
        {
            InitializeTileConnections();
            var cornerTiles = GetCornerTiles();
            var pictureBuilder = new PictureBuilder(cornerTiles, tiles);
            var picture = pictureBuilder.Build();
            picture.AssembleTiles();
            // picture.WriteOutPicture();
            var monsterFinder = new MonsterFinder(picture);
            monsterFinder.MarkMonstersOnPicture();
            // picture.WriteOutPicture();
            return picture.CountNotMonsters().ToString();
        }

        private IEnumerable<Tile> GetCornerTiles() => tiles.Where(t => t.TileMatchCount == 2);

        private bool isInitialized = false;
        private void InitializeTileConnections()
        {
            if (isInitialized) return;
            isInitialized = true;

            for (int i = 0; i < tiles.Count - 1; i++)
            {
                for (int j = i + 1; j < tiles.Count; j++)
                {
                    Tile.CheckTileMatch(tiles[i], tiles[j]);
                }
            }

        }
    }
}
