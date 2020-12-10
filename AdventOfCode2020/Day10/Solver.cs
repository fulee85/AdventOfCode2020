namespace AdventOfCode2020.Day10
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solver : ISolver
    {
        private readonly List<int> joltages;

        public Solver(IEnumerable<int> input)
        {
            this.joltages = input.ToList();
            joltages.Sort();
        }
        public string GetFirstSolution()
        {
            var differenceCounter = new DifferenceCounter(joltages.First());
            for (int i = 0; i < joltages.Count - 1; i++)
            {
                differenceCounter.CountDifference(joltages[i], joltages[i + 1]);
            }
            differenceCounter.CountDifference(joltages.Last(), joltages.Last() + 3);
            return differenceCounter.Result.ToString();
        }

        public string GetSecondSolution()
        {
            var routesCounter = joltages.Select(e => new ListElement(e)).ToArray();
            routesCounter.Last().PossibleRoutesFromHere = 1;
            for (int i = routesCounter.Length - 2; 0 <= i; i--)
            {
                SetPossibleRouteCount(i, routesCounter);
            }
            return routesCounter.Where(e => e.Jolt <= 3).Sum(e => e.PossibleRoutesFromHere).ToString();
        }

        private void SetPossibleRouteCount(int i, ListElement[] routesCounter)
        {
            for (int j = i + 1; j < routesCounter.Length && routesCounter[j].Jolt - routesCounter[i].Jolt <= 3  ; j++)
            {
                routesCounter[i].PossibleRoutesFromHere += routesCounter[j].PossibleRoutesFromHere;
            }
        }
    }
}
