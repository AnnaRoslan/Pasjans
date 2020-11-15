using System.Linq;
using CardPack;
using Xunit;

namespace CardPackTests
{
    public class DefaultCardPackTests
    {
        [Fact]
        public void DefaultPack_Get_Return52UniqueCards_Test()
        {
            var pack = DefaultCardPack.GetCards();
            Assert.Equal(52, pack.Distinct().Count());
        }
    }
}