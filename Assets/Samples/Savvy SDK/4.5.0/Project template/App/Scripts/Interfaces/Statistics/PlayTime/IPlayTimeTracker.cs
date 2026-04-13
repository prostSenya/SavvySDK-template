using App.Scripts.Interfaces.SaveLoad;

namespace App.Scripts.Interfaces.Statistics.PlayTime
{
    public interface IPlayTimeTracker
    {
        void UpdateProgress(ref ProgressData data);
        void Dispose();
    }
}