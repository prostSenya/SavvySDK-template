using Savvy.Interfaces;

namespace App.Scripts.Interfaces.Vibration
{
    public interface ICustomVibrationService : IService
    {
        void Vibrate(VibrationForce force);
    }
}
