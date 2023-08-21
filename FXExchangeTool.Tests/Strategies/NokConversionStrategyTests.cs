using FXExchangeTool.BusinessLogic.Models;
using FXExchangeTool.DataAccess.Interfaces;
using Moq;

namespace FXExchangeTool.Tests.Strategies
{
    public class NokConversionStrategyTests
    {
        private readonly Dictionary<string, decimal> _nokExchangeRates = new()
        {
            {"EUR", 0.1054M },
            {"USD", 0.118M },
            {"GBP", 0.0919M },
            {"SEK", 1.0302M },
            {"NOK", 1.0M },
            {"CHF", 0.1146M },
            {"JPY", 13.1235M },
            {"DKK", 1.2755M }
        };

        [Fact]
        public void Convert_ValidInput_ReturnsCorrectAmount()
        {
            // Arrange
            string toCurrency = "CHF";
            decimal amount = 100M;
            decimal expectedConvertedAmount = 11.46M;
            var currencyRepositoryMock = new Mock<ICurrencyRepository>();
            currencyRepositoryMock.Setup(repo => repo.GetNokConversionRateByShortname(toCurrency)).Returns(_nokExchangeRates[toCurrency]);

            var nokConversionStrategy = new NokConversionStrategy(currencyRepositoryMock.Object);

            // Act
            decimal result = nokConversionStrategy.Convert(toCurrency, amount);

            // Assert
            Assert.Equal(expectedConvertedAmount, result);
        }
    }
}
