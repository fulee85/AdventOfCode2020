using AdventOfCode2020.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day01
{
    /// <summary>
    /// https://adventofcode.com/2020/day/1
    /// </summary>
    public class Solver : ISolver
    {
        private readonly HashSet<int> numbers = new HashSet<int>();

        public Solver(IEnumerable<int> input)
        {
            this.numbers = input.ToHashSet();
        }

        public string GetFirstSolution()
        {
            int goal = 2020;
            foreach (var item in numbers)
            {
                if (numbers.Contains(goal-item))
                {
                    return (item * (goal - item)).ToString();
                }
            }
            return "No solution!";
        }

        public string GetSecondSolution()
        {
            int goal = 2020;
            foreach (var item1 in numbers)
            {
                foreach (var item2 in numbers)
                {
                    var item3 = goal - item1 - item2;
                    if (numbers.Contains(item3))
                    {
                        return (item1 * item2 * item3).ToString();
                    }
                }
            }
            return "No solution!";
        }
    }
}
