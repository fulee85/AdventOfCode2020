namespace AdventOfCode2020.Day11
{
    using System;
    using System.Collections.Generic;

    public record Position
    {
        private readonly int maxRow;
        private readonly int maxCol;

        public Position(int row, int col, int maxRow, int maxCol)
        {
            Row = row;
            Col = col;
            this.maxRow = maxRow;
            this.maxCol = maxCol;
        }

        public int Row { get; private set; }
        public int Col { get; private set; }
        private bool IsOnField => 0 <= Row && Row < maxRow && 0 <= Col && Col < maxCol;

        public IEnumerable<Position> GetPositionsInDirection(Directions dir)
        {
            var nextPosition = this.CreatePositionInDirection(dir);
            while (nextPosition.IsOnField)
            {
                yield return nextPosition;
                nextPosition = nextPosition.CreatePositionInDirection(dir);
            }
        }

        private Position CreatePositionInDirection(Directions dir) => dir switch
        {
            Directions.Up => this with { Row = Row + 1 },
            Directions.Down => this with { Row = Row -1 },
            Directions.Left => this with { Col = Col - 1 },
            Directions.Right => this with { Col = Col + 1 },
            Directions.UpLeft => this with { Row = Row + 1, Col = Col - 1 },
            Directions.UpRight => this with { Row = Row + 1, Col = Col + 1 },
            Directions.DownLeft => this with { Row = Row - 1, Col = Col - 1 },
            Directions.DownRight => this with { Row = Row - 1, Col = Col + 1 },
            _ => throw new Exception()
        };
    }
}
