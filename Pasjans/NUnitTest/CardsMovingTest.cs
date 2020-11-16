﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            _table.Stock1.Add(new Card(CardValue.Ace, Color.Diamond) {IsReversed = false});
            _table.Stock1.Add(new Card(CardValue.Two, Color.Heart) {IsReversed = true});
            _table.Stock2.Add(new Card(CardValue.Three, Color.Spade) {IsReversed = true});
            _table.Stock3.Add(new Card(CardValue.Four, Color.Club) {IsReversed = true});
            _table.Stock4.Add(new Card(CardValue.Two, Color.Diamond) {IsReversed = false});
            _table.Stock5.Add(new Card(CardValue.Five, Color.Diamond) {IsReversed = true});
            _table.Stock5.Add(new Card(CardValue.Four, Color.Spade) {IsReversed = true});
            _table.Stock6.Add(new Card(CardValue.Three, Color.Diamond) {IsReversed = true});
            _table.Stock6.Add(new Card(CardValue.Two, Color.Spade) {IsReversed = true});
            _table.Stock7.Add(new Card(CardValue.Three, Color.Diamond) { IsReversed = true });
            _table.Stock7.Add(new Card(CardValue.Four, Color.Club) {IsReversed = true});

            _table.ReserveStock.Add(new Card(CardValue.Three, Color.Heart) { IsReversed = false });
            _table.ReserveStock.Add(new Card(CardValue.Two, Color.Heart) { IsReversed = true });
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

        [Test]
        public void MoveOneCardTest()
        {
            _cardMover.MoveCard(_table, 1, 2, new Card(CardValue.Two, Color.Heart));
            Assert.AreEqual(1, _table.Stock1.Count);
            Assert.AreEqual(new Card(CardValue.Two, Color.Heart) { IsReversed = true }, _table.Stock2[1]);
        }

        [Test]
        public void MoveMultipleCardsTest()
        {
            _cardMover.MoveCard(_table, 6, 7, new Card(CardValue.Three, Color.Diamond));
            Assert.AreEqual(0, _table.Stock6.Count);
            Assert.AreEqual(4, _table.Stock7.Count);
            Assert.AreEqual(new Card(CardValue.Three, Color.Diamond) { IsReversed = true }, _table.Stock7[0]);
            Assert.AreEqual(new Card(CardValue.Four, Color.Club) { IsReversed = true }, _table.Stock7[1]);
            Assert.AreEqual(new Card(CardValue.Three, Color.Diamond) { IsReversed = true }, _table.Stock7[2]);
            Assert.AreEqual(new Card(CardValue.Two, Color.Spade) { IsReversed = true }, _table.Stock7[3]);
        }

        [Test]
        public void TryMovingMultipleWithWrongOrder()
        {
            Assert.Throws(typeof(ArgumentException),
                () => _cardMover.MoveCard(_table, 7, 5, new Card(CardValue.Three, Color.Diamond)));
        }

        [Test]
        public void TestMovingNotReversedFromReserveStock()
        {
            Assert.Throws(typeof(ArgumentException), () => _cardMover.MoveCard(_table, 0, 3,
                new Card(CardValue.Three, Color.Heart) {IsReversed = false}));
        }

        [Test]
        public void TestMovingFromReserveStock()
        {
            _cardMover.MoveCard(_table, 0, 2, new Card(CardValue.Two, Color.Heart) {IsReversed = true});
            Assert.AreEqual(1, _table.ReserveStock.Count);
            Assert.AreEqual(new Card(CardValue.Two, Color.Heart) { IsReversed = true }, _table.Stock2[1]);
        }

        [Test]
        public void TestReversingAfterMove()
        {
            Assert.AreEqual(false, _table.Stock1[0].IsReversed);
            _cardMover.MoveCard(_table, 1, 2, new Card(CardValue.Two, Color.Heart));
            Assert.AreEqual(1, _table.Stock1.Count);
            Assert.AreEqual(new Card(CardValue.Two, Color.Heart) { IsReversed = true }, _table.Stock2[1]);
            Assert.AreEqual(true, _table.Stock1[0].IsReversed);
        }

        [Test]
        public void TestMoveToFinal()
        {
            _table.Stock1.Clear();
            Assert.AreEqual(0, _table.Stock1.Count);
            Assert.AreEqual(0, _table.FinalStock1.Count);
            for (var i = 12; i > 0; i--)
            {
                _table.Stock1.Add(new Card((CardValue)i, (Color)(i % 2)) {IsReversed = true});
            }
            Assert.AreEqual(12, _table.Stock1.Count);
            _table.Stock2.Clear();
            Assert.AreEqual(0, _table.Stock2.Count);
            _table.Stock2.Add(new Card(CardValue.King, Color.Club) {IsReversed = true});
            Assert.AreEqual(1, _table.Stock2.Count);
            _cardMover.MoveCard(_table, 1, 2, new Card(CardValue.Queen, Color.Heart));
            Assert.AreEqual(0, _table.Stock1.Count);
            Assert.AreEqual(13, _table.FinalStock1.Count);
        }

        [Test]
        public void TestGettingNewCardFromReserve()
        {
            _table = new Table(new Deck());
            var initReserveStockLength = _table.ReserveStock.Count;
            for (var i = 0; i < 24; i++)
            {
                var lastCard = _table.ReserveStock.Last();
                var prevLastCard = _table.ReserveStock[^2];
                _cardMover.MoveCard(_table, 0, 0, null);
                Assert.AreEqual(initReserveStockLength, _table.ReserveStock.Count);
                Assert.AreEqual(true, _table.ReserveStock.Last().IsReversed);
                Assert.AreEqual(true, _table.ReserveStock.GetRange(0, _table.ReserveStock.Count - 1).All(x => x.IsReversed == false));
                Assert.AreEqual(lastCard, _table.ReserveStock[0]);
                Assert.AreEqual(prevLastCard, _table.ReserveStock.Last());
            }
        }
    }
}