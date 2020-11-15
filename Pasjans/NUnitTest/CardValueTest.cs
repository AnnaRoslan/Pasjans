using System.Runtime.CompilerServices;
using NUnit.Framework;
using Pasjans;

namespace NUnitTest
{
    public class CardValueTest
    {

        [Test]
        public void Is_Ace_Smaller_Then_two()
        {
            Assert.IsTrue(CardValue.Ace < CardValue.Two);
        }
        [Test]
        public void Is_Two_Smaller_Then_three()
        {
            Assert.IsTrue(CardValue.Two < CardValue.Three);
        }
        [Test]
        public void Is_Three_Smaller_Then_four()
        {
            Assert.IsTrue(CardValue.Three < CardValue.Four);
        }
    }
}