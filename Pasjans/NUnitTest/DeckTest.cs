using System;
using System.Collections.Generic;
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
    }
}
