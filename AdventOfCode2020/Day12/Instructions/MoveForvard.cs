namespace AdventOfCode2020.Day12.Instructions
{
    using System;

    public class MoveForvard : IInstruction
    {
        private readonly int distance;

        public MoveForvard(int distance)
        {
            this.distance = distance;
        }
        public void Apply(Ship ship)
        {
            ship.PositionX += ship.WayPoint.X * distance;
            ship.PositionY += ship.WayPoint.Y * distance;
        }
    }
}
