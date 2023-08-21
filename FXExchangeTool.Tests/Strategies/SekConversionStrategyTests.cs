using FXExchangeTool.BusinessLogic.Models;
using FXExchangeTool.DataAccess.Interfaces;
using Moq;

namespace FXExchangeTool.Tests.Strategies
{
    public class SekConversionStrategyTests
    {
        private readonly Dictionary<string, decimal> _sekExchangeRates = new()
        {
            {"EUR", 0.10229M },
            {"USD", 0.11476M },
            {"GBP", 0.08923M },
            {"SEK", 1.0M },
            {"NOK", 0.9706M },
            {"CHF", 0.1113M },
            {"JPY", 12.7385M },
            {"DKK", 1.314M }
        };

        [Fact]
        public void Convert_ValidInput_ReturnsCorrectAmount()
        {
            // Arrange
            string toCurrency = "CHF";
            decimal amount = 1000M;
            decimal expectedConvertedAmount = 111.3M;
            var currencyRepositoryMock = new Mock<ICurrencyRepository>();
            currencyRepositoryMock.Setup(repo => repo.GetSekConversionRateByShortname(toCurrency)).Returns(_sekExchangeRates[toCurrency]);

            var sekConversionStrategy = new SekConversionStrategy(currencyRepositoryMock.Object);

            // Act
            decimal result = sekConversionStrategy.Convert(toCurrency, amount);

            // Assert
            Assert.Equal(expectedConvertedAmount, result);
        }
    }
}
