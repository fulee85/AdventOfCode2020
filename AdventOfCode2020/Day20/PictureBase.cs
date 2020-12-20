namespace AdventOfCode2020.Day20
{
    using System;

    public abstract class PictureBase
    {
        protected char[][] pixels;
        public int RowCount { get; protected set; }
        public int ColumnCount { get; protected set; }

        public virtual void RotateRight()
        {
            var newPixels = new char[ColumnCount][];
            for (int row = 0; row < ColumnCount; row++)
            {
                newPixels[row] = new char[RowCount];
                for (int col = 0; col < RowCount; col++)
                {
                    newPixels[row][col] = pixels[ColumnCount - 1 - col][row];
                }
            }
            pixels = newPixels;
        }

        public virtual void RotateLeft()
        {
            var newPixels = new char[ColumnCount][];
            for (int row = 0; row < ColumnCount; row++)
            {
                newPixels[row] = new char[RowCount];
                for (int col = 0; col < RowCount; col++)
                {
                    newPixels[row][col] = pixels[col][ColumnCount - 1 - row];
                }
            }
            pixels = newPixels;
        }

        public virtual void FlipVertical()
        {
            var newPixels = new char[RowCount][];
            for (int row = 0; row < RowCount; row++)
            {
                newPixels[row] = new char[ColumnCount];
                for (int col = 0; col < ColumnCount; col++)
                {
                    newPixels[row][col] = pixels[row][ColumnCount - 1 - col];
                }
            }
            pixels = newPixels;
        }

        public virtual void FlipHorisontal()
        {
            var newPixels = new char[RowCount][];
            for (int row = 0; row < RowCount; row++)
            {
                newPixels[row] = new char[ColumnCount];
                for (int col = 0; col < ColumnCount; col++)
                {
                    newPixels[row][col] = pixels[RowCount - 1 - row][col];
                }
            }
            pixels = newPixels;
        }
    }
}
