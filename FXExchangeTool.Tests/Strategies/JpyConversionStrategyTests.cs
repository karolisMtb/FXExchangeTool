using FXExchangeTool.BusinessLogic.Models;
using FXExchangeTool.DataAccess.Interfaces;
using Moq;

namespace FXExchangeTool.Tests.Strategies
{
    public class JpyConversionStrategyTests
    {
        private readonly Dictionary<string, decimal> _jpyExchangeRates = new()
        {
            {"EUR", 0.00803M },
            {"USD", 0.009M },
            {"GBP", 0.007M },
            {"SEK", 0.0785M },
            {"NOK", 0.0762M },
            {"CHF", 0.008739M },
            {"JPY", 1.0M },
            {"DKK", 16.7392M }
        };

        [Fact]
        public void Convert_ValidInput_ReturnsCorrectAmount()
        {
            // Arrange
            string toCurrency = "EUR";
            decimal amount = 1000M;
            decimal expectedConvertedAmount = 8.03M;
            var currencyRepositoryMock = new Mock<ICurrencyRepository>();
            currencyRepositoryMock.Setup(repo => repo.GetJpyConversionRateByShortname(toCurrency)).Returns(_jpyExchangeRates[toCurrency]);

            var jpyConversionStrategy = new JpyConversionStrategy(currencyRepositoryMock.Object);

            // Act
            decimal result = jpyConversionStrategy.Convert(toCurrency, amount);

            // Assert
            Assert.Equal(expectedConvertedAmount, result);
        }
    }
}
