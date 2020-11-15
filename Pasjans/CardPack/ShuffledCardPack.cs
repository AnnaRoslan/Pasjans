using System.Collections.Generic;

namespace CardPack
{
    public class ShuffledCardPack : IShuffledCardPack
    {
        public IReadOnlyList<Card> GetCards()
        {
            var defaultPack = DefaultPack.Get();

            return defaultPack;
        }
    }
}