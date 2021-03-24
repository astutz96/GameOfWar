using System;

namespace CardGames
{
    public enum Suit
    {
        Clubs, Spades, Hearts, Diamonds
    }

    public class Card
    {
        public Suit Suit { get; set; }
        public int RankValue { get; set; }

        public Card(Suit suit, int rankValue)
        {
            if (rankValue < 2 || rankValue > 14)
            {
                throw new ArgumentException("Invalid Rank Provided: " + rankValue.ToString());
            };

            this.Suit = suit;
            this.RankValue = rankValue;
        }

        public override string ToString()
        {
            return GetRank() + " of " + Suit.ToString();
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
        }
    }
}
