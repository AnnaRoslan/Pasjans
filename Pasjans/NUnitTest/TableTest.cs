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
            _table = new Table();
        }
        [Test]
        public void Is_Reserve_stock_have_24_cards_on_begining()
        {
            Assert.AreEqual(_table.ReserveStock.Count,24);

        }
    }
}
