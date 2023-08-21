
namespace FXExchangeTool.DataAccess.Interfaces
{
    public interface ICurrencyRepository
    {
        decimal GetUsdConversionRateByShortname(string shortname);
        decimal GetSekConversionRateByShortname(string shortname);
        decimal GetNokConversionRateByShortname(string shortname);
        decimal GetJpyConversionRateByShortname(string shortname);
        decimal GetGbpConversionRateByShortname(string shortname);
        decimal GetEurConversionRateByShortname(string shortname);
        decimal GetDkkConversionRateByShortname(string shortname);
        decimal GetChfConversionRateByShortname(string shortname);
    }
}
