namespace AdventOfCode2020.Day24
{
    using AdventOfCode2020.Common;
    using System.Collections.Generic;
    using System.Linq;

    public class LobbyFloor
    {
        private HashSet<TilePosition> blackTiles = new HashSet<TilePosition>();

        public int BlackTileCount => blackTiles.Count;

        public void FlipTileInPosition(TilePosition tilePosition)
        {
            if (!blackTiles.Contains(tilePosition))
            {
                blackTiles.Add(tilePosition);
            }
            else
            {
                blackTiles.Remove(tilePosition);
            }
        }

        public void DoDailyFlips()
        {
            var tilesPositionsToCheck = new HashSet<TilePosition>();
            foreach (var blackTile in blackTiles)
            {
                tilesPositionsToCheck.Add(blackTile);
                blackTile.GetAdjacentPositions().ForEach(adj => tilesPositionsToCheck.Add(adj));
            }

            var nextBlackTiles = new HashSet<TilePosition>();
            foreach (var tilePositionToCheck in tilesPositionsToCheck)
            {
                var blackAdjCount = tilePositionToCheck
                    .GetAdjacentPositions()
                    .Count(adj => blackTiles.Contains(adj));

                if (blackTiles.Contains(tilePositionToCheck))
                { // Tile is black
                    if (blackAdjCount == 1 || blackAdjCount == 2)
                    {
                        nextBlackTiles.Add(tilePositionToCheck); // RemainsBlack
                    }
                }
                else
                { // Tile is white
                    if (blackAdjCount == 2)
                    {
                        nextBlackTiles.Add(tilePositionToCheck); // SwitchToBlack
                    }
                }
            }
            blackTiles = nextBlackTiles;
        }
    }
}
