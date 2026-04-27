namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters
{
	public class DummyVibrationAdapter : IVibrationAdapter
	{
		private bool _isSupported;
		public bool IsEnabled { get; private set; }

		bool IVibrationAdapter.IsSupported => _isSupported;
		public bool SupportsForceControl => false;

		public void SetEnable(bool isEnable)
		{
			
		}

		public void Cancel()
		{
			
		}

		public bool IsSupported() => 
			false;

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