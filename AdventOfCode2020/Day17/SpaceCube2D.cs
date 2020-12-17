namespace AdventOfCode2020.Day17
{
    using System.Collections.Generic;
    using System.Linq;

    public class SpaceCube2D : ISpaceCube
    {
        protected int hashCode;
        protected readonly List<ISpaceCube> neighbours = new List<ISpaceCube>();

        public SpaceCube2D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            hashCode = X ^ (Y << 2) ^ (Z << 4);
        }

        public int X { get; }
        public int Y { get; }
        public int Z { get; }
        public bool IsActive { get; set; }
        public bool IsActiveNext { get; set; }

        public override int GetHashCode()
        {
            return X ^ Y ^ Z;
        }

        public override bool Equals(object obj)
        {
            if (obj is not null && obj is SpaceCube2D spacePart)
            {
                return spacePart.X == X && spacePart.Y == Y && spacePart.Z == Z;
            }
            return false;
        }

        public void CalculateNextStatus(ISpace space)
        {
            var activeNeighbourCount = GetNeighbours(space).Count(pt => pt.IsActive);

            if (IsActive && (activeNeighbourCount == 2 || activeNeighbourCount == 3)
                || !IsActive && activeNeighbourCount == 3)
            {
                IsActiveNext = true;
            }
            else
            {
                IsActiveNext = false;
            }
        }

        public IEnumerable<ISpaceCube> GetNeighbours(ISpace space)
        {
            if (neighbours.Count == 0)
            {
                CalculateNeighbours(space);
            }
            return neighbours;
        }

        protected virtual void CalculateNeighbours(ISpace space)
        {
            for (int x = X - 1; x <= X + 1; x++)
            {
                for (int y = Y - 1; y <= Y + 1; y++)
                {
                    for (int z = Z - 1; z <= Z + 1; z++)
                    {
                        if (x != X || y != Y || z != Z)
                        {
                            neighbours.Add(space.GetSpacePart(x, y, z));
                        }
                    }
                }
            }
        }

        public void Change()
        {
            IsActive = IsActiveNext;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}, IsActive: {IsActive}";
        }
    }
}
