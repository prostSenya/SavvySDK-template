using System;
using System.Threading;
using Savvy.Container;
using Savvy.Interfaces;
using UnityEngine;

namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters.Android
{
	public class AndroidVibrationAdapter : NetSavvy, IVibrationAdapter
	{
		private const string IsVibrationEnablePreferenceKey = "IsVibrationEnable";

		private readonly AndroidVibrationConfig _androidVibrationConfig;
		readonly object _lock = new();

		private IPreferencesService _preferencesService;
		private AndroidJavaObject _androidVibrator;
		private AndroidJavaClass _vibrationEffectClass;
		private int _androidApiLevel;
		private CancellationTokenSource _cts;
		
		public AndroidVibrationAdapter() => 
			_androidVibrationConfig = ScriptableObjectLoader.LoadResource<AndroidVibrationConfig>();

		public bool IsEnabled { get; private set; }

		public void Inject()
		{
			_preferencesService = GetService<IPreferencesService>();
		}

		public void Init()
		{
			try
			{
				using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				using (var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
				{
					_androidVibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
					_androidApiLevel = new AndroidJavaClass("android.os.Build$VERSION").GetStatic<int>("SDK_INT");
                
					if (_androidApiLevel >= 26) // Oreo 8.0+
					{
						_vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect");
					}
				}
				
				Debug("Android haptics initialized. API Level: " + _androidApiLevel);
			}
			catch (Exception e)
			{
				Error("Android haptics initialization failed: " + e.Message);
			}
		}

		public void SetEnable(bool isEnable)
		{
			IsEnabled = isEnable;
			
			_preferencesService.SetBool(IsVibrationEnablePreferenceKey, IsEnabled);
		}

		public void Vibrate(VibrationType vibrationType)
		{
			if (IsEnabled == false)
				return;

			lock (_lock)
			{
				_cts?.Dispose();
				_cts = new CancellationTokenSource();
			}

			switch (vibrationType)
			{
				case VibrationType.Easy:
					break;
				
				case VibrationType.Medium:
					break;
				
				case VibrationType.Hard:
					break;
				
				case VibrationType.Unknown:
				default:
					throw new ArgumentOutOfRangeException(nameof(vibrationType), vibrationType, null);
			}
		}

		public void Vibrate(float force, float duration)
		{
			
		}
		
		public bool IsSupported() => 
			_androidVibrator != null && _androidVibrator.Call<bool>("hasVibrator");
		

		public void Cancel()
		{
			lock (_lock) 
				_cts?.Cancel();
		}
	}

	public enum VibrationType
	{
		Unknown = 0,
		Easy = 1,
		Medium = 2,
		Hard = 3
	}
}