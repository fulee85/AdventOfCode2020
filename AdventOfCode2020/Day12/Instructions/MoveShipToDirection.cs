namespace AdventOfCode2020.Day12.Instructions
{
    using System;

    public class MoveShipToDirection : IInstruction
    {
        private readonly Direction direction;
        private readonly int distance;

        public MoveShipToDirection(Direction direction, int distance)
        {
            this.direction = direction;
            this.distance = distance;
        }
        public void Apply(Ship ship)
        {
            switch (direction)
            {
                case Direction.North:
                    ship.PositionY += distance;
                    break;
                case Direction.East:
                    ship.PositionX += distance;
                    break;
                case Direction.South:
                    ship.PositionY -= distance;
                    break;
                case Direction.West:
                    ship.PositionX -= distance;
                    break;
            }
        }
    }
}