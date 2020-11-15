using System;
using System.Collections.Generic;
using System.Reflection;
using CardPack;
using FluentAssertions;
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

        [Fact]
        public void CardsColumnFactory_Create_ThrowArgumentException_ColumnCapacityBiggerThanCardPackLength_Test()
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    var cardPack = new List<Card> {new Card(CardColour.Club, CardValue.Ace)};

                    var factory = new CardsColumnFactory();
                    factory.Create(cardPack, 2);
                }
            );
        }

        [Fact]
        public void CardsColumnFactory_Create_ReturnProperCardsColumn_Test()
        {
            var cardPack = new List<Card>
            {
                new Card(CardColour.Club, CardValue.Ace),
                new Card(CardColour.Diamond, CardValue.Eight),
                new Card(CardColour.Heart, CardValue.Five),
                new Card(CardColour.Spade, CardValue.Jack)
            };

            var expectedHiddenCards = cardPack.GetRange(0, 3);
            var expectedVisibleCards = cardPack.GetRange(3, 1);

            var hiddenCardsProperty =
                typeof(CardsColumn).GetField("_hiddenCards", BindingFlags.NonPublic | BindingFlags.Instance);
            var visibleCardsProperty =
                typeof(CardsColumn).GetField("_visibleCards", BindingFlags.NonPublic | BindingFlags.Instance);

            var factory = new CardsColumnFactory();
            var cardsColumn = factory.Create(cardPack, 4);

            hiddenCardsProperty.GetValue(cardsColumn).Should().BeEquivalentTo(expectedHiddenCards);
            visibleCardsProperty.GetValue(cardsColumn).Should().BeEquivalentTo(expectedVisibleCards);
            cardPack.Should().BeEmpty();
        }
    }
}