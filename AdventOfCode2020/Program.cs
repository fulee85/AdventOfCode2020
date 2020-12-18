using System;

namespace AdventOfCode2020
{
    static class Program
    {
        static void Main(string[] args)
        {
            var solver = SolverFactory.GetSolver(18);
            Console.WriteLine("First solution: " + solver.GetFirstSolution());
            Console.WriteLine("Second solution: " + solver.GetSecondSolution());
        }
    }
}
