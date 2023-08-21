using FXExchangeTool.BusinessLogic.Interfaces;
using FXExchangeTool.BusinessLogic.Models;
using FXExchangeTool.DataAccess.Interfaces;

namespace FXExchangeTool.BusinessLogic.Factories
{
    public class StrategyFactory : IStrategyFactory
    {
        private Dictionary<string, ICurrencyConversionStrategy> _currencyConversionStrategies;

        public StrategyFactory(ICurrencyRepository currencyRepository)
        {
            _currencyConversionStrategies = new()
            {
                {"EUR", new EurConversionStrategy(currencyRepository) },
                {"CHF", new ChfConversionStrategy(currencyRepository) },
                {"DKK", new DkkConversionStrategy(currencyRepository) },
                {"GBP", new GbpConversionStrategy(currencyRepository) },
                {"JPY", new JpyConversionStrategy(currencyRepository) },
                {"NOK", new NokConversionStrategy(currencyRepository) },
                {"SEK", new SekConversionStrategy(currencyRepository) },
                {"USD", new UsdConversionStrategy(currencyRepository) },
            };
        }

        public ICurrencyConversionStrategy GetStrategy(string toCurrency)
        {
            if (!_currencyConversionStrategies.ContainsKey(toCurrency))
            {
                throw new KeyNotFoundException("No such currency exists");
            }

            return _currencyConversionStrategies[toCurrency];
        }
    }
}
