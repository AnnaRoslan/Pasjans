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

        public override bool Equals(object? obj)
        {
            if ((obj == null) || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Card)obj;
            return other.CardValue == CardValue && other.Color == Color && other.IsReversed == IsReversed;
        }
    }
}