using App.Scripts.Constants;
using App.Scripts.Interfaces.Analytics;
using App.Scripts.Interfaces.Statistics.NewPlayer;
using App.Scripts.Interfaces.Statistics.PlayTime;
using Savvy.Container;
using Savvy.Interfaces;

namespace App.Scripts.Services.Analytics
{
    public class AnalyticsService : NetSavvyResources, IAnalyticsService
    {
        private readonly string _settingsPath = $"{PathConstants.ServicesDir}/{nameof(AnalyticsSettings)}";
        private readonly AnalyticsSettings _settings;
        
        //private IAppMetricaService _appMetricaService;
        //private IFirebaseAnalyticsService _firebaseAnalyticsService;
        //private ITenjinService _tenjinService;
        //private IGameAnalyticsService _gameAnalyticsService;
        
        public AnalyticsService() => 
            _settings = LoadResources<AnalyticsSettings>(_settingsPath);

        public void Inject()
        {
            //_appMetricaService = GetService<IAppMetricaService>();
            //_firebaseAnalyticsService = GetService<IFirebaseAnalyticsService>();
            //_tenjinService = GetService<ITenjinService>();
            //_gameAnalyticsService = GetService<IGameAnalyticsService>();
        }

        public void SendEvent(PlayTimeData data)
        {
            //_appMetricaService.SendEvent(nameof(PlayTimeData), data);
            //_firebaseAnalyticsService.SendEvent(nameof(PlayTimeData), data);
            //_tenjinService.SendEvent(nameof(PlayTimeData), data);
            //_gameAnalyticsService.SendEvent(nameof(PlayTimeData), data.PlayTime);
        }

        public void SendEventOnce(NewPlayerData data)
        {
            //_appMetricaService.SendEventOnce(nameof(NewPlayerData), data);
            //_firebaseAnalyticsService.SendEventOnce(nameof(NewPlayerData), data);
            //_tenjinService.SendEventOnce(nameof(NewPlayerData), data);
            //_gameAnalyticsService.SendEventOnce($"{nameof(NewPlayerData)}:{data.Step}", data.StepId);
        }
    }
}