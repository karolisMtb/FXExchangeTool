using FXExchangeTool.BusinessLogic.Models;
using FXExchangeTool.DataAccess.Interfaces;
using Moq;

namespace FXExchangeTool.Tests.Strategies
{

    public class ChfConversionStrategyTests
    {
        private readonly Dictionary<string, decimal> _chfExchangeRates = new()
        {
            {"EUR", 0.9188M },
            {"USD", 1.0308M },
            {"GBP", 0.8015M },
            {"SEK", 8.9826M },
            {"NOK", 8.719M },
            {"CHF", 1.0M },
            {"JPY", 114.4258M },
            {"DKK", 0.1462M }
        };

        [Fact]
        public void Convert_ValidInput_ReturnsCorrectAmount()
        {
            // Arrange
            string toCurrency = "SEK";
            decimal amount = 10;
            decimal expectedConvertedAmount = 89.826M;
            var currencyRepositoryMock = new Mock<ICurrencyRepository>();
            currencyRepositoryMock.Setup(repo => repo.GetChfConversionRateByShortname(toCurrency)).Returns(_chfExchangeRates[toCurrency]);

            var chfConversionStrategy = new ChfConversionStrategy(currencyRepositoryMock.Object);

            // Act
            decimal result = chfConversionStrategy.Convert(toCurrency, amount);

            // Assert
            Assert.Equal(expectedConvertedAmount, result);
        }
    }    
}
