using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Pasjans;

namespace NUnitTest
{
    class DeckTest
    {
        private Deck deck;
        [SetUp]
        public void setUp()
        {
            deck = new Deck();
        }
        [Test]
        public void Is_deck_have_52_cards()
        {
            Assert.AreEqual(deck.DeckCards.Count,52);
        }

        [Test]
        public void Is_deck_have_13_cards_of_oe_color()
        {
            var oneColor = deck.DeckCards.Where(x => x.Color == Color.Club).ToList().Count;
            Assert.Equals(oneColor, 13);
        }
    }
}
