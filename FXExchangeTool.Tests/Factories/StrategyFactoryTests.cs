using FXExchangeTool.BusinessLogic.Factories;
using FXExchangeTool.BusinessLogic.Models;
using FXExchangeTool.DataAccess.Interfaces;
using Moq;

namespace FXExchangeTool.Tests.Factories
{
    public class StrategyFactoryTests
    {
        [Fact]
        public void GetStrategy_ExistingCurrency_ReturnsCorrectStrategy()
        {
            // Arrange
            var currencyRepositoryMock = new Mock<ICurrencyRepository>();
            var strategyFactory = new StrategyFactory(currencyRepositoryMock.Object);

            // Act
            var strategy = strategyFactory.GetStrategy("EUR");

            // Assert
            Assert.NotNull(strategy);
            Assert.IsType<EurConversionStrategy>(strategy);
        }

        [Fact]
        public void GetStrategy_NonExistingCurrency_ThrowsKeyNotFoundException()
        {
            // Arrange
            var currencyRepositoryMock = new Mock<ICurrencyRepository>();
            var strategyFactory = new StrategyFactory(currencyRepositoryMock.Object);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => strategyFactory.GetStrategy("AUD"));
        }
    }
}
