using App.Scripts.Interfaces.Vibration;
using Savvy.Container;

namespace App.Scripts.Services.Vibration
{
    public class IosVibrationAdapter : NetSavvy, ICustomVibrationAdapter
    {
        public void Inject()
        {
        }

        public void Vibrate(VibrationForce force)
        {
            Debug($"iOS vibrate: force={force}");
        }

        public void Dispose()
        {
            
        }
    }
}
