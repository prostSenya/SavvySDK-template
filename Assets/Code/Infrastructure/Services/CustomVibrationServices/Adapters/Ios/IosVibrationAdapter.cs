using Savvy.Container;

namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters.Ios
{
	public class IosVibrationAdapter : IVibrationAdapter
	{
		private readonly IosVibrationConfig _iosVibrationConfig;
		private bool _isSupported;

		public IosVibrationAdapter() => 
			_iosVibrationConfig = ScriptableObjectLoader.LoadResource<IosVibrationConfig>();

		public bool IsEnabled { get; }

		bool IVibrationAdapter.IsSupported => _isSupported;

		public void SetEnable(bool isEnable)
		{
			
		}

		public void Cancel()
		{
			
		}

		public void Vibrate(VibrationType vibrationType)
		{
			
		}

		public void Vibrate(float force, float duration)
		{
			
		}

		public void Dispose()
		{
			
		}
	}
}