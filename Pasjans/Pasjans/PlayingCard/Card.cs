using System;
using System.Diagnostics;

namespace Pasjans.PlayingCard
{
    [Serializable]
    public class Card
    {
        public Color Color { get; }
        public CardValue CardValue { get; }
        public bool IsReversed { get; set; }

        public Card(CardValue value, Color color)
        {
            Color = color;
            CardValue = value;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Card)obj;
            return other.CardValue == CardValue && other.Color == Color && other.IsReversed == IsReversed;
        }

        public override string ToString()
        {
            var c = Color switch
            {
                Color.Club => "C",
                Color.Diamond =>"D",
                Color.Heart => "H",
                Color.Spade => "S"
            };

            var value = CardValue switch
            {
                CardValue.Ace => "A",
                CardValue.Jack=> "J",
                CardValue.Queen=> "Q",
                CardValue.King=> "K",
                _=> ((int)CardValue).ToString()
            };
            return IsReversed ? value+c : "██";
        }
    }
}