using System;
using CardGames;
using System.Collections.Generic;

namespace GameOfWar
{
    class PlayGameOfWarRunner
    {
        private static DeckInteractor DeckInteractor;
        static void Main(string[] args)
        {
            DeckInteractor = new DeckInteractor();
            List<Card> gameDeck = DeckInteractor.GenerateDeck();
            DeckInteractor.Shuffle(gameDeck);

            GameOfWar gameState = new GameOfWar();

            gameState.P1Hand = gameDeck.GetRange(0, (gameDeck.Count / 2));
            gameState.P2Hand = gameDeck.GetRange(gameDeck.Count / 2, gameDeck.Count / 2);

            while (!(gameState.P1Hand.Count.Equals(0) || gameState.P2Hand.Count.Equals(0)))
            {

                gameState.P1CardInPlay = DeckInteractor.DrawTopCard(gameState.P1Hand);
                gameState.P2CardInPlay = DeckInteractor.DrawTopCard(gameState.P2Hand);
                gameState.WinnersPot = new List<Card>();
                Console.Write(DeckInteractor.GetRank(gameState.P1CardInPlay) + " of " + gameState.P1CardInPlay.Suit.ToString());
                Console.Write(" VS ");
                Console.Write(DeckInteractor.GetRank(gameState.P2CardInPlay) + " of " + gameState.P2CardInPlay.Suit.ToString());
                PlayRound(gameState);
                Console.WriteLine("");
            }

            if (gameState.P1Hand.Count.Equals(0))
            {
                Console.WriteLine("Player 2 wins game!");
            }
            else
            {
                Console.WriteLine("Player 1 wins game!");
            }
        }

        public static void PlayRound(GameOfWar game)
        {
            string winner = FindWinner(game.P1CardInPlay, game.P2CardInPlay);
            if (winner == "P1")
            {
                Console.Write(" Player 1 Wins!");
                game.WinnersPot.Add(game.P1CardInPlay);
                game.WinnersPot.Add(game.P2CardInPlay);
                game.P1Hand.AddRange(game.WinnersPot);
            }
            else if (winner == "P2")
            {
                Console.Write(" Player 2 Wins!");
                game.WinnersPot.Add(game.P1CardInPlay);
                game.WinnersPot.Add(game.P2CardInPlay);
                game.P2Hand.AddRange(game.WinnersPot);
            }
            else
            {
                Console.Write(" ITS A TIE!!!");
                game.WinnersPot.Add(game.P1CardInPlay);
                game.WinnersPot.Add(game.P2CardInPlay);
                for (int i = 0; i < 3; i++)
                {
                    game.WinnersPot.Add(DeckInteractor.DrawTopCard(game.P1Hand));
                    game.WinnersPot.Add(DeckInteractor.DrawTopCard(game.P2Hand));
                }
                game.P1CardInPlay = DeckInteractor.DrawTopCard(game.P1Hand);
                game.P2CardInPlay = DeckInteractor.DrawTopCard(game.P2Hand);
                PlayRound(game);
            }

        }

        public static string FindWinner(Card p1Card, Card p2Card)
        {
            if (p1Card.RankValue > p2Card.RankValue)
            {
                return "P1";
            }
            else if (p2Card.RankValue > p1Card.RankValue)
            {
                return "P2";
            }
            else
            {
                return "Tie";
            }
        }
    }
}
