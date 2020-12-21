using AdventOfCode2020.Common;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day08
{
    public class Solver : ISolver
    {
        private readonly List<Instruction> instructions;
        private readonly Computer computer;

        public Solver(IEnumerable<Instruction> inputs)
        {
            instructions = inputs.ToList();
            computer = new Computer();
        }

        public string GetPartOneSolution() => computer.Run(instructions).accumlator.ToString();

        public string GetPartTwoSolution()
        {
            for (int i = 0; i < instructions.Count; i++)
            {
                if (instructions[i].Operation == Computer.Instructions.nop)
                {
                    instructions[i].Operation = Computer.Instructions.jmp;
                    var (wasSuccessful, accumlator) = computer.Run(instructions);
                    if (wasSuccessful)
                    {
                        return accumlator.ToString();
                    }
                    instructions[i].Operation = Computer.Instructions.nop;
                }
                else if (instructions[i].Operation == Computer.Instructions.jmp)
                {
                    instructions[i].Operation = Computer.Instructions.nop;
                    var (wasSuccessful, accumlator) = computer.Run(instructions);
                    if (wasSuccessful)
                    {
                        return accumlator.ToString();
                    }
                    instructions[i].Operation = Computer.Instructions.jmp;
                }
            }
            return "";
        }
    }
}