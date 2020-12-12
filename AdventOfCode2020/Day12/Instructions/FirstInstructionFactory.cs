namespace AdventOfCode2020.Day12.Instructions
{
    using System;

    public class FirstInstructionFactory : IInstructionsFactory
    {
        public IInstruction Create(string input)
        {
            char action = input[0];
            int value = int.Parse(input[1..]);
            return action switch
            {
                'N' => new MoveShipToDirection(Direction.North, value),
                'S' => new MoveShipToDirection(Direction.South, value),
                'E' => new MoveShipToDirection(Direction.East, value),
                'W' => new MoveShipToDirection(Direction.West, value),
                'L' => new Turn(Side.Left, value),
                'R' => new Turn(Side.Right, value),
                'F' => new MoveForvard(value),
                _ => null
            };
        }
    }
}
