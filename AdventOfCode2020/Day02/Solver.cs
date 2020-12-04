using AdventOfCode2020.Common;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day02
{
    public class Solver : ISolver
    {
        private readonly IEnumerable<Password> input;

        public Solver(IEnumerable<Password> input)
        {
            this.input = input;
        }

        public string GetFirstSolution() => input.Count(prop => prop.IsValidSledRental).ToString();

        public string GetSecondSolution() => input.Count(prop => prop.IsValidAtToboggan).ToString();
    }
}
