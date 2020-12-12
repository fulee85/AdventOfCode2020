namespace AdventOfCode2020.Day12.Instructions
{
    using System;

    public class MoveWaypointToDirection : IInstruction
    {
        private readonly Direction direction;
        private readonly int distance;

        public MoveWaypointToDirection(Direction direction, int distance)
        {
            this.direction = direction;
            this.distance = distance;
        }
        public void Apply(Ship ship)
        {
            switch (direction)
            {
                case Direction.North:
                    ship.WayPoint.Y += distance;
                    break;
                case Direction.East:
                    ship.WayPoint.X += distance;
                    break;
                case Direction.South:
                    ship.WayPoint.Y -= distance;
                    break;
                case Direction.West:
                    ship.WayPoint.X -= distance;
                    break;
            }
        }
    }
}
