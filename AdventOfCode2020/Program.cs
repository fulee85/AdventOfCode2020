using AdventOfCode2020.Common;
using System;
using System.Diagnostics;

namespace AdventOfCode2020
{
    static class Program
    {
        static void Main(string[] args)
        {
            var dayNumber = 23;

            Stopwatch stopwatch = new Stopwatch();
            ISolver solver = SolverFactory.GetSolver(dayNumber);

            stopwatch.Start();
            var partOneSolution = solver.GetPartOneSolution();
            stopwatch.Stop();
            var time1 = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Day {dayNumber} part one solution: {partOneSolution} solved in {time1} ms");
            stopwatch.Reset(); 

            stopwatch.Start();
            var partTwoSolution = solver.GetPartTwoSolution();
            stopwatch.Stop();
            var time2 = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Day {dayNumber} part two solution: {partTwoSolution} solved in {time2} ms");
        }
    }
}
