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
    }
}