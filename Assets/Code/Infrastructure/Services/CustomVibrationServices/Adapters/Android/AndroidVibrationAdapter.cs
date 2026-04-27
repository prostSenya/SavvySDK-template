#if UNITY_ANDROID

using System;
using System.Collections.Generic;
using System.Linq;
using Savvy.Container;
using Savvy.Interfaces;
using UnityEngine;

namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters.Android
{
	public class AndroidVibrationAdapter : NetSavvy, IVibrationAdapter
	{
		private const string IsVibrationEnablePreferenceKey = "IsVibrationEnable";
		
		private const int AndroidOreoApiLevel = 26; // API Oreo 8.0+
		private const int DefaultAmplitude = -1;
		private const int MinAmplitude = 1;
		private const int MaxAmplitude = 255;
		
		private readonly Dictionary<VibrationType, VibrationData> _vibrationDatas;

		private IPreferencesService _preferencesService;
		private AndroidJavaObject _androidVibrator;
		private AndroidJavaClass _vibrationEffectClass;
		private AndroidJavaClass _buildVersionClass;
		private int _androidApiLevel;
		private bool _hasAmplitudeControl;

		public AndroidVibrationAdapter()
		{
			_vibrationDatas = ScriptableObjectLoader.LoadSettings<AndroidVibrationConfig>()
				.VibrationDatas
				.ToDictionary(x => x.VibrationType, x => x);
		}

		public bool IsSupported { get; private set; }
		public bool IsEnabled { get; private set; }

		public void Inject() => 
			_preferencesService = GetService<IPreferencesService>();

		public void Init()
		{
			try
			{
				using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				using (var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
				{
					_androidVibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
					_buildVersionClass = new AndroidJavaClass("android.os.Build$VERSION");
					_androidApiLevel = _buildVersionClass.GetStatic<int>("SDK_INT");

					if (_androidApiLevel >= AndroidOreoApiLevel)
					{
						_vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect");
						_hasAmplitudeControl = _androidVibrator != null &&
						                       _androidVibrator.Call<bool>("hasAmplitudeControl");
					}
					
					IsSupported = _androidVibrator != null && _androidVibrator.Call<bool>("hasVibrator");
                
					if (_androidApiLevel >= AndroidOreoApiLevel) 
					{
						_vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect");
					}
				}
				
				Debug($"Android haptics initialized. API Level: {_androidApiLevel}. Amplitude control: {_hasAmplitudeControl}");
			}
			catch (Exception exception)
			{
				Error($"Android haptics initialization failed: {exception.Message}");
			}
			
			IsEnabled = _preferencesService.GetBool(IsVibrationEnablePreferenceKey);
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

			if (vibrationType == VibrationType.Unknown)
				throw new ArgumentOutOfRangeException(nameof(vibrationType), vibrationType, null);

			if (_vibrationDatas.TryGetValue(vibrationType, out VibrationData vibrationData) == false)
				throw new KeyNotFoundException($"Vibration type {vibrationType} was not found");
			
			Vibrate(vibrationData.Force, vibrationData.Duration);
		}

		public void Vibrate(float force, float duration)
		{
			if (IsEnabled == false)
				return;

			if (IsSupported == false)
				return;

			if (duration <= 0f)
				return;

			force = Mathf.Clamp01(force);

			if (force <= 0f)
			{
				Cancel();
				return;
			}
			
			long durationMs = Mathf.Max(1, Mathf.RoundToInt(duration * 1000f));

			try
			{
				if (_androidApiLevel >= AndroidOreoApiLevel && _vibrationEffectClass != null)
				{
					VibrateWithVibrationEffect(force, durationMs);
					return;
				}

				VibrateLegacy(durationMs);
			}
			catch (Exception exception)
			{
				Error($"Android vibration failed: {exception.Message}");
			}
		}
		
		public void Cancel()
		{
			try
			{
				_androidVibrator?.Call("cancel");
			}
			catch (Exception exception)
			{
				Error($"Android vibration cancel failed: {exception.Message}");
			}		
		}

		public void Dispose()
		{
			Cancel();

			_androidVibrator?.Dispose();
			_vibrationEffectClass?.Dispose();
			_buildVersionClass?.Dispose();

			_androidVibrator = null;
			_vibrationEffectClass = null;
			_buildVersionClass = null;
		}
		
		private void VibrateWithVibrationEffect(float force, long durationMs)
		{
			int amplitude = GetAmplitude(force);

			using AndroidJavaObject vibrationEffect = _vibrationEffectClass.CallStatic<AndroidJavaObject>(
				"createOneShot",
				durationMs,
				amplitude);

			_androidVibrator.Call("vibrate", vibrationEffect);
		}
		
		private void VibrateLegacy(long durationMs)
		{
			_androidVibrator.Call("vibrate", durationMs);
		}

		private int GetAmplitude(float force)
		{
			if (_hasAmplitudeControl == false)
				return DefaultAmplitude;

			return Mathf.Clamp(
				Mathf.RoundToInt(force * MaxAmplitude),
				MinAmplitude,
				MaxAmplitude);
		}
	}
}
#endif