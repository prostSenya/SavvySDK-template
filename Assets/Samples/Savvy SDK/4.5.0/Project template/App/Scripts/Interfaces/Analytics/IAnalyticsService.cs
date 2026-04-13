using App.Scripts.Interfaces.Statistics.NewPlayer;
using App.Scripts.Interfaces.Statistics.PlayTime;
using Savvy.Interfaces;

namespace App.Scripts.Interfaces.Analytics
{
    public interface IAnalyticsService : IService
    {
        void SendEvent(PlayTimeData data);
        void SendEventOnce(NewPlayerData data);
    }
}