using System;
using Savvy.Interfaces;

namespace App.Scripts.Interfaces.Vibration
{
    public interface ICustomVibrationAdapter : IService, IDisposable
    {
        void Vibrate(VibrationForce force);
    }
}
