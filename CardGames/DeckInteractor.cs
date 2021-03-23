using System;
using System.Collections.Generic;

namespace CardGames
{
    public class DeckInteractor
    {
        public List<Card> GenerateDeck()
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

        public Card DrawTopCard(List<Card> cards)
        {
            Card topCard;
            topCard = cards[0];
            cards.RemoveAt(0);
            return topCard;
        }

        public List<Card> Shuffle(List<Card> cards)
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
            return cards;
        }
    }
}

