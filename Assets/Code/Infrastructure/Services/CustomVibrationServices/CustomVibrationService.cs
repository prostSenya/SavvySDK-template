using Code.Infrastructure.Services.CustomVibrationServices.Adapters;
using Savvy.Container;

namespace Code.Infrastructure.Services.CustomVibrationServices
{
	public class CustomVibrationService : NetSavvy, ICustomVibrationService
	{
		private IVibrationAdapter _vibrationAdapter;

		public void Inject() => 
			_vibrationAdapter = GetService<IVibrationAdapter>();

		public bool IsEnabled => _vibrationAdapter.IsEnabled;
		
		public void SetEnabled(bool enabled) => 
			_vibrationAdapter.SetEnable(enabled);
	}
}