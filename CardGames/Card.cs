using System;

namespace CardGames
{

    public enum Suit
    {
        Clubs, Spades, Hearts, Diamonds
    }

    public class Card
    {

        private Suit suit;
        private int rank;

        public Card(Suit suit, int rank)
        {
            if (rank < 2 || rank > 14)
            {
                throw new ArgumentException("Invalid Rank Provided: " + rank.ToString());
            };

            this.suit = suit;
            this.rank = rank;
        }

        public int GetRankValue()
        {
            return rank;
        }

        public string GetRank()
        {
            if (rank.Equals(11))
            {
                return "Jack";
            }
            else if (rank.Equals(12))
            {
                return "Queen";
            }
            else if (rank.Equals(13))
            {
                return "King";
            }
            else if (rank.Equals(14))
            {
                return "Ace";
            }
            else
            {
                return rank.ToString();
            }
        }

        public string GetSuit()
        {
            return Enum.GetName(typeof(Suit), this.suit);
        }

    }
}
