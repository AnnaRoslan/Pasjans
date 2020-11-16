using System;
using System.Collections.Generic;
using System.Reflection;
using CardPack;
using CardsColumnLib;
using FluentAssertions;
using Xunit;

namespace CardsColumnLibTests
{
    public class CardsColumnTests
    {
        private readonly CardsColumn _cardsColumn;

        public CardsColumnTests()
        {
            var cardPack = new List<Card>
            {
                new Card(CardColour.Club, CardValue.Ace),
                new Card(CardColour.Diamond, CardValue.Eight),
                new Card(CardColour.Heart, CardValue.Five),
                new Card(CardColour.Spade, CardValue.Jack),
                new Card(CardColour.Club, CardValue.Ten)
            };

            //TODO change to parametrized constructor
            var cardsColumn = Activator.CreateInstance(typeof(CardsColumn), true);

            var hiddenCardsProperty = cardsColumn?.GetType()
                .GetField("_hiddenCards", BindingFlags.NonPublic | BindingFlags.Instance);
            hiddenCardsProperty?.SetValue(cardsColumn, cardPack.GetRange(0, 3));

            var visibleCardsProperty = cardsColumn?.GetType()
                .GetField("_visibleCards", BindingFlags.NonPublic | BindingFlags.Instance);
            visibleCardsProperty?.SetValue(cardsColumn, cardPack.GetRange(3, 2));

            _cardsColumn = (CardsColumn) cardsColumn;
        }

        [Fact]
        public void CardsColumn_GetVisibleCards_ReturnProperValue_Test()
        {
            var result = _cardsColumn.GetVisibleCards();
            result.Should().BeEquivalentTo(new List<Card>
            {
                new Card(CardColour.Spade, CardValue.Jack),
                new Card(CardColour.Club, CardValue.Ten)
            });
        }
    }
}