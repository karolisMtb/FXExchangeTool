using FXExchangeTool.BusinessLogic.Models;
using FXExchangeTool.DataAccess.Interfaces;
using Moq;

namespace FXExchangeTool.Tests.Strategies
{
    public class GbpConversionStrategyTests
    {
        private readonly Dictionary<string, decimal> _gbpExchangeRates = new()
        {
            {"EUR", 1.1463M },
            {"USD", 1.2861M },
            {"GBP", 1.0M },
            {"SEK", 11.2069M },
            {"NOK", 10.8781M },
            {"CHF", 1.2476M },
            {"JPY", 142.760M },
            {"DKK", 0.11725M }
        };

        [Fact]
        public void Convert_ValidInput_ReturnsCorrectAmount()
        {
            // Arrange
            string toCurrency = "EUR";
            decimal amount = 10M;
            decimal expectedConvertedAmount = 11.463M;
            var currencyRepositoryMock = new Mock<ICurrencyRepository>();
            currencyRepositoryMock.Setup(repo => repo.GetGbpConversionRateByShortname(toCurrency)).Returns(_gbpExchangeRates[toCurrency]);

            var gbpConversionStrategy = new GbpConversionStrategy(currencyRepositoryMock.Object);

            // Act
            decimal result = gbpConversionStrategy.Convert(toCurrency, amount);

            // Assert
            Assert.Equal(expectedConvertedAmount, result);
        }
    }
}
