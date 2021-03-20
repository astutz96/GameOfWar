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
            List<Card> gameDeck = GenerateDeck();
            Shuffle(gameDeck);

            List<Card> p1Hand = gameDeck.GetRange(0, (gameDeck.Count / 2) - 1);
            List<Card> p2Hand = gameDeck.GetRange(gameDeck.Count / 2, gameDeck.Count / 2);

            Console.WriteLine("hi");

            while (!(p1Hand.Count.Equals(0) || p2Hand.Count.Equals(0)))
            {
                Card p1Card = DrawTopCard(p1Hand);
                Card p2Card = DrawTopCard(p2Hand);
                Console.Write(GetRank(p1Card) + " of " + Enum.GetName(typeof(Suit), p1Card.Suit));
                Console.Write(" VS ");
                Console.Write(GetRank(p2Card) + " of " + Enum.GetName(typeof(Suit), p2Card.Suit));
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

        private static List<Card> GenerateDeck()
        {
            List<Card> myCards = new List<Card>();

            for (int i = 2; i < 15; i++)
            {
                myCards.Add(new Card(Suit.Clubs, i));
                myCards.Add(new Card(Suit.Diamonds, i));
                myCards.Add(new Card(Suit.Hearts, i));
                myCards.Add(new Card(Suit.Spades, i));
            }
            return myCards;
        }

        private static string GetRank(Card card)
        {
            if (card.RankValue.Equals(11))
            {
                return "Jack";
            }
            else if (card.RankValue.Equals(12))
            {
                return "Queen";
            }
            else if (card.RankValue.Equals(13))
            {
                return "King";
            }
            else if (card.RankValue.Equals(14))
            {
                return "Ace";
            }
            else
            {
                return card.RankValue.ToString();
            }
        }

        private static Card DrawTopCard(List<Card> cards)
        {
            Card topCard;
            topCard = cards[0];
            cards.RemoveAt(0);
            return topCard;
        }

        private static void Shuffle(List<Card> cards)
        {
            //FisherYatesShuffle
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int x = rng.Next(n + 1);
                Card value = cards[x];
                cards[x] = cards[n];
                cards[n] = value;
            }
        }
    }
}
