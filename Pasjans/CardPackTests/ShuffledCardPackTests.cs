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
    }
}