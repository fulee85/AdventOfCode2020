namespace AdventOfCode2020.Day20
{
    using System;
    using System.Collections.Generic;

    public class MonsterFinder
    {
        private string monster = 
@"                  # 
#    ##    ##    ###
 #  #  #  #  #  #   ";
        private Picture picture;
        private List<RelativePosition> monsterRelativePositions = new List<RelativePosition>();

        public MonsterFinder(Picture picture)
        {
            this.picture = picture;
            string[] monsterMatrix = monster.Split(Environment.NewLine);
            for (int row = 0; row < monsterMatrix.Length; row++)
            {
                for (int col = 0; col < monsterMatrix[0].Length; col++)
                {
                    if (monsterMatrix[row][col] == '#')
                    {
                        monsterRelativePositions.Add(new RelativePosition(row, col));
                    }
                }
            }
        }

        public void MarkMonstersOnPicture()
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int row = 0; row < picture.RowCount; row++)
                    {
                        for (int col = 0; col < picture.ColumnCount; col++)
                        {
                            bool monsterFound = true;
                            foreach (var relPos in monsterRelativePositions)
                            {
                                if (!picture.IsOccupiedElementAt(relPos.ToAbsRow(row), relPos.ToAbsCol(col)))
                                {
                                    monsterFound = false;
                                    break;
                                }
                            }
                            if (monsterFound)
                            {
                                foreach (var relPos in monsterRelativePositions)
                                {
                                    picture.MarkMonster(relPos.ToAbsRow(row), relPos.ToAbsCol(col));
                                }
                            }
                        }
                    }
                    picture.RotateRight();
                }
                picture.RotateRight();
                picture.FlipHorisontal();
            }
        }

        private class RelativePosition
        {
            private readonly int row;
            private readonly int col;

            public RelativePosition(int row, int col)
            {
                this.row = row;
                this.col = col;
            }

            public int ToAbsRow(int r)
            {
                return r + row;
            }

            public int ToAbsCol(int c)
            {
                return c + col;
            }
        }
    }
}
