namespace AdventOfCode2020.Day15
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solver : ISolver
    {
        public Solver(string input)
        {
            startingNumbers = input.Split(',').Select(int.Parse).ToArray();
        }

        private readonly int[] startingNumbers;

        public string GetPartOneSolution()
        {
            return Calculate(2020);
        }

        public string GetPartTwoSolution()
        {
            return Calculate(30000000);
        }

        private string Calculate(int elementNeed)
        {
            var numberTurnDict = new Dictionary<int, int>();
            int round = 1;
            for (int i = 0; i < startingNumbers.Length - 1; i++)
            {
                numberTurnDict[startingNumbers[i]] = round++;
            }
            int lastNumberSpoken = startingNumbers.Last();
            int lastRound = startingNumbers.Length;

            int actualRound = lastRound + 1;
            while (lastRound != elementNeed)
            {
                if (numberTurnDict.ContainsKey(lastNumberSpoken))
                {
                    var lastNumberLastTimeSpoken = numberTurnDict[lastNumberSpoken];
                    numberTurnDict[lastNumberSpoken] = lastRound;
                    lastNumberSpoken = lastRound - lastNumberLastTimeSpoken;
                }
                else
                {
                    numberTurnDict[lastNumberSpoken] = lastRound;
                    lastNumberSpoken = 0;
                }
                lastRound++;
                actualRound++;
            }
            return lastNumberSpoken.ToString();
        }
    }
}
