namespace AdventOfCode2020.Day12.Instructions
{
    using System;

    public class Turn : IInstruction
    {
        private readonly Side side;
        private readonly int degree;

        public Turn(Side side, int degree)
        {
            this.side = side;
            this.degree = degree;
        }

        public void Apply(Ship ship)
        {
            switch (side)
            {
                case Side.Left:
                    ship.WayPoint.RotateBy(degree);
                    break;
                case Side.Right:
                    ship.WayPoint.RotateBy(-degree);
                    break;
                default:
                    break;
            }
        }
    }
}
