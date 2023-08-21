using FXExchangeTool.BusinessLogic.Interfaces;
using FXExchangeTool.BusinessLogic.Services;
using Moq;

namespace FXExchangeTool.Tests.Services
{
    public class CurrencyConverterServiceTests
    {

        [Fact]
        public void ConvertCurrency_NoStrategy_ThrowsException()
        {
            // Arrange
            var currencyConverterService = new CurrencyConverterService();

            // Act & Assert
            Assert.Throws<Exception>(() => currencyConverterService.ConvertCurrency("USD", 100m));
        }

        [Fact]
        public void ConvertCurrency_ValidInput_ReturnsConvertedAmount()
        {
            // Arrange
            var currencyConversionStrategyMock = new Mock<ICurrencyConversionStrategy>();
            currencyConversionStrategyMock.Setup(strategy => strategy.Convert("USD", 100m)).Returns(110m);

            var currencyConverterService = new CurrencyConverterService();
            currencyConverterService.SetConversionStrategy(currencyConversionStrategyMock.Object);

            // Act
            decimal result = currencyConverterService.ConvertCurrency("USD", 100m);

            // Assert
            Assert.Equal(110m, result);
        }

        [Theory]
        [InlineData("usd/eur 100", "USD")]
        [InlineData("GBP/JPY 200", "GBP")]
        public void GetFromCurrency_ValidInput_ReturnsCorrectCurrency(string input, string expectedCurrency)
        {
            // Arrange
            var currencyConverterService = new CurrencyConverterService();

            // Act
            string result = currencyConverterService.GetFromCurrency(input);

            // Assert
            Assert.Equal(expectedCurrency, result);
        }

        [Theory]
        [InlineData("usd/eur 100", "EUR")]
        [InlineData("GBP/JPY 200", "JPY")]
        public void GetToCurrency_ValidInput_ReturnsCorrectCurrency(string input, string expectedCurrency)
        {
            // Arrange
            var currencyConverterService = new CurrencyConverterService();

            // Act
            string result = currencyConverterService.GetToCurrency(input);

            // Assert
            Assert.Equal(expectedCurrency, result);
        }

        [Theory]
        [InlineData("usd/eur 100", 100)]
        [InlineData("GBP/JPY 200", 200)]
        public void GetAmount_ValidInput_ReturnsCorrectAmount(string input, decimal expectedAmount)
        {
            // Arrange
            var currencyConverterService = new CurrencyConverterService();

            // Act
            decimal result = currencyConverterService.GetAmount(input);

            // Assert
            Assert.Equal(expectedAmount, result);
        }
    }
}
