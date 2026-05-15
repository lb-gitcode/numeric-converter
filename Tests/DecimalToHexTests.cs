using Moq;
using numeric_converter;

namespace Tests
{
    public class DecimalToHexTests
    {
        [Fact]
        public void NormalTest_ShouldReturnNormal()
        {
            string test = Converter.DecimalToHex(255);

            Assert.Equal("FF", test);
        }
    }
}
