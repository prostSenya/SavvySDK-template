namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters
{
	public class DummyVibrationAdapter : IVibrationAdapter
	{
		public void SetEnable(bool isEnable)
		{
			
		}

		public void Cancel()
		{
			
		}

		public bool IsEnabled { get; private set; }
	}
}