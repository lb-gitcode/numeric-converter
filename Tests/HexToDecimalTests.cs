using Moq;
using numeric_converter;

namespace Tests
{
    public class HexToDecimalTests
    {
        // normal cases
        [Fact]
        public void IntegersOnly_ShouldReturnNormal()
        {
            int test = Converter.HexToDecimal("63");

            Assert.Equal(99, test);
        }

        [Fact]
        public void LettersOnly_ShouldReturnNormal()
        {
            int test = Converter.HexToDecimal("FF");

            Assert.Equal(255, test);
        }
    }
}
