namespace AdventOfCode2020.Day20
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Picture : PictureBase
    {
        private readonly List<List<Tile>> tiles = new List<List<Tile>>();
        private int tilesAddedSoFar;
        private readonly int allTilesCount;

        public int TileRowCount => tiles[0].Count;

        public bool Ready => tilesAddedSoFar == allTilesCount;

        public Picture(int tilesCount)
        {
            StartRow();
            this.allTilesCount = tilesCount;
            tilesAddedSoFar = 0;
        }

        public void StartRow()
        {
            tiles.Add(new List<Tile>());
        }

        internal void AddTile(Tile tile)
        {
            tiles.Last().Add(tile);
            tilesAddedSoFar++;
        }

        public void AssembleTiles()
        {
            tiles.ForEach(tl => tl.ForEach(t => t.RemoveEdges()));
            List<string> pictureRows = new List<string>();
            foreach (var tilesList in tiles)
            {
                for (int r = 0; r < tiles[0][0].RowCount; r++)
                {
                    pictureRows.Add("");
                    for (int i = 0; i < tilesList.Count; i++)
                    {
                        pictureRows[^1] = new string(pictureRows[^1].Concat(tilesList[i].GetRow(r)).ToArray());
                    }
                }
            }
            pixels = pictureRows.Select(pr => pr.ToCharArray()).ToArray();
            RowCount = pixels.Length;
            ColumnCount = pixels[0].Length;
        }

        internal void WriteOutPicture()
        {
            foreach (var row in pixels)
            {
                Console.WriteLine(new string(row));
            }
        }

        public int CountNotMonsters()
        {
            int counter = 0;
            foreach (var row in pixels)
            {
                foreach (var ch in row)
                {
                    if (ch == '#')
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        internal void MarkMonster(int row, int col)
        {
            pixels[row][col] = 'O';
        }

        public bool IsOccupiedElementAt(int row, int col)
        {
            if (0 <= row && row < RowCount && 0 <= col && col < ColumnCount)
            {
                return pixels[row][col] == '#';
            }
            return false;
        }
    }
}
