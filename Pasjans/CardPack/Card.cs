using System;

namespace CardPack
{
    public class Card
    {
        public CardColour CardColour { get; }
        public CardValue CardValue { get; }

        public Card(CardColour cardColour, CardValue cardValue)
        {
            CardColour = cardColour;
            CardValue = cardValue;
        }


        public override bool Equals(object obj)
        {
            if (!(obj is Card))
            {
                return false;
            }

            var other = (Card) obj;

            return other.CardColour == CardColour && other.CardValue == CardValue;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(CardColour, CardValue).GetHashCode();
        }
    }
}