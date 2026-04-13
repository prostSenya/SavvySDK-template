using App.Scripts.Interfaces.Analytics;
using App.Scripts.Interfaces.Statistics.NewPlayer;
using Savvy.Container;

namespace App.Scripts.Services.Statistics.Trackers
{
    public class NewPlayerTracker : NetSavvy, INewPlayerTracker
    {
        private readonly IAnalyticsService _analyticsService;
        private readonly bool _debug;

        public NewPlayerTracker(bool debug)
        {
            _analyticsService = GetService<IAnalyticsService>();
            _debug = debug;
        }

        public void SendStep(NewPlayerStep step)
        {
            Debug($"Player step '{step}'", _debug);
            _analyticsService.SendEventOnce(GetNewPlayerData(step));
        }

        private NewPlayerData GetNewPlayerData(NewPlayerStep step) => new()
        {
            StepId = (int)step,
            Step = step.ToString()
        };
    }
}