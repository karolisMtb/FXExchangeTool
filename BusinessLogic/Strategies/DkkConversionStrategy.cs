using FXExchangeTool.BusinessLogic.Interfaces;
using FXExchangeTool.DataAccess.Interfaces;

namespace FXExchangeTool.BusinessLogic.Models
{
    public class DkkConversionStrategy : ICurrencyConversionStrategy
    {
        private ICurrencyRepository _currencyRepository;

        public DkkConversionStrategy(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public decimal Convert(string toCurrency, decimal amount)
        {
            return _currencyRepository.GetDkkConversionRateByShortname(toCurrency) * amount;
        }
    }
}
