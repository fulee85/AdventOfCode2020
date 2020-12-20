namespace AdventOfCode2020.Day20
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solver : ISolver
    {
        private List<Tile> tiles = new List<Tile>();
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

        public string GetFirstSolution()
        {
            var tileDict = tiles.ToDictionary(t => t.Id, t => new List<Tile>());
            for (int i = 0; i < tiles.Count - 1; i++)
            {
                for (int j = i + 1; j < tiles.Count; j++)
                {
                    var matchCount = Tile.GetSideMatchCount(tiles[i], tiles[j]);
                    if (matchCount > 0)
                    {
                        tileDict[tiles[i].Id].Add(tiles[j]);
                        tileDict[tiles[j].Id].Add(tiles[i]);
                    }
                }
            }
            var y = tileDict.Where(t => t.Value.Count == 2).Aggregate(1M, (a,kv) => a*kv.Key);
            return y.ToString();
        }

        public string GetSecondSolution()
        {
            return string.Empty;
        }

    }
}
