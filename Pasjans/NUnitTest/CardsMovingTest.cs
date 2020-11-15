using System;
using System.Collections.Generic;
using NUnit.Framework;
using Pasjans;
using Pasjans.PlayingCard;

namespace NUnitTest
{
    public class CardsMovingTest
    {
        private Table _table;
        private CardMover _cardMover;

        [SetUp]
        public void SetUp()
        {
            _table = new Table();
            _cardMover = new CardMover();
            MockTable();
        }

        private void MockTable()
        {
            _table.Stock1.Add(new Card(CardValue.Two, Color.Heart) {IsReversed = true});
            _table.Stock2.Add(new Card(CardValue.Three, Color.Spade) {IsReversed = true});
            _table.Stock3.Add(new Card(CardValue.Four, Color.Club) {IsReversed = true});
            _table.Stock4.Add(new Card(CardValue.Two, Color.Diamond) {IsReversed = false});
            _table.Stock5.Add(new Card(CardValue.Five, Color.Diamond) {IsReversed = true});
            _table.Stock5.Add(new Card(CardValue.Four, Color.Spade) {IsReversed = true});
            _table.Stock6.Add(new Card(CardValue.Three, Color.Diamond) {IsReversed = true});
            _table.Stock6.Add(new Card(CardValue.Two, Color.Spade) {IsReversed = true});
            _table.Stock7.Add(new Card(CardValue.Four, Color.Club) {IsReversed = true});
        }

        [Test]
        public void TryMovingFromNonExistingStock()
        {
            Assert.Throws(typeof(ArgumentException),
                () => _cardMover.MoveCard(_table, -1, 2, new Card(CardValue.Ace, Color.Diamond)));
            Assert.Throws(typeof(ArgumentException),
                () => _cardMover.MoveCard(_table, 0, 2, new Card(CardValue.Ace, Color.Diamond)));
            Assert.Throws(typeof(ArgumentException),
                () => _cardMover.MoveCard(_table, 8, 2, new Card(CardValue.Ace, Color.Diamond)));
        }

        [Test]
        public void TryMovingToNonExistingStock()
        {
            Assert.Throws(typeof(ArgumentException),
                () => _cardMover.MoveCard(_table, 1, -1, new Card(CardValue.Two, Color.Heart)));
            Assert.Throws(typeof(ArgumentException),
                () => _cardMover.MoveCard(_table, 1, 0, new Card(CardValue.Two, Color.Heart)));
            Assert.Throws(typeof(ArgumentException),
                () => _cardMover.MoveCard(_table, 1, 8, new Card(CardValue.Two, Color.Heart)));
        }

        [Test]
        public void TryMoveNonExistingInStockCard()
        {
            Assert.Throws(typeof(ArgumentException),
                () => _cardMover.MoveCard(_table, 1, 2, new Card(CardValue.Ace, Color.Diamond)));
        }

        [Test]
        public void TryMovingReversedCard()
        {
            Assert.Throws(typeof(ArgumentException),
                () => _cardMover.MoveCard(_table, 4, 2, new Card(CardValue.Two, Color.Diamond)));
        }

        [Test]
        public void TryMovingHigherOnLower()
        {
            Assert.Throws(typeof(ArgumentException),
                () => _cardMover.MoveCard(_table, 2, 1, new Card(CardValue.Three, Color.Spade)));
        }

        [Test]
        public void TryMovingOnSameColor()
        {
            Assert.Throws(typeof(ArgumentException),
                () => _cardMover.MoveCard(_table, 2, 3, new Card(CardValue.Three, Color.Spade)));
        }
    }
}