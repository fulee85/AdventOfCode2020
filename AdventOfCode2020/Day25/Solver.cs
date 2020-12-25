namespace AdventOfCode2020.Day25
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solver : ISolver
    {
        private readonly int cardPublicKey;
        private readonly int doorPublicKey;

        public Solver(IEnumerable<string> input)
        {
            cardPublicKey = int.Parse(input.First());
            doorPublicKey = int.Parse(input.Last());
        }
        public string GetPartOneSolution()
        {
            var value = 1L;
            var subjectNumber = 7;
            var loopSize = 0;
            while (value != cardPublicKey)
            {
                loopSize++;
                value *= subjectNumber;
                value %= 20201227;
            }

            value = 1L;
            subjectNumber = doorPublicKey;
            for (int i = 0; i < loopSize; i++)
            {
                value *= subjectNumber;
                value %= 20201227;
            }

            return value.ToString();
        }

        public string GetPartTwoSolution()
        {
            return "";
        }
    }
}
