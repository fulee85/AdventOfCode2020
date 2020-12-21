using System;

namespace AdventOfCode2020
{
    static class Program
    {
        static void Main(string[] args)
        {
            var solver = SolverFactory.GetSolver(21);
            Console.WriteLine("First solution: " + solver.GetPartOneSolution());
            Console.WriteLine("Second solution: " + solver.GetPartTwoSolution());
        }
    }
}
