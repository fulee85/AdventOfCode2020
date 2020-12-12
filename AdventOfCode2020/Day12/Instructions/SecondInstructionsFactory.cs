namespace AdventOfCode2020.Day12.Instructions
{
    using System;

    public class SecondInstructionsFactory : IInstructionsFactory
    {
        public IInstruction Create(string input)
        {
            char action = input[0];
            int value = int.Parse(input[1..]);
            return action switch
            {
                'N' => new MoveWaypointToDirection(Direction.North, value),
                'S' => new MoveWaypointToDirection(Direction.South, value),
                'E' => new MoveWaypointToDirection(Direction.East, value),
                'W' => new MoveWaypointToDirection(Direction.West, value),
                'L' => new Turn(Side.Left, value),
                'R' => new Turn(Side.Right, value),
                'F' => new MoveForvard(value),
                _ => null
            };
        }
    }
}
