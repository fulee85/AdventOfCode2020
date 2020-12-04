using AdventOfCode2020.Common;
using System;

namespace AdventOfCode2020
{
    public static class SolverFactory
    {
        public static ISolver GetSolver(int day)
        {
            return day switch
            {
                1 => new Day01.Solver(new Input<int>("01", int.Parse)),
                2 => new Day02.Solver(new Input<Day02.Password>("02", Day02.Password.Parse)),
                3 => new Day03.Solver(new Input<string>("03", s => s)),
                4 => new Day04.Solver(new Input<string>("04", s => s)),
                _ => throw new Exception()
            };
        }
    }
}
