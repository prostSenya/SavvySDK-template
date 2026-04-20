using Savvy.Container;

namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters.Ios
{
	public class IosVibrationAdapter : IVibrationAdapter
	{
		private readonly IosVibrationConfig _iosVibrationConfig;

		public IosVibrationAdapter() => 
			_iosVibrationConfig = ScriptableObjectLoader.LoadResource<IosVibrationConfig>();

		public bool IsEnabled { get; }

		public void SetEnable(bool isEnable)
		{
			
		}

		public void Cancel()
		{
			
		}
		
		public bool IsSupported() => 
			true;

		public void Vibrate(VibrationType vibrationType)
		{
			
		}

		public void Vibrate(float force, float duration)
		{
			
		}
	}
}