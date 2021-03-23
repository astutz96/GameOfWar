﻿using System;

namespace CardGames
{

    public enum Suit
    {
        Clubs, Spades, Hearts, Diamonds
    }

    public class Card
    {

        private Suit _suit;
        private int _rankValue;

        public Card(Suit suit, int rankValue)
        {
            if (rankValue < 2 || rankValue > 14)
            {
                throw new ArgumentException("Invalid Rank Provided: " + rankValue.ToString());
            };

            this._suit = suit;
            this._rankValue = rankValue;
        }

        public int RankValue
        {
            get { return _rankValue; }
            set { _rankValue = value; }
        }

        public Suit Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        public override string ToString()
        {
            return GetRank() + " of " + _suit.ToString();
        }

        public string GetRank()
        {
            return RankValue switch
            {
                11 => "Jack",
                12 => "Queen",
                13 => "King",
                14 => "Ace",
                _ => RankValue.ToString()
            };
            // if (this.RankValue.Equals(11))
            // {
            //     return "Jack";
            // }
            // else if (this.RankValue.Equals(12))
            // {
            //     return "Queen";
            // }
            // else if (this.RankValue.Equals(13))
            // {
            //     return "King";
            // }
            // else if (this.RankValue.Equals(14))
            // {
            //     return "Ace";
            // }
            // else
            // {
            //     return this.RankValue.ToString();
            // }
        }

    }

}
