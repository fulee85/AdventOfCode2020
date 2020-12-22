namespace AdventOfCode2020.Day22
{
    using System.Collections.Generic;
    using System.Linq;

    public class RecursiveGame
    {
        private readonly static Dictionary<string, Player> winners = new Dictionary<string, Player>(); 
        private string startSetup;

        private readonly Queue<int> player1Cards;
        private readonly Queue<int> player2Cards;
        private readonly HashSet<string> standings = new HashSet<string>();

        public RecursiveGame(Queue<int> player1cards, Queue<int> player2cards)
        {
            player1Cards = player1cards;
            player2Cards = player2cards;
        }

        public Player GetWinner()
        {
            startSetup = string.Join(',', player1Cards.Select(c => c.ToString())) + '#' + string.Join(',', player2Cards.Select(c => c.ToString()));
            if (winners.ContainsKey(startSetup))
            {
                return winners[startSetup];
            }
            while (player1Cards.Count > 0 && player2Cards.Count > 0)
            {
                var actualStanding = string.Join(',', player1Cards.Select(c => c.ToString())) + '#' + string.Join(',', player2Cards.Select(c => c.ToString()));
                if (standings.Contains(actualStanding))
                {
                    winners.Add(startSetup, Player.Player1);
                    return Player.Player1;
                }
                
                standings.Add(actualStanding);

                var player1Card = player1Cards.Dequeue();
                var player2Card = player2Cards.Dequeue();

                var winner = Player.None;
                if (player1Card <= player1Cards.Count && 
                    player2Card <= player2Cards.Count)
                {
                    var subGame = new RecursiveGame(
                        new Queue<int>(player1Cards.Take(player1Card)), 
                        new Queue<int>(player2Cards.Take(player2Card)));
                    winner = subGame.GetWinner();
                }
                else
                {
                    winner = player1Card > player2Card ? Player.Player1 : Player.Player2;
                }

                if (winner == Player.Player1)
                {
                    player1Cards.Enqueue(player1Card);
                    player1Cards.Enqueue(player2Card);
                }
                else
                {
                    player2Cards.Enqueue(player2Card);
                    player2Cards.Enqueue(player1Card);
                }

            }

            if (player1Cards.Count == 0)
            {
                winners.Add(startSetup, Player.Player2);
                return Player.Player2;
            }
            else
            {
                winners.Add(startSetup, Player.Player1);
                return Player.Player1;
            }
        }
    }
}
