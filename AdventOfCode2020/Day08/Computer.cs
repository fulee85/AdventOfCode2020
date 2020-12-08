using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day08
{
    public class Computer
    {
        public static class Instructions
        {
            public const string nop = "nop";
            public const string acc = "acc";
            public const string jmp = "jmp";
        }

        private int accumlator = 0;
        private int instructionPointer = 0;
        private HashSet<int> runnedInstructions = new HashSet<int>();

        public (bool wasSuccessful, int accumlator) Run(List<Instruction> instructions)
        {
            Init();
            while (!runnedInstructions.Contains(instructionPointer) && 0 <= instructionPointer && instructionPointer < instructions.Count)
            {
                runnedInstructions.Add(instructionPointer);
                Execute(instructions[instructionPointer]);
            }
            return (instructionPointer == instructions.Count, accumlator);
        }

        private void Init()
        {
            instructionPointer = 0;
            accumlator = 0;
            runnedInstructions = new HashSet<int>();
        }

        private void Execute(Instruction instruction)
        {
            switch (instruction.Operation)
            {
                case Instructions.nop: NoOperation();
                    break;
                 case Instructions.acc: Acc(instruction.Parameter);
                    break;
                case Instructions.jmp: Jump(instruction.Parameter);
                    break;
            }
        }

        private void Jump(int parameter)
        {
            instructionPointer += parameter;
        }

        private void Acc(int parameter)
        {
            accumlator += parameter;
            instructionPointer++;
        }

        private void NoOperation()
        {
            instructionPointer++;
        }
    }
}
