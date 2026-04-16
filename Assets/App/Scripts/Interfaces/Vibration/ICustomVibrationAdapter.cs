using Savvy.Interfaces;

namespace App.Scripts.Interfaces.Vibration
{
    public interface ICustomVibrationAdapter : IService
    {
        void Vibrate(VibrationForce force);
    }
}
