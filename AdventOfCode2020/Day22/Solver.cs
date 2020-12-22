namespace AdventOfCode2020.Day22
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;

    public class Solver : ISolver
    {
        private readonly ParsedInput parsedInput;

        public Solver(IEnumerable<string> input)
        {
            parsedInput = InputParser.Parse(input);
        }

        public string GetPartOneSolution()
        {
            var player1cards = new Queue<int>(parsedInput.Player1Cards);
            var player2cards = new Queue<int>(parsedInput.Player2Cards);
            while (player1cards.Count > 0 && player2cards.Count > 0)
            {
                var player1Card = player1cards.Dequeue();
                var player2Card = player2cards.Dequeue();
                if (player1Card > player2Card)
                {
                    player1cards.Enqueue(player1Card);
                    player1cards.Enqueue(player2Card);
                }
                else
                {
                    player2cards.Enqueue(player2Card);
                    player2cards.Enqueue(player1Card);
                }
            }
            var winnerCards = player1cards.Count > 0 ? player1cards : player2cards;

            return GetResult(winnerCards);
        }

        public string GetPartTwoSolution()
        {
            var player1cards = new Queue<int>(parsedInput.Player1Cards);
            var player2cards = new Queue<int>(parsedInput.Player2Cards);
            var recursiveGame = new RecursiveGame(player1cards, player2cards);
            var winner = recursiveGame.GetWinner();
            var winnerCards = winner == Player.Player1 ? player1cards : player2cards;

            return GetResult(winnerCards);
        }

        private string GetResult(Queue<int> winnerCards)
        {
            var result = 0;
            while (winnerCards.Count > 0)
            {
                var multiplier = winnerCards.Count;
                var card = winnerCards.Dequeue();
                result += card * multiplier;
            }
            return result.ToString();
        }
    }
}
