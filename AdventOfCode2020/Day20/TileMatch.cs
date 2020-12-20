namespace AdventOfCode2020.Day20
{
    using System;

    public class TileMatch
    {
        public TileMatch(Side side, Tile otherTile)
        {
            Side = side;
            OtherTile = otherTile;
        }
        public bool IsReverseMatch { get; private set; }
        public Side Side { get; private set; }
        public Tile OtherTile { get; private set; }

        public void RotateLeft() => Side = Side.RotateLeft();
        public void RotateRight() => Side = Side.RotateRight();
        public void FlipVertical()
        {
            Side = Side.FlipVertical();
        }
        public void FlipHorisontal()
        {
            Side = Side.FlipHorizontal();
        }
    }

    public enum Side
    {
        Top,
        Right,
        Bottom,
        Left
    }
}
