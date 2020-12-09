using AdventOfCode2020.Common;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day09
{
    public class Solver : ISolver
    {
        private readonly int preamble;
        private readonly long[] inputs;
        private readonly List<(int first, int second)> pairs = new List<(int first, int second)>();
        private int firstSolutionPlace = -1;

        public Solver(IEnumerable<long> inputs, int preamble = 25)
        {
            this.preamble = preamble;
            this.inputs = inputs.ToArray();
            pairs = GeneratePairs().ToList();
        }

        private IEnumerable<(int first, int second)> GeneratePairs()
        {
            for (int i = 0; i < preamble - 1; i++)
            {
                for (int j = 1; j < preamble; j++)
                {
                    yield return (i, j);
                }
            }
        }

        public string GetFirstSolution()
        {
            int i;
            for (i = preamble; i < inputs.Length && HasSumOfTwoIn(inputs[i], inputs[(i - preamble)..i]); i++)
            {
            }
            firstSolutionPlace = i;
            return inputs[i].ToString();
        }

        private bool HasSumOfTwoIn(long v, long[] vs)
        {
            foreach (var (first, second) in pairs)
            {
                if (vs[first] + vs[second] == v)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetSecondSolution()
        {
            if (firstSolutionPlace == -1)
            {
                GetFirstSolution();
            }
            long firstSolutionValue = inputs[firstSolutionPlace];
            bool contiguousRangeHasFound = false;
            int rangeStart = 0, rangeEnd = 0;
            long sumOfRange = inputs[rangeStart];
            while (!contiguousRangeHasFound && rangeEnd < firstSolutionPlace)
            {
                if (firstSolutionValue > sumOfRange)
                {
                    rangeEnd++;
                    sumOfRange += inputs[rangeEnd];
                }
                else if (firstSolutionValue < sumOfRange)
                {
                    sumOfRange -= inputs[rangeStart];
                    rangeStart++;
                }
                else
                {
                    contiguousRangeHasFound = true;
                }
            }
            return (inputs[rangeStart..rangeEnd].Max() + inputs[rangeStart..rangeEnd].Min()).ToString();
        }
    }
}