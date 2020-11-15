using System.Diagnostics;

namespace Pasjans.PlayingCard
{
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