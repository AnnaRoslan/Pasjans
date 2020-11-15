using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Pasjans;

namespace NUnitTest
{
    class TableTest
    {
        private Table _table;
        
        [SetUp]
        public void SetUp()
        {
            _table = new Table(new Deck());
        }
        [Test]
        public void Is_Reserve_stock_have_24_cards_on_begining()
        {
            Assert.AreEqual(24, _table.ReserveStock.Count);
        }
        [Test]
        public void Is_Stock1__have_1_cards_on_begining()
        {
            Assert.AreEqual(1, _table.Stock1.Count);
        }
        [Test]
        public void Is_Stock7__have_7_cards_on_begining()
        {
            Assert.AreEqual(7, _table.Stock7.Count);
        }
    }
}
