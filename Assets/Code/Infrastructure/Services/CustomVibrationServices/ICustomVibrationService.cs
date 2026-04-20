using Savvy.Interfaces;

namespace Code.Infrastructure.Services.CustomVibrationServices
{
	public interface ICustomVibrationService : IService
	{
		bool IsEnabled { get; }
		void SetEnabled(bool enabled);
	}
}