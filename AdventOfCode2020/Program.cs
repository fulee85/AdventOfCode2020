using System;

namespace AdventOfCode2020
{
    static class Program
    {
        static void Main(string[] args)
        {
            var solution = SolverFactory.GetSolver(7);
            Console.WriteLine("First solution: " + solution.GetFirstSolution());
            Console.WriteLine("Second solution: " + solution.GetSecondSolution());
        }
    }
}
