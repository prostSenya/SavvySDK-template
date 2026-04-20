using Code.Infrastructure.Services.CustomVibrationServices;
using Code.Infrastructure.Services.CustomVibrationServices.Adapters;
using Code.Infrastructure.Services.CustomVibrationServices.Adapters.Android;
using Savvy.Bootstrap;

namespace Code.Infrastructure.Scopes
{
	public class ProjectScope : ProjectBehaviourBase
	{
		protected override void OnProjectBehaviourInitialized()
		{
			base.OnProjectBehaviourInitialized();
		}

		protected override void RegisterProjectServices()
		{
			RegisterService<ICustomVibrationService>(new CustomVibrationService());

#if UNITY_IOS
			RegisterService<IVibrationAdapter>(new IosVibrationAdapter());
#elif UNITY_ANDROID
			RegisterService<IVibrationAdapter>(new AndroidVibrationAdapter());
#else
			RegisterService<IVibrationAdapter>(new DummyVibrationAdapter());
#endif
		}
	}
}