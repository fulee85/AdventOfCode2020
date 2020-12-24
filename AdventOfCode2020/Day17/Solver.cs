namespace AdventOfCode2020.Day17
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;

    public class Solver : ISolver
    {
        private readonly ISpace space2D;
        private readonly ISpace space3D;

        public Solver(List<string> input)
        {
            space2D = new Space3D();
            space3D = new Space4D();
            int i = 0;
            for (int x = -input.Count / 2; x <= input.Count / 2 && i < input.Count; x++)
            {
                var line = input[i++];
                int j = 0;
                for (int y = -line.Length / 2; y <= line.Length / 2 && j < line.Length; y++)
                {
                    if (line[j++] == '#')
                    {
                        space2D.SetActivePart(x, y);
                        space3D.SetActivePart(x, y);
                    }
                }
            }
        }

        public string GetPartOneSolution()
        {
            return GetActiveCubeCount(space2D);
        }

        public string GetPartTwoSolution()
        {
            return GetActiveCubeCount(space3D);
        }

        private string GetActiveCubeCount(ISpace space)
        {
            for (int round = 0; round < 6; round++)
            {
                space.Step();
            }
            return space.GetActivePartsCount().ToString();
        }

    }
}
