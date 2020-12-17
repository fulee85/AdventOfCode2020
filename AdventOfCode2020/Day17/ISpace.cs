namespace AdventOfCode2020.Day17
{
    public interface ISpace
    {
        int GetActivePartsCount();
        void SetActivePart(int x, int y);
        ISpaceCube GetSpacePart(int x, int y, int z, int w = 0);
        void Step();
    }
}