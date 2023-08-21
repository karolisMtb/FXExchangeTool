using FXExchangeTool.BusinessLogic.Models;
using FXExchangeTool.DataAccess.Interfaces;
using Moq;

namespace FXExchangeTool.Tests.Strategies
{
    public class EurConversionStrategyTests
    {
        private readonly Dictionary<string, decimal> _eurExchangeRates = new()
        {
            {"EUR", 1.0M },
            {"USD", 1.1219M },
            {"GBP", 0.87229M },
            {"SEK", 9.7758M },
            {"NOK", 9.489M },
            {"CHF", 1.0883M },
            {"JPY", 124.5296M },
            {"DKK", 0.1344M }
        };

        [Fact]
        public void Convert_ValidInput_ReturnsCorrectAmount()
        {
            // Arrange
            string toCurrency = "EUR";
            decimal amount = 10;
            decimal expectedConvertedAmount = 10M;
            var currencyRepositoryMock = new Mock<ICurrencyRepository>();
            currencyRepositoryMock.Setup(repo => repo.GetEurConversionRateByShortname(toCurrency)).Returns(_eurExchangeRates[toCurrency]);

            var eurConversionStrategy = new EurConversionStrategy(currencyRepositoryMock.Object);

            // Act
            decimal result = eurConversionStrategy.Convert(toCurrency, amount);

            // Assert
            Assert.Equal(expectedConvertedAmount, result);
        }
    }
}
