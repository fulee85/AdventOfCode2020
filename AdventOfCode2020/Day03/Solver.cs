using AdventOfCode2020.Common;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day03
{
    public class Solver : ISolver
    {
        private readonly List<string> input;

        public Solver(IEnumerable<string> input)
        {
            this.input = input.ToList();
        }

        const char tree = '#';

        public string GetPartOneSolution() => CountEncounteredTrees(3, 1).ToString();

        private static readonly List<(int right, int down)> steps = new List<(int right, int down)>
        {
            (1,1),
            (3,1),
            (5,1),
            (7,1),
            (1,2)
        };

        public string GetPartTwoSolution() => steps
            .Select(t => CountEncounteredTrees(t.right, t.down))
            .Aggregate(1M, (a, b) => a * b).ToString();

        private int CountEncounteredTrees(int stepRight, int stepDown)
        {
            int horisontalPosition = 0;
            int treeCount = 0;
            for (int row = 0; row < input.Count; row += stepDown)
            {
                horisontalPosition %= input[row].Length;
                if (input[row][horisontalPosition] == tree)
                {
                    treeCount++;
                }
                horisontalPosition += stepRight;
            }

            return treeCount;
        }
    }
}
