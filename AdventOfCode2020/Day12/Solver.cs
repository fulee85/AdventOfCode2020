namespace AdventOfCode2020.Day12
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day12.Instructions;
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
            var instructionFactory = new FirstInstructionFactory();
            var ship = new Ship(new DirectionVector(1,0));
            foreach (var instruction in input.Select(instructionFactory.Create))
            {
                instruction.Apply(ship);
            }
            return ship.GetManhattanDistance().ToString();
        }

        public string GetPartTwoSolution()
        {
            var instructionFactory = new SecondInstructionsFactory();
            var ship = new Ship(new DirectionVector(10, 1));
            foreach (var instruction in input.Select(instructionFactory.Create))
            {
                instruction.Apply(ship);
            }
            return ship.GetManhattanDistance().ToString();
        }
    }
}
