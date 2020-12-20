namespace AdventOfCode2020.Day20
{
    using System;

    public static class SideHelper
    {
        public static Side RotateRight(this Side side) => side switch
        {
            Side.Top => Side.Right,
            Side.Right => Side.Bottom,
            Side.Bottom => Side.Left,
            Side.Left => Side.Top,
            _ => throw new ArgumentException()
        };

        public static Side RotateLeft(this Side side) => side switch
        {
            Side.Top => Side.Left,
            Side.Left => Side.Bottom,
            Side.Bottom => Side.Right,
            Side.Right => Side.Top,
            _ => throw new ArgumentException()
        };

        public static Side FlipVertical(this Side side) => side switch
        {
            Side.Right => Side.Left,
            Side.Left => Side.Right,
            Side.Top => Side.Top,
            Side.Bottom => Side.Bottom,
            _ => throw new ArgumentException()
        };

        public static Side FlipHorizontal(this Side side) => side switch
        {
            Side.Top => Side.Bottom,
            Side.Bottom => Side.Top,
            Side.Right => Side.Right,
            Side.Left => Side.Left,
            _ => throw new ArgumentException()
        };
    }
}
