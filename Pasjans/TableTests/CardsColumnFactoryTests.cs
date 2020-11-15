using System;
using System.Collections.Generic;
using CardPack;
using Table;
using Xunit;

namespace TableTests
{
    public class CardsColumnFactoryTests
    {
        [Fact]
        public void CardsColumnFactory_Create_ThrowArgumentException_NullCardPackArgument_Test()
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    var factory = new CardsColumnFactory();
                    factory.Create(null, 1);
                }
            );
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void CardsColumnFactory_Create_ThrowArgumentException_ZeroOrLessColumnCapacityArgument_Test(
            int columnCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    var cardPack = new List<Card>();

                    var factory = new CardsColumnFactory();
                    factory.Create(cardPack, columnCapacity);
                }
            );
        }
    }
}