namespace AdventOfCode2020.Day17
{
    public class SpaceCube4D : SpaceCube3D, ISpaceCube
    {
        public SpaceCube4D(int x, int y, int z, int w) : base(x, y, z)
        {
            W = w;
            hashCode ^= (W << 6);
        }

        public int W { get; }

        protected override void CalculateNeighbours(ISpace space)
        {
            for (int x = X - 1; x <= X + 1; x++)
            {
                for (int y = Y - 1; y <= Y + 1; y++)
                {
                    for (int z = Z - 1; z <= Z + 1; z++)
                    {
                        for (int w = W - 1; w <= W + 1; w++)
                        {
                            if (x != X || y != Y || z != Z || w != W)
                            {
                                neighbours.Add(space.GetSpacePart(x, y, z, w));
                            }
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}, W: {W}, IsActive: {IsActive}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not null && obj is SpaceCube4D spacePart)
            {
                return spacePart.X == X && spacePart.Y == Y && spacePart.Z == Z && spacePart.W == W;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return hashCode;
        }
    }
}
