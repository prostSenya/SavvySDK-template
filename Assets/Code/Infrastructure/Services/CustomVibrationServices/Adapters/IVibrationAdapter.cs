using Savvy.Interfaces;

namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters
{
	public interface IVibrationAdapter : IService
	{
		bool IsEnabled { get; }
		void SetEnable(bool isEnable);
		void Cancel();
		bool IsSupported();
	}
}