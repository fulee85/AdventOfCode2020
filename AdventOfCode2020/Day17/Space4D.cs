namespace AdventOfCode2020.Day17
{
    public class Space4D : Space3D
    {
        protected override ISpaceCube CreateSpaceCube(int x, int y, int z, int w)
        {
            return new SpaceCube4D(x, y, z, w);
        }
    }
}
