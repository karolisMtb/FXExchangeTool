using FXExchangeTool.BusinessLogic.Interfaces;

namespace FXExchangeTool.BusinessLogic.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        private ICurrencyConversionStrategy? _currencyConversionStrategy;

        public void SetConversionStrategy(ICurrencyConversionStrategy currencyConversionStrategy)
        {
            _currencyConversionStrategy = currencyConversionStrategy;
        }

        public decimal ConvertCurrency(string currency, decimal amount)
        {
            if (_currencyConversionStrategy == null)
                throw new Exception($"No strategy found for currency ${currency}");

            return Math.Round(_currencyConversionStrategy.Convert(currency, amount), 2);
        }

        public string GetFromCurrency(string currencyInput)
        {
            var currencies = GetCurrencies(currencyInput);

            return currencies[0].ToUpper();
        }

        public string GetToCurrency(string currencyInput)
        {
            var currencies = GetCurrencies(currencyInput);

            return currencies[1].ToUpper();
        }

        public decimal GetAmount(string currencyInput)
        {
            decimal amount = decimal.Parse(GetCurrencies(currencyInput)[2]);
            
            if(amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }

            return amount;
        }

        private string[] GetCurrencies(string currencyInput)
        {
            string[] currencies = currencyInput.ToUpper().Split('/', ' ');

            return currencies;
        }

    }
}
