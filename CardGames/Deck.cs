using System;
using System.Collections.Generic;

namespace CardGames
{
    public class Deck
    {
        private List<Card> cards;
        public Deck()
        {
            cards = GenerateCards();
        }

        public List<Card> GetCards()
        {
            return cards;
        }

        public void Shuffle()
        {
            //Fisher Yates Shuffle
        }

        private List<Card> GenerateCards()
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

    }

}