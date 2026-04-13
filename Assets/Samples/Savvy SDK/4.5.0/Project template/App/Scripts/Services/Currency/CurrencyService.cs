using System;
using App.Scripts.Constants;
using App.Scripts.Interfaces.Currency;
using App.Scripts.Interfaces.SaveLoad;
using Savvy.Container;
using Savvy.Interfaces;

namespace App.Scripts.Services.Currency
{
    public class CurrencyService : NetSavvyResources, ICurrencyService, ISavedProgress<ProgressData>
    {
        private readonly string _settingsPath = $"{PathConstants.ServicesDir}/{nameof(CurrencySettings)}";
        private readonly CurrencySettings _settings;

        public event Action<int> GemsUpdated;
        public event Action<int> CoinsUpdated;

        private ISaveLoadService<ProgressData> _saveLoadService;
        private ICurrencyProvider _gemsProvider;
        private ICurrencyProvider _coinsProvider;

        public int Gems => _gemsProvider.Amount;
        public int Coins => _coinsProvider.Amount;

        public CurrencyService() => 
            _settings = LoadResources<CurrencySettings>(_settingsPath);

        public void Inject() =>
            _saveLoadService = GetService<ISaveLoadService<ProgressData>>();

        public void Init()
        {
            var progressData = _saveLoadService.GetProgressData();
            _gemsProvider = new CurrencyProvider(CurrencyId.Gems, progressData.Gems, _settings.Debug);
            _coinsProvider = new CurrencyProvider(CurrencyId.Coins, progressData.Coins, _settings.Debug);
        }

        public void AddGems(int amount)
        {
            _gemsProvider.Add(amount);
            GemsUpdated?.Invoke(Gems);
        }

        public void AddCoins(int amount)
        {
            _coinsProvider.Add(amount);
            CoinsUpdated?.Invoke(Coins);
        }

        public void SpendGems(int amount, Action success, Action failure)
        {
            if (_gemsProvider.TrySpend(amount))
            {
                success?.Invoke();
                GemsUpdated?.Invoke(Gems);
            }
            else
            {
                failure?.Invoke();
            }
        }

        public void SpendCoins(int amount, Action success, Action failure)
        {
            if (_coinsProvider.TrySpend(amount))
            {
                success?.Invoke();
                CoinsUpdated?.Invoke(Coins);
            }
            else
            {
                failure?.Invoke();
            }
        }

        public void UpdateProgress(ref ProgressData data)
        {
            data.Gems = _gemsProvider.Amount;
            data.Coins = _coinsProvider.Amount;
        }
    }
}