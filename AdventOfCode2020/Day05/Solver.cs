using AdventOfCode2020.Common;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day05
{
    public class Solver : ISolver
    {
        private readonly IEnumerable<BoardingPass> boardingPasses;

        public Solver(IEnumerable<BoardingPass> boardingPasses)
        {
            this.boardingPasses = boardingPasses;
        }
        public string GetFirstSolution() => boardingPasses.Max(bp => bp.SeatId).ToString();

        public string GetSecondSolution()
        {
            return "";
        }
    }
}
