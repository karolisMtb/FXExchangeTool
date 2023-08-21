using FXExchangeTool.BusinessLogic.Factories;
using FXExchangeTool.BusinessLogic.Interfaces;
using FXExchangeTool.BusinessLogic.Services;
using FXExchangeTool.DataAccess.Interfaces;
using FXExchangeTool.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddScoped<IStrategyFactory, StrategyFactory>()
            .AddScoped<ICurrencyRepository, CurrencyRepository>()
            .AddScoped<ICurrencyConverterService, CurrencyConverterService>()
            .BuildServiceProvider();

        var factory = serviceProvider.GetRequiredService<IStrategyFactory>();
        var currencyConverterService = serviceProvider.GetRequiredService<ICurrencyConverterService>();

        do
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Usage: <convert from currency>/<convert to currency> <amount to exchange>");
                Console.WriteLine("Example: ");
                Console.WriteLine("GBP/USD 100");
                Console.WriteLine("Available currencies are: \nDKK\nEUR\nUSD\nGBP\nSEK\nNOK\nCHF\nJPY\n--------");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !ValidateInputFormat(input))
                {
                    throw new ArgumentException("Invalid input format");
                }

                string fromCurrency = currencyConverterService.GetFromCurrency(input);
                string toCurrency = currencyConverterService.GetToCurrency(input);
                decimal amount = currencyConverterService.GetAmount(input);

                currencyConverterService.SetConversionStrategy(factory.GetStrategy(fromCurrency));
                decimal convertedValue = currencyConverterService.ConvertCurrency(toCurrency, amount);

                Console.WriteLine(convertedValue);

            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Argument error occurred: {e.Message}");
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine($"Key not found error occurred: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred: {e.Message}");
            }
        }
        while (true);
    }

    static bool ValidateInputFormat(string input)
    {
        string pattern = @"^[A-Za-z]{3}/[A-Za-z]{3}\s[0-9]\d*$";

        return Regex.IsMatch(input, pattern);
    }




}