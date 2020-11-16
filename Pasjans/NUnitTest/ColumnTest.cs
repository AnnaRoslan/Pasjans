using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NUnit.Framework;
using Pasjans;
using Pasjans.PlayingCard;

namespace NUnitTest
{

    class ColumnTest
    {
        private Table _table;
        private Column _column;
        private int _colIndex;
        List<Card> someRange;

        [SetUp]
        public void setUp()
        {
            someRange = new List<Card> { };
            _colIndex = 3;
            _table = new Table();
            _column = new Column(_colIndex, _table);

        }

        [Test]
        public void isDeleteable_ShouldReturnFalse_IfSomeCardFromsomeRange_IsReversed()
        {
            someRange.Add(new Card(CardValue.Ace, Color.Club));
            someRange.Add(new Card(CardValue.Two, Color.Club));
            someRange[0].IsReversed = true;

            Assert.False(_column.isDeleteable(someRange));
        }

        [Test]
        public void isDeletable_ShouldReturnFalse_IfColorsDoesntMatch()
        {
            someRange.Add(new Card(CardValue.Ace, Color.Club));
            someRange.Add(new Card(CardValue.Three, Color.Diamond));
            someRange.Add(new Card(CardValue.Ace, Color.Heart));
            someRange.Add(new Card(CardValue.Three, Color.Spade));

            Assert.False(_column.isDeleteable(someRange));
        }

        [Test]
        public void isDeletable_ShouldReturnFalse_IfGapBetweenElements_IsMoreThanOne()
        {
            someRange.Add(new Card(CardValue.Ace, Color.Club));
            someRange.Add(new Card(CardValue.Six, Color.Club));
            someRange.Add(new Card(CardValue.Jack, Color.Club));
            someRange.Add(new Card(CardValue.King, Color.Club));

            Assert.False(_column.isDeleteable(someRange));
        }

        [Test]
        public void isDeletable_ShouldReturnTrue_IfsomeRange_IsInAppropriateFormat()
        {

            someRange.Add(new Card(CardValue.Ace, Color.Club));
            someRange.Add(new Card(CardValue.Two, Color.Club));
            someRange.Add(new Card(CardValue.Three, Color.Club));
            someRange.Add(new Card(CardValue.Four, Color.Club));

            Assert.True(_column.isDeleteable(someRange));
        }

        [Test]
        public void checkConclusion_ShouldReturnDoubleFalse_IfLengthOfSomeRange_IsLessThanThirteen()
        {
            _column.possibleCards.Add(new Card(CardValue.Two, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Three, Color.Club));

            Assert.False(_column.checkConclusion(_table)[0]);
            Assert.False(_column.checkConclusion(_table)[1]);
        }

        [Test]
        public void checkConclusion_SHouldReturnFalseAndTrue_IfsomeRangeIsDeletable_AndSizeHigherThanThirteen()
        {
            _column.possibleCards.Add(new Card(CardValue.Ace, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Two, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Three, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Four, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Five, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Six, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Seven, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Eight, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Nine, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Ten, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Jack, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Queen, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.King, Color.Club));

            List<bool> resBool = _column.checkConclusion(_table);

            Assert.True(resBool[0]);
            Assert.False(resBool[1]);

        }

        [Test]
        public void checkConclusion_ShouldReturnDoubleTrue_IfsomeRangeIsDeletable_HigherThanThirteen_AndLastRange()
        {
            someRange.Add(new Card(CardValue.Ace, Color.Club));
            someRange.Add(new Card(CardValue.Two, Color.Club));
            someRange.Add(new Card(CardValue.Three, Color.Club));
            someRange.Add(new Card(CardValue.Four, Color.Club));
            someRange.Add(new Card(CardValue.Five, Color.Club));
            someRange.Add(new Card(CardValue.Six, Color.Club));
            someRange.Add(new Card(CardValue.Seven, Color.Club));
            someRange.Add(new Card(CardValue.Eight, Color.Club));
            someRange.Add(new Card(CardValue.Nine, Color.Club));
            someRange.Add(new Card(CardValue.Ten, Color.Club));
            someRange.Add(new Card(CardValue.Jack, Color.Club));
            someRange.Add(new Card(CardValue.Queen, Color.Club));
            someRange.Add(new Card(CardValue.King, Color.Club));

            _column.possibleCards.Add(new Card(CardValue.Ace, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Two, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Three, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Four, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Five, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Six, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Seven, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Eight, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Nine, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Ten, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Jack, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Queen, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.King, Color.Club));

            _table.FinalStock1.AddRange(someRange);
            _table.FinalStock2.AddRange(someRange);
            _table.FinalStock3.AddRange(someRange);

            List<bool> resBool = _column.checkConclusion(_table);

            Assert.True(resBool[0]);
            Assert.True(resBool[1]);
        }

        [Test]
        public void ColumnContructor_ShouldThrowAnException_IfThereIsNoColumnWithThatIndex ()
        {
            _column.colIndex = 44;
            Assert.Throws(typeof(ArgumentException),
                () => new Column(44, _table)); 

        }

        [Test]
        public void checkConclusion_shouldThrowAnError_IfEveryFinalStock_ContainsSomeGarbage()
        {
            someRange.Add(new Card(CardValue.Nine, Color.Club));
            _table.FinalStock1.AddRange(someRange);
            _table.FinalStock2.AddRange(someRange);
            _table.FinalStock3.AddRange(someRange);
            _table.FinalStock4.AddRange(someRange);

            _column.possibleCards.Add(new Card(CardValue.Ace, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Two, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Three, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Four, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Five, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Six, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Seven, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Eight, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Nine, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Ten, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Jack, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.Queen, Color.Club));
            _column.possibleCards.Add(new Card(CardValue.King, Color.Club));

            Assert.Throws(typeof(Exception),
                () => _column.checkConclusion(_table));
        }



    }
}
