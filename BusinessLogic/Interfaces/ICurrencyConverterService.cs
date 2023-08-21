namespace FXExchangeTool.BusinessLogic.Interfaces
{
    public interface ICurrencyConverterService
    {
        void SetConversionStrategy(ICurrencyConversionStrategy currencyConversionStrategy);
        decimal ConvertCurrency(string currency, decimal amount);
        string GetToCurrency(string currencyInput);
        string GetFromCurrency(string currencyInput);
        decimal GetAmount(string currencyInput);

    }
}
