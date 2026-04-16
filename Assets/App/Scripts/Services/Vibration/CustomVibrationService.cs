using App.Scripts.Interfaces.Vibration;
using Savvy.Container;

namespace App.Scripts.Services.Vibration
{
    public class CustomVibrationService : NetSavvy, ICustomVibrationService
    {
        private ICustomVibrationAdapter _adapter;

        public void Inject()
        {
            _adapter = GetService<ICustomVibrationAdapter>();
        }

        public void Vibrate(VibrationForce force)
        {
            _adapter.Vibrate(force);
        }
    }
}
