using System;
using App.Scripts.Constants;
using App.Scripts.Interfaces.SaveLoad;
using App.Scripts.Interfaces.Statistics;
using App.Scripts.Interfaces.Statistics.NewPlayer;
using App.Scripts.Interfaces.Statistics.PlayTime;
using App.Scripts.Services.Statistics.Trackers;
using Savvy.Container;
using Savvy.Interfaces;

namespace App.Scripts.Services.Statistics
{
    public class StatisticsService : NetSavvyResources, IStatisticsService, ISavedProgress<ProgressData>, IDisposable
    {
        private readonly string _settingsPath = $"{PathConstants.ServicesDir}/{nameof(StatisticsSettings)}";
        private readonly StatisticsSettings _settings;

        private ISaveLoadService<ProgressData> _saveLoadService;

        private IPlayTimeTracker _playTime;
        private INewPlayerTracker _newPlayer;

        public StatisticsService() => 
            _settings = LoadResources<StatisticsSettings>(_settingsPath);

        public void Inject() => 
            _saveLoadService = GetService<ISaveLoadService<ProgressData>>();

        public void Init()
        {
            var loadData = _saveLoadService.GetProgressData();
            
            _playTime = new PlayTimeTracker(_settings.Debug, loadData.PlayTimeSec);
            _newPlayer = new NewPlayerTracker(_settings.Debug);
        }
        
        public void UpdateProgress(ref ProgressData data) => 
            _playTime.UpdateProgress(ref data);

        public void Dispose() => 
            _playTime.Dispose();

        public void NewPlayerStep(NewPlayerStep step) => 
            _newPlayer.SendStep(step);
    }
}