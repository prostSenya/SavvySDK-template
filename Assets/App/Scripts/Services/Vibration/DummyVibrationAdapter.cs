using App.Scripts.Interfaces.Vibration;
using Savvy.Container;

namespace App.Scripts.Services.Vibration
{
    public class DummyVibrationAdapter : NetSavvy, ICustomVibrationAdapter
    {
        public void Inject()
        {
        }

        public void Vibrate(VibrationForce force)
        {
        }

        public void Dispose()
        {
            
        }
    }
}
