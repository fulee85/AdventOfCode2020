namespace AdventOfCode2020.Day18
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solver : ISolver
    {
        private readonly IEnumerable<string> input;

        public Solver(IEnumerable<string> input)
        {
            this.input = input;
        }
        public string GetPartOneSolution()
        {
            decimal result = 0M; 
            foreach (var expression in input)
            {
                var calculator = new Calculator();
                result += calculator.Calculate(expression);
            }
            return result.ToString();
        }

        public string GetPartTwoSolution()
        {
            decimal result = 0M;
            foreach (var expression in input)
            {
                var calculator = new AdvencedCalculator();
                result += calculator.Calculate(expression);
            }
            return result.ToString();
        }
    }
}
