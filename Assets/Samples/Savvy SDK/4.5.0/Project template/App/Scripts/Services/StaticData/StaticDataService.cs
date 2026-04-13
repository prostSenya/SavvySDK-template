using App.Scripts.Interfaces.Currency;
using App.Scripts.Interfaces.StaticData;
using App.Scripts.Interfaces.Windows;
using Savvy.Container;

namespace App.Scripts.Services.StaticData
{
    public partial class StaticDataService : NetSavvyResources, IStaticDataService
    {
        private void LoadStaticData()
        {
            LoadAndRegister<WindowId, WindowStaticData>(x => x.WindowId);
            LoadAndRegister<CurrencyId, CurrencyStaticData>(x => x.CurrencyId);
        }
    }
}