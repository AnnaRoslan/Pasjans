using System;
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
    }
}