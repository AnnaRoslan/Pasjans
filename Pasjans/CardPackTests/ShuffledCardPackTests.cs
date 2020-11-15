using System.Linq;
using CardPack;
using Xunit;

namespace CardPackTests
{
    public class ShuffledCardPackTests
    {
        [Fact]
        public void ShuffledPack_Get_Return52UniqueCards_Test()
        {
            var pack = new ShuffledCardPack().GetCards();
            Assert.Equal(52, pack.Distinct().Count());
        }

        [Fact]
        public void ShuffledPack_Get_ReturnShuffledCards_Test()
        {
            var defaultPack = DefaultCardPack.GetCards();

            var pack = new ShuffledCardPack().GetCards();

            Assert.NotEqual(defaultPack, pack);
        }
    }
}