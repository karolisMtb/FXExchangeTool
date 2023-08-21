using FXExchangeTool.DataAccess.Interfaces;

namespace FXExchangeTool.DataAccess.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly Dictionary<string, decimal> _chfExchangeRates = new()
        {
            {"EUR", 0.9188M },
            {"USD", 1.0308M },
            {"GBP", 0.8015M },
            {"SEK", 8.9826M },
            {"NOK", 8.719M },
            {"CHF", 1.0M },
            {"JPY", 114.4258M },
            {"DKK", 0.1462M }
        };

        private readonly Dictionary<string, decimal> _dkkExchangeRates = new()
        {
            {"EUR", 7.4394M },
            {"USD", 6.6311M },
            {"GBP", 8.5285M },
            {"SEK", 0.761M },
            {"NOK", 0.784M },
            {"CHF", 6.8358M },
            {"JPY", 0.05974M },
            {"DKK", 1.0M }
        };

        private readonly Dictionary<string, decimal> _eurExchangeRates = new()
        {
            {"EUR", 1.0M },
            {"USD", 1.1219M },
            {"GBP", 0.87229M },
            {"SEK", 9.7758M },
            {"NOK", 9.489M },
            {"CHF", 1.0883M },
            {"JPY", 124.5296M },
            {"DKK", 0.1344M }
        };

        private readonly Dictionary<string, decimal> _gbpExchangeRates = new()
        {
            {"EUR", 1.1463M },
            {"USD", 1.2861M },
            {"GBP", 1.0M },
            {"SEK", 11.2069M },
            {"NOK", 10.8781M },
            {"CHF", 1.2476M },
            {"JPY", 142.760M },
            {"DKK", 0.11725M }
        };

        private readonly Dictionary<string, decimal> _jpyExchangeRates = new()
        {
            {"EUR", 0.00803M },
            {"USD", 0.009M },
            {"GBP", 0.007M },
            {"SEK", 0.0785M },
            {"NOK", 0.0762M },
            {"CHF", 0.008739M },
            {"JPY", 1.0M },
            {"DKK", 16.7392M }
        };

        private readonly Dictionary<string, decimal> _nokExchangeRates = new()
        {
            {"EUR", 0.1054M },
            {"USD", 0.118M },
            {"GBP", 0.0919M },
            {"SEK", 1.0302M },
            {"NOK", 1.0M },
            {"CHF", 0.1146M },
            {"JPY", 13.1235M },
            {"DKK", 1.2755M }
        };

        private readonly Dictionary<string, decimal> _sekExchangeRates = new()
        {
            {"EUR", 0.10229M },
            {"USD", 0.11476M },
            {"GBP", 0.08923M },
            {"SEK", 1.0M },
            {"NOK", 0.9706M },
            {"CHF", 0.1113M },
            {"JPY", 12.7385M },
            {"DKK", 1.314M }
        };

        private readonly Dictionary<string, decimal> _usdExchangeRates = new()
        {
            {"EUR", 0.891M },
            {"USD", 1.0M },
            {"GBP", 0.7775M },
            {"SEK", 7.713M },
            {"NOK", 8.458M },
            {"CHF", 0.97M },
            {"JPY", 110.9993M },
            {"DKK", 0.1508M }
        };

        public decimal GetUsdConversionRateByShortname(string shortname)
        {
            if (!_usdExchangeRates.ContainsKey(shortname))
                throw new KeyNotFoundException($"Key not found in dictionary {shortname}");

            return _usdExchangeRates[shortname];
        }

        public decimal GetSekConversionRateByShortname(string shortname)
        {
            if (!_sekExchangeRates.ContainsKey(shortname))
                throw new KeyNotFoundException($"Key not found in dictionary {shortname}");

            return _sekExchangeRates[shortname];
        }

        public decimal GetNokConversionRateByShortname(string shortname)
        {
            if (!_nokExchangeRates.ContainsKey(shortname))
                throw new KeyNotFoundException($"Key not found in dictionary {shortname}");

            return _nokExchangeRates[shortname];
        }

        public decimal GetJpyConversionRateByShortname(string shortname)
        {
            if (!_jpyExchangeRates.ContainsKey(shortname))
                throw new KeyNotFoundException($"Key not found in dictionary {shortname}");

            return _jpyExchangeRates[shortname];
        }

        public decimal GetGbpConversionRateByShortname(string shortname)
        {
            if (!_gbpExchangeRates.ContainsKey(shortname))
                throw new KeyNotFoundException($"Key not found in dictionary {shortname}");

            return _gbpExchangeRates[shortname];
        }

        public decimal GetEurConversionRateByShortname(string shortname)
        {
            if (!_eurExchangeRates.ContainsKey(shortname))
                throw new KeyNotFoundException($"Key not found in dictionary {shortname}");

            return _eurExchangeRates[shortname];
        }

        public decimal GetDkkConversionRateByShortname(string shortname)
        {
            if (!_dkkExchangeRates.ContainsKey(shortname))
                throw new KeyNotFoundException($"Key not found in dictionary {shortname}");

            return _dkkExchangeRates[shortname];
        }

        public decimal GetChfConversionRateByShortname(string shortname)
        {
            if (!_chfExchangeRates.ContainsKey(shortname))
                throw new KeyNotFoundException($"Key not found in dictionary {shortname}");

            return _chfExchangeRates[shortname];
        }
    }
}
