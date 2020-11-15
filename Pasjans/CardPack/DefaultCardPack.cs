using System.Collections.Generic;

namespace CardPack
{
    public static class DefaultCardPack
    {
        private const int ColoursNumber = 4;
        private const int ValuesNumber = 13;

        public static IReadOnlyList<Card> GetCards()
        {
            var pack = new List<Card>();

            for (var colourIndex = 0; colourIndex < ColoursNumber; colourIndex++)
            {
                for (var valueIndex = 0; valueIndex < ValuesNumber; valueIndex++)
                {
                    pack.Add(new Card((CardColour) colourIndex, (CardValue) valueIndex));
                }
            }

            return pack;
        }
    }
}