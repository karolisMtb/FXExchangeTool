using FXExchangeTool.BusinessLogic.Interfaces;
using FXExchangeTool.DataAccess.Interfaces;

namespace FXExchangeTool.BusinessLogic.Models
{
    public class SekConversionStrategy : ICurrencyConversionStrategy
    {
        private ICurrencyRepository _currencyRepository;

        public SekConversionStrategy(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }


        public decimal Convert(string toCurrency, decimal amount)
        {
            return _currencyRepository.GetSekConversionRateByShortname(toCurrency) * amount;
        }
    }
}
