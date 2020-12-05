using AdventOfCode2020.Common;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day05
{
    public class Solver : ISolver
    {
        private readonly List<int> boardingPassIds;

        public Solver(IEnumerable<BoardingPass> boardingPasses)
        {
            this.boardingPassIds = boardingPasses
                .OrderByDescending(bp => bp.SeatId)
                .Select(bp => bp.SeatId)
                .ToList();
        }
        public string GetFirstSolution() => boardingPassIds.FirstOrDefault().ToString();

        public string GetSecondSolution()
        {
            int mySeat = -1;
            for (int i = 0; i < boardingPassIds.Count - 1 && mySeat == -1; i++)
            {
                if (boardingPassIds[i] - boardingPassIds[i + 1] > 1)
                {
                    mySeat = boardingPassIds[i] - 1;
                }
            }
            return mySeat.ToString();
        }
    }
}
