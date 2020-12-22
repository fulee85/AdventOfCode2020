namespace AdventOfCode2020.Day22
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class InputParser
    {
        public static ParsedInput Parse(IEnumerable<string> input)
        {
            var player1Cards = input.TakeWhile(s => !string.IsNullOrWhiteSpace(s)).Skip(1).Select(int.Parse);
            var player2Cards = input.SkipWhile(s => !string.IsNullOrWhiteSpace(s)).Skip(2).Select(int.Parse);
            return new ParsedInput { Player1Cards = player1Cards, Player2Cards = player2Cards };
        }
    }
}
