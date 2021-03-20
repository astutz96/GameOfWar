﻿using System;

namespace CardGames
{

    public enum Suit
    {
        Clubs, Spades, Hearts, Diamonds
    }

    public class Card
    {

        private Suit suit;
        private int rankValue;

        public int RankValue
        {
            get { return rankValue; }
            set { rankValue = value; }
        }

        public Suit Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        public Card(Suit suit, int rankValue)
        {
            if (rankValue < 2 || rankValue > 14)
            {
                throw new ArgumentException("Invalid Rank Provided: " + rankValue.ToString());
            };

            this.suit = suit;
            this.rankValue = rankValue;
        }

        public String Print()
        {
            return rankValue.ToString() + " of " + suit.ToString();
        }

    }

}
