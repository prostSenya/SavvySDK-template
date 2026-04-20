namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters
{
	public class DummyVibrationAdapter : IVibrationAdapter
	{
		public bool IsEnabled { get; private set; }
		
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
	}
}