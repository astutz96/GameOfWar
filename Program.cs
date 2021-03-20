using System;
using CardGames;
using System.Collections.Generic;

namespace GameOfWar
{
    class PlayGameOfWar
    {
        static void Main(string[] args)
        {
            List<Card> gameDeck = GenerateDeck();
            Shuffle(gameDeck);

            List<Card> p1Hand = gameDeck.GetRange(0, (gameDeck.Count / 2) - 1);
            List<Card> p2Hand = gameDeck.GetRange(gameDeck.Count / 2, gameDeck.Count / 2);

            Console.WriteLine("hi");

            // while (!(player1Deck.GetCards().Count.Equals(5) || player2Deck.GetCards().Count.Equals(5)))
            // {
            //     Card p1Card = player1Deck.DrawTopCard();
            //     Card p2Card = player2Deck.DrawTopCard();
            //     Console.Write(p1Card.GetRank() + " of " + p1Card.GetSuit());
            //     Console.Write(" VS ");
            //     Console.Write(p2Card.GetRank() + " of " + p2Card.GetSuit());
            //     if (p1Card.GetRankValue() > p2Card.GetRankValue())
            //     {
            //         p1RoundWinCount++;
            //         Console.Write(" Player 1 wins round!");
            //         player1Deck.AddCardToBottomOfDeck(p1Card);
            //         player1Deck.AddCardToBottomOfDeck(p2Card);
            //     }
            //     else if (p1Card.GetRankValue() < p2Card.GetRankValue())
            //     {
            //         p2RoundWinCount++;
            //         Console.Write(" Player 2 wins round!");
            //         player2Deck.AddCardToBottomOfDeck(p1Card);
            //         player2Deck.AddCardToBottomOfDeck(p2Card);
            //     }
            //     else
            //     {
            //         p1RoundWinCount++;
            //         Console.Write("--- TIE ---");
            //         player1Deck.AddCardToBottomOfDeck(p1Card);
            //         player1Deck.AddCardToBottomOfDeck(p2Card);
            //     }
            //     Console.WriteLine("---");
            // }

            // if (player1Deck.GetCards().Count.Equals(0))
            // {
            //     Console.WriteLine("layer 2 wins! Total rounds won: " + p1RoundWinCount.ToString());
            // }
            // else
            // {
            //     Console.WriteLine("Player 1 wins! Total round won: " + p2RoundWinCount.ToString());
            // }
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
