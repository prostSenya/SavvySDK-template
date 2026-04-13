namespace App.Scripts.Interfaces.Currency
{
    public interface ICurrencyProvider
    {
        int Amount { get; }
        void Add(int amount);
        bool TrySpend(int amount);
    }
}