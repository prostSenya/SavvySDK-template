using App.Scripts.Interfaces.Currency;
using Savvy.Container;

namespace App.Scripts.Services.Currency
{
    public class CurrencyProvider : NetSavvy, ICurrencyProvider
    {
        private readonly CurrencyId _currencyId;
        private readonly bool _debug;

        public int Amount { get; private set; }

        public CurrencyProvider(CurrencyId currencyId, int amount, bool debug)
        {
            _currencyId = currencyId;
            _debug = debug;
            LoadOrDefault(amount);
        }

        public void Add(int amount)
        {
            if (amount > int.MaxValue - Amount)
                Amount = int.MaxValue;
            else
                Amount += amount;

            Debug($"Added '{amount}' to '{_currencyId}'. Total '{Amount}'", _debug);
        }

        public bool TrySpend(int amount)
        {
            if (Amount < amount)
            {
                Warning($"Not enough '{_currencyId}'. Need '{amount}', have '{Amount}'", _debug);
                return false;
            }

            Amount -= amount;
            Debug($"Spent '{amount}' from '{_currencyId}'. Total '{Amount}'", _debug);
            return true;
        }

        private void LoadOrDefault(int loadAmount)
        {
            if (loadAmount < 0)
            {
                Amount = 0;
                Debug($"Loaded default {_currencyId}: '{Amount}'", _debug);
            }
            else
            {
                Amount = loadAmount;
                Debug($"Loaded progress {_currencyId}: '{Amount}'", _debug);
            }
        }
    }
}