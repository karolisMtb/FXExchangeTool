namespace FXExchangeTool.BusinessLogic.Interfaces
{
    public interface IStrategyFactory
    {
        ICurrencyConversionStrategy GetStrategy(string currency);
    }
}
