using System;
using System.Collections.Generic;
using System.Linq;

namespace CardPack
{
    public class ShuffledCardPack : IShuffledCardPack
    {
        public IReadOnlyList<Card> GetCards()
        {
            const int cardsNumberInPack = 52;

            var defaultPack = DefaultPack.Get();
            var random = new Random();

            var pack = new HashSet<Card>();
            while (pack.Count < cardsNumberInPack)
            {
                pack.Add(defaultPack[random.Next(cardsNumberInPack)]);
            }

            return pack.ToList();
        }
    }
}