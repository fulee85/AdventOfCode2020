namespace AdventOfCode2020.Day24
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;

    public class Solver : ISolver
    {
        private readonly LobbyFloor lobbyFloor;
        public Solver(IEnumerable<Instruction> instructions)
        {
            lobbyFloor = new LobbyFloor();
            foreach (var instruction in instructions)
            {
                var tilePosition = TilePosition.Create(instruction);
                lobbyFloor.FlipTileInPosition(tilePosition);
            }
            
        }

        public string GetPartOneSolution()
        {
            return lobbyFloor.BlackTileCount.ToString();
        }

        public string GetPartTwoSolution()
        {
            for (int day = 0; day < 100; day++)
            {
                lobbyFloor.DoDailyFlips();
            }
            return lobbyFloor.BlackTileCount.ToString();
        }
    }
}
