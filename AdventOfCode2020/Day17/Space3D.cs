namespace AdventOfCode2020.Day17
{
    public class Space3D : Space2D, ISpace
    {
        protected override ISpaceCube CreateSpaceCube(int x, int y, int z, int w)
        {
            return new SpaceCube3D(x, y, z, w);
        }
    }
}
