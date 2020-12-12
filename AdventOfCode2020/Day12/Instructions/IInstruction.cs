namespace AdventOfCode2020.Day12.Instructions
{
    using System;

    public interface IInstruction
    {
        public void Apply(Ship ship);
    }
}
