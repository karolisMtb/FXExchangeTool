using FXExchangeTool.DataAccess.Repositories;

namespace FXExchangeTool.Tests.Repositories
{
    public class CurrencyRepositoryTests
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
        public void GetUsdConversionRateByShortname_CorrectCurrencyInput_ReturnsConversionRate()
        {
            // Arrange
            string currency = "SEK";
            var currencyRepository = new CurrencyRepository();
            decimal expectedRate = _usdExchangeRates[currency];

            // Act
            decimal result = currencyRepository.GetUsdConversionRateByShortname(currency);

            // Assert
            Assert.Equal(expectedRate, result);
        }

        [Fact]
        public void GetUsdConversionRateByShortname_InvalidInput_ThrowsException()
        {
            // Arrange
            string currency = "ANY";
            var currencyRepository = new CurrencyRepository();

            // Assert && Act 
            Assert.Throws<KeyNotFoundException>(() => currencyRepository.GetUsdConversionRateByShortname(currency));
        }

        [Fact]
        public void GetSekConversionRateByShortname_CorrectCurrencyInput_ReturnsConversionRate()
        {
            // Arrange
            string currency = "SEK";
            var currencyRepository = new CurrencyRepository();
            decimal expectedRate = _sekExchangeRates[currency];

            // Act
            decimal result = currencyRepository.GetSekConversionRateByShortname(currency);

            // Assert
            Assert.Equal(expectedRate, result);
        }

        [Fact]
        public void GetSekConversionRateByShortname_InvalidInput_ThrowsException()
        {
            // Arrange
            string currency = "ANY";
            var currencyRepository = new CurrencyRepository();

            // Assert && Act 
            Assert.Throws<KeyNotFoundException>(() => currencyRepository.GetSekConversionRateByShortname(currency));
        }

        [Fact]
        public void GetNokConversionRateByShortname_CorrectCurrencyInput_ReturnsConversionRate()
        {
            // Arrange
            string currency = "SEK";
            var currencyRepository = new CurrencyRepository();
            decimal expectedRate = _nokExchangeRates[currency];

            // Act
            decimal result = currencyRepository.GetNokConversionRateByShortname(currency);

            // Assert
            Assert.Equal(expectedRate, result);
        }

        [Fact]
        public void GetNokConversionRateByShortname_InvalidInput_ThrowsException()
        {
            // Arrange
            string currency = "ANY";
            var currencyRepository = new CurrencyRepository();

            // Assert && Act 
            Assert.Throws<KeyNotFoundException>(() => currencyRepository.GetNokConversionRateByShortname(currency));
        }

        [Fact]
        public void GetJpyConversionRateByShortname_CorrectCurrencyInput_ReturnsConversionRate()
        {
            // Arrange
            string currency = "SEK";
            var currencyRepository = new CurrencyRepository();
            decimal expectedRate = _jpyExchangeRates[currency];

            // Act
            decimal result = currencyRepository.GetJpyConversionRateByShortname(currency);

            // Assert
            Assert.Equal(expectedRate, result);
        }

        [Fact]
        public void GetJpyConversionRateByShortname_InvalidInput_ThrowsException()
        {
            // Arrange
            string currency = "ANY";
            var currencyRepository = new CurrencyRepository();

            // Assert && Act 
            Assert.Throws<KeyNotFoundException>(() => currencyRepository.GetJpyConversionRateByShortname(currency));
        }

        [Fact]
        public void GetGbpConversionRateByShortname_CorrectCurrencyInput_ReturnsConversionRate()
        {
            // Arrange
            string currency = "SEK";
            var currencyRepository = new CurrencyRepository();
            decimal expectedRate = _gbpExchangeRates[currency];

            // Act
            decimal result = currencyRepository.GetGbpConversionRateByShortname(currency);

            // Assert
            Assert.Equal(expectedRate, result);
        }

        [Fact]
        public void GetGbpConversionRateByShortname_InvalidInput_ThrowsException()
        {
            // Arrange
            string currency = "ANY";
            var currencyRepository = new CurrencyRepository();

            // Assert && Act 
            Assert.Throws<KeyNotFoundException>(() => currencyRepository.GetGbpConversionRateByShortname(currency));
        }

        [Fact]
        public void GetEurConversionRateByShortname_CorrectCurrencyInput_ReturnsConversionRate()
        {
            // Arrange
            string currency = "SEK";
            var currencyRepository = new CurrencyRepository();
            decimal expectedRate = _eurExchangeRates[currency];

            // Act
            decimal result = currencyRepository.GetEurConversionRateByShortname(currency);

            // Assert
            Assert.Equal(expectedRate, result);
        }

        [Fact]
        public void GetEurConversionRateByShortname_InvalidInput_ThrowsException()
        {
            // Arrange
            string currency = "ANY";
            var currencyRepository = new CurrencyRepository();

            // Assert && Act 
            Assert.Throws<KeyNotFoundException>(() => currencyRepository.GetEurConversionRateByShortname(currency));
        }

        [Fact]
        public void GetDkkConversionRateByShortname_CorrectCurrencyInput_ReturnsConversionRate()
        {
            // Arrange
            string currency = "SEK";
            var currencyRepository = new CurrencyRepository();
            decimal expectedRate = _dkkExchangeRates[currency];

            // Act
            decimal result = currencyRepository.GetDkkConversionRateByShortname(currency);

            // Assert
            Assert.Equal(expectedRate, result);
        }

        [Fact]
        public void GetDkkConversionRateByShortname_InvalidInput_ThrowsException()
        {
            // Arrange
            string currency = "ANY";
            var currencyRepository = new CurrencyRepository();

            // Assert && Act 
            Assert.Throws<KeyNotFoundException>(() => currencyRepository.GetDkkConversionRateByShortname(currency));
        }

        [Fact]
        public void GetChfConversionRateByShortname_CorrectCurrencyInput_ReturnsConversionRate()
        {
            // Arrange
            string currency = "SEK";
            var currencyRepository = new CurrencyRepository();
            decimal expectedRate = _chfExchangeRates[currency];

            // Act
            decimal result = currencyRepository.GetChfConversionRateByShortname(currency);

            // Assert
            Assert.Equal(expectedRate, result);
        }

        [Fact]
        public void GetChfConversionRateByShortname_InvalidInput_ThrowsException()
        {
            // Arrange
            string currency = "ANY";
            var currencyRepository = new CurrencyRepository();

            // Assert && Act 
            Assert.Throws<KeyNotFoundException>(() => currencyRepository.GetChfConversionRateByShortname(currency));
        }
    }
}
