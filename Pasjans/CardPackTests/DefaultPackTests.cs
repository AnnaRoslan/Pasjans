using System.Linq;
using CardPack;
using Xunit;

namespace CardPackTests
{
    public class DefaultPackTests
    {
        [Fact]
        public void DefaultPack_Get_Return52UniqueCards_Test()
        {
            var pack = DefaultPack.Get();
            Assert.Equal(52, pack.Distinct().Count());
        }
    }
}