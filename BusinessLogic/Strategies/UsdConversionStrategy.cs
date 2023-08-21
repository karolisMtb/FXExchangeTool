using FXExchangeTool.BusinessLogic.Interfaces;
using FXExchangeTool.DataAccess.Interfaces;

namespace FXExchangeTool.BusinessLogic.Models
{
    public class UsdConversionStrategy : ICurrencyConversionStrategy
    {
        private ICurrencyRepository _currencyRepository;

        public UsdConversionStrategy(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public decimal Convert(string toCurrency, decimal amount)
        {
            return _currencyRepository.GetUsdConversionRateByShortname(toCurrency) * amount;
        }
    }
}
