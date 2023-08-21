using FXExchangeTool.BusinessLogic.Models;
using FXExchangeTool.DataAccess.Interfaces;
using Moq;

namespace FXExchangeTool.Tests.Strategies
{
    public class UsdConversionStrategyTests
    {
        private readonly Dictionary<string, decimal> _usdExchangeRates = new()
        {
            {"EUR", 0.891M },
            {"USD", 1.0M },
            {"GBP", 0.7775M },
            {"SEK", 7.713M },
            {"NOK", 8.458M },
            {"CHF", 0.97M },
            {"JPY", 110.9993M },
            {"DKK", 0.1508M }
        };

        [Fact]
        public void Convert_ValidInput_ReturnsCorrectAmount()
        {
            // Arrange
            string toCurrency = "EUR";
            decimal amount = 1000M;
            decimal expectedConvertedAmount = 891M;
            var currencyRepositoryMock = new Mock<ICurrencyRepository>();
            currencyRepositoryMock.Setup(repo => repo.GetUsdConversionRateByShortname(toCurrency)).Returns(_usdExchangeRates[toCurrency]);

            var usdConversionStrategy = new UsdConversionStrategy(currencyRepositoryMock.Object);

            // Act
            decimal result = usdConversionStrategy.Convert(toCurrency, amount);

            // Assert
            Assert.Equal(expectedConvertedAmount, result);
        }
    }
}
