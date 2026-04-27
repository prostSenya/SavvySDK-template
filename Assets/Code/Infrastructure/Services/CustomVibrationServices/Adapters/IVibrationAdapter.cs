using System;
using Savvy.Interfaces;

namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters
{
	public interface IVibrationAdapter : IService, IDisposable
	{
		bool IsEnabled { get; }
		bool IsSupported { get; }
		void SetEnable(bool isEnable);
		void Vibrate(float force, float duration);
		void Vibrate(VibrationType vibrationType);
		void Cancel();
	}
}