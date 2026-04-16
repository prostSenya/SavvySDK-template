using App.Scripts.Interfaces.Statistics.NewPlayer;
using Savvy.Interfaces;

namespace App.Scripts.Interfaces.Statistics
{
    public interface IStatisticsService : IService
    {
        void NewPlayerStep(NewPlayerStep step);
    }
}