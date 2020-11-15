using System.Collections.Generic;

namespace CardPack
{
    public interface IShuffledCardPack
    {
        IReadOnlyList<Card> GetCards();
    }
}