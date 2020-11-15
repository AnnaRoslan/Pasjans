using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NUnit.Framework;
using Pasjans;

namespace NUnitTest
{
    class CardTest
    {
        [Test]
        public void Create_Card()
        {
            var color = Color.Club;
            var value = CardValue.Two;
            var card = new Card(value, color);
            Assert.AreEqual(card.CardValue, value);

        }
    }
}
