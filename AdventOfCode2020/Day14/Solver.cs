namespace AdventOfCode2020.Day14
{
    using AdventOfCode2020.Common;
    using System.Collections.Generic;
    using System.Linq;

    public class Solver : ISolver
    {
        private readonly List<string> input;

        public Solver(IEnumerable<string> input)
        {
            this.input = input.ToList();
        }
        public string GetFirstSolution()
        {
            var portComputer = new PartOne.PortComputer();
            input.ForEach(portComputer.ProcessInstruction);
            return portComputer.GetMemorySum().ToString();
        }

        public string GetSecondSolution()
        {
            var portComputer = new PartTwo.PortComputer();
            input.ForEach(portComputer.ProcessInstruction);
            return portComputer.GetMemorySum().ToString();
        }
    }
}
