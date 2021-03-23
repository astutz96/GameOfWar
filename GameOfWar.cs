using System;
using CardGames;
using System.Collections.Generic;
using System.Linq;

namespace GameOfWar
{
    class PlayGameOfWarRunner
    {
        private static DeckInteractor DeckInteractor;
        static void Main(string[] args)
        {
            DeckInteractor = new DeckInteractor();
            List<Card> gameDeck = DeckInteractor.GenerateDeck();
            gameDeck = DeckInteractor.Shuffle(gameDeck);

            GameOfWar gameState = new GameOfWar();

            gameState.P1Hand = gameDeck.GetRange(0, (gameDeck.Count / 2));
            gameState.P2Hand = gameDeck.GetRange(gameDeck.Count / 2, gameDeck.Count / 2);

            while (PlayersStillHaveCards(gameState))
            {
                gameState.P1CardInPlay = DeckInteractor.DrawTopCard(gameState.P1Hand);
                gameState.P2CardInPlay = DeckInteractor.DrawTopCard(gameState.P2Hand);
                gameState.WinnersPot = new List<Card>();
                DisplayMatchup(gameState);
                PlayRound(gameState);
                Console.WriteLine("");
            }

            DisplayWinner(gameState);
        }

        private static void DisplayWinner(GameOfWar gameState)
        {
            if (gameState.P1Hand.Any())
            {
                Console.WriteLine("Player 1 wins game!");
            }
            else
            {
                Console.WriteLine("Player 2 wins game!");
            }
        }

        private static void DisplayMatchup(GameOfWar gameState)
        {
            Console.Write(gameState.P1CardInPlay);
            Console.Write(" VS ");
            Console.Write(gameState.P2CardInPlay);
        }

        private static bool PlayersStillHaveCards(GameOfWar gameState)
        {
            return gameState.P1Hand.Any() && gameState.P2Hand.Any();
        }

        public static void PlayRound(GameOfWar game)
        {
            string winner = FindRoundWinner(game.P1CardInPlay, game.P2CardInPlay);
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
                int tieCounter = 0;
                Console.WriteLine(" IT'S A TIE!!!");
                game.WinnersPot.Add(game.P1CardInPlay);
                game.WinnersPot.Add(game.P2CardInPlay);

                while (!EitherPlayerOnlyHasOneCardLeft(game) && tieCounter < 3)
                {
                    game.WinnersPot.Add(DeckInteractor.DrawTopCard(game.P1Hand));
                    game.WinnersPot.Add(DeckInteractor.DrawTopCard(game.P2Hand));
                    tieCounter++;
                }
                game.P1CardInPlay = DeckInteractor.DrawTopCard(game.P1Hand);
                game.P2CardInPlay = DeckInteractor.DrawTopCard(game.P2Hand);
                PlayRound(game);
            }

        }

        private static bool EitherPlayerOnlyHasOneCardLeft(GameOfWar game)
        {
            return ((game.P1Hand.Count < 2) || (game.P2Hand.Count < 2));
        }

        public static string FindRoundWinner(Card p1Card, Card p2Card)
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
