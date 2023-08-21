using FXExchangeTool.BusinessLogic.Interfaces;
using FXExchangeTool.DataAccess.Interfaces;

namespace FXExchangeTool.BusinessLogic.Models
{
    public class ChfConversionStrategy : ICurrencyConversionStrategy
    {
        private ICurrencyRepository _currencyRepository;

        public ChfConversionStrategy(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public decimal Convert(string toCurrency, decimal amount)
        {
            return _currencyRepository.GetChfConversionRateByShortname(toCurrency) * amount;
        }
    }
}
