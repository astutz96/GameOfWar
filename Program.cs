using System;
using CardGames;
using System.Collections.Generic;

namespace GameOfWar
{
    class PlayGameOfWar
    {
        static void Main(string[] args)
        {
            int p1RoundsWon = 0;
            int p2RoundsWon = 0;
            DeckInteractor deckInteractor = new DeckInteractor();
            List<Card> gameDeck = deckInteractor.GenerateDeck();
            deckInteractor.Shuffle(gameDeck);

            List<Card> p1Hand = gameDeck.GetRange(0, (gameDeck.Count / 2) - 1);
            List<Card> p2Hand = gameDeck.GetRange(gameDeck.Count / 2, gameDeck.Count / 2);

            while (!(p1Hand.Count.Equals(0) || p2Hand.Count.Equals(0)))
            {
                Card p1Card = deckInteractor.DrawTopCard(p1Hand);
                Card p2Card = deckInteractor.DrawTopCard(p2Hand);
                Console.Write(deckInteractor.GetRank(p1Card) + " of " + Enum.GetName(typeof(Suit), p1Card.Suit));
                Console.Write(" VS ");
                Console.Write(deckInteractor.GetRank(p2Card) + " of " + Enum.GetName(typeof(Suit), p2Card.Suit));
                if (p1Card.RankValue > p2Card.RankValue)
                {
                    p1RoundsWon++;
                    Console.Write(" Player 1 wins round!");
                    p1Hand.Add(p1Card);
                    p1Hand.Add(p2Card);
                }
                else if (p1Card.RankValue < p2Card.RankValue)
                {
                    p2RoundsWon++;
                    Console.Write(" Player 2 wins round!");
                    p2Hand.Add(p1Card);
                    p2Hand.Add(p2Card);
                }
                else
                {
                    p1RoundsWon++;
                    Console.Write("--- TIE ---");
                    p1Hand.Add(p1Card);
                    p1Hand.Add(p2Card);
                }
                Console.WriteLine("---");
            }

            if (p1Hand.Count.Equals(0))
            {
                Console.WriteLine("layer 2 wins! Total rounds won: " + p2RoundsWon.ToString());
            }
            else
            {
                Console.WriteLine("Player 1 wins! Total round won: " + p1RoundsWon.ToString());
            }
        }
    }
}
