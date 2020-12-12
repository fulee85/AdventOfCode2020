namespace AdventOfCode2020.Day12.Instructions
{
    using System;

    public interface IInstructionsFactory
    {
        IInstruction Create(string input);
    }
}
