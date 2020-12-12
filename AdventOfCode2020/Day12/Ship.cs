namespace AdventOfCode2020.Day12
{
    using System;

    public class Ship
    {
        public Ship(DirectionVector wayPoint)
        {
            WayPoint = wayPoint;
        }

        public int PositionX { get; set; } = 0;
        public int PositionY { get; set; } = 0;

        public DirectionVector WayPoint { get; private set; }

        public int GetManhattanDistance()
        {
            return Math.Abs(PositionX) + Math.Abs(PositionY);
        }
    }
}
