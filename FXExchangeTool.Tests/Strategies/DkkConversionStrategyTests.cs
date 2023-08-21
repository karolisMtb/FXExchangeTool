using FXExchangeTool.BusinessLogic.Models;
using FXExchangeTool.DataAccess.Interfaces;
using Moq;

namespace FXExchangeTool.Tests.Strategies
{
    public class DkkConversionStrategyTests
    {
        private readonly Dictionary<string, decimal> _dkkExchangeRates = new()
        {
            {"EUR", 7.4394M },
            {"USD", 6.6311M },
            {"GBP", 8.5285M },
            {"SEK", 0.761M },
            {"NOK", 0.784M },
            {"CHF", 6.8358M },
            {"JPY", 0.05974M },
            {"DKK", 1.0M }
        };

        [Fact]
        public void Convert_ValidInput_ReturnsCorrectAmount()
        {
            // Arrange
            string toCurrency = "EUR";
            decimal amount = 10;
            decimal expectedConvertedAmount = 74.394M;
            var currencyRepositoryMock = new Mock<ICurrencyRepository>();
            currencyRepositoryMock.Setup(repo => repo.GetDkkConversionRateByShortname(toCurrency)).Returns(_dkkExchangeRates[toCurrency]);

            var dkkConversionStrategy = new DkkConversionStrategy(currencyRepositoryMock.Object);

            // Act
            decimal result = dkkConversionStrategy.Convert(toCurrency, amount);

            // Assert
            Assert.Equal(expectedConvertedAmount, result);
        }
    }
}
