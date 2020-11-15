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
    }
}