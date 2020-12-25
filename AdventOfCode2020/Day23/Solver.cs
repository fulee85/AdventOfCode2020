namespace AdventOfCode2020.Day23
{
    using AdventOfCode2020.Common;
    using System.Collections.Generic;
    using System.Linq;

    public class Solver : ISolver
    {
        private readonly List<int> cups;

        public Solver(IEnumerable<string> input)
        {
            cups = input.First().Select(c => int.Parse(c.ToString())).ToList();
        }
        public string GetPartOneSolution()
        {
            var crabGame = new CrabGame(cups);
            for (int i = 0; i < 100; i++)
            {
                crabGame.DoShuffle();
            }
            return crabGame.GetNumbersAfterOne();
        }

        
        public string GetPartTwoSolution()
        {
            var crabGame = new CrabGame(getCups());
            for (int i = 0; i < 10_000_000; i++)
            {
                crabGame.DoShuffle();
            }
            return crabGame.GetTwoNumbersMultipliedAfterCupOne();
        }

        private IEnumerable<int> getCups()
        {
            foreach (var cupId in cups)
            {
                yield return cupId;
            }
            for (int i = 10; i <= 1_000_000; i++)
            {
                yield return i;
            }
        }
    }
}
