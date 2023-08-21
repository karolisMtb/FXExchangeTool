using FXExchangeTool.BusinessLogic.Interfaces;
using FXExchangeTool.DataAccess.Interfaces;

namespace FXExchangeTool.BusinessLogic.Models
{
    public class GbpConversionStrategy : ICurrencyConversionStrategy
    {
        private ICurrencyRepository _currencyRepository;

        public GbpConversionStrategy(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public decimal Convert(string toCurrency, decimal amount)
        {
            return _currencyRepository.GetGbpConversionRateByShortname(toCurrency) * amount;
        }
    }
}
