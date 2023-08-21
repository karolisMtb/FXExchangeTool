namespace FXExchangeTool.BusinessLogic.Interfaces
{
    public interface ICurrencyConversionStrategy
    {
        decimal Convert(string toCurrency, decimal amount);
    }
}
