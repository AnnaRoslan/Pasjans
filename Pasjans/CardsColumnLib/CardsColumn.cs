using System.Collections.Generic;
using CardPack;

namespace CardsColumnLib
{
    public class CardsColumn : ICardsColumn
    {
        private List<Card> _hiddenCards;
        private List<Card> _visibleCards;

        internal CardsColumn(List<Card> hiddenCards, List<Card> visibleCards)
        {
            _hiddenCards = hiddenCards;
            _visibleCards = visibleCards;
        }

        private CardsColumn()
        {
        }

        public List<Card> GetVisibleCards()
        {
            throw new System.NotImplementedException();
        }

        public List<Card> PeekTopVisibleCards(int n)
        {
            throw new System.NotImplementedException();
        }

        public List<Card> TakeTopVisibleCards(int n)
        {
            throw new System.NotImplementedException();
        }

        public void PutCards(List<Card> cards)
        {
            throw new System.NotImplementedException();
        }
    }
}