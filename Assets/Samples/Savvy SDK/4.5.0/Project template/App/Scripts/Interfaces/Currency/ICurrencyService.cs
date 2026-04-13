using System;
using Savvy.Interfaces;

namespace App.Scripts.Interfaces.Currency
{
    public interface ICurrencyService : IService
    {
        event Action<int> GemsUpdated;
        event Action<int> CoinsUpdated;
        int Gems { get; }
        int Coins { get; }
        void AddGems(int amount);
        void AddCoins(int amount);
        void SpendGems(int amount, Action success, Action failure = null);
        void SpendCoins(int amount, Action success, Action failure = null);
    }
}