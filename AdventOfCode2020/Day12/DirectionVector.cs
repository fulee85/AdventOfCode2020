namespace AdventOfCode2020.Day12
{
    using System;

    public class DirectionVector
    {
        public DirectionVector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void RotateBy(int degree)
        {
            var x = X * Cos(degree) - Y * Sin(degree);
            var y = X * Sin(degree) + Y * Cos(degree);
            X = x;
            Y = y;
        }

        private int Sin(int x)
        {
            return (int)Math.Sin(Math.PI * x / 180);
        }

        private int Cos(int x)
        {
            return (int)Math.Cos(Math.PI * x / 180);
        }
    }
}
