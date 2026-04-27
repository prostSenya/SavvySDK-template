using System;
using System.Collections.Generic;
using System.Linq;
using Savvy.Container;
using Savvy.Interfaces;
using UnityEngine;

namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters.Ios
{
	public sealed class IosVibrationAdapter : NetSavvy, IVibrationAdapter, IDisposable
	{
		private const string IsVibrationEnablePreferenceKey = "IsVibrationEnable";

		private readonly Dictionary<VibrationType, VibrationData> _vibrationDatas;

		private IPreferencesService _preferencesService;

		public bool IsEnabled { get; private set; }

		public bool IsSupported => IosHapticsNative.IsSupported();

		public bool SupportsForceControl => IosHapticsNative.SupportsForceControl();

		public IosVibrationAdapter()
		{
			_vibrationDatas = ScriptableObjectLoader
				.LoadSettings<IosVibrationConfig>()
				.VibrationDatas
				.ToDictionary(x => x.VibrationType, x => x);
		}

		public void Inject()
		{
			_preferencesService = GetService<IPreferencesService>();
		}

		public void Init()
		{
			if (_preferencesService == null)
				throw new InvalidOperationException($"{nameof(IPreferencesService)} is not injected.");

			IsEnabled = _preferencesService.GetBool(IsVibrationEnablePreferenceKey, true);

			IosHapticsNative.Init();

			Debug(
				$"iOS haptics initialized. " +
				$"IsSupported: {IsSupported}. " +
				$"SupportsForceControl: {SupportsForceControl}. " +
				$"IsEnabled: {IsEnabled}.");
		}

		public void SetEnable(bool isEnable)
		{
			IsEnabled = isEnable;
			_preferencesService.SetBool(IsVibrationEnablePreferenceKey, IsEnabled);

			if (IsEnabled == false)
				Cancel();
		}

		public void Cancel()
		{
			IosHapticsNative.Cancel();
		}

		public void Vibrate(VibrationType vibrationType)
		{
			if (IsEnabled == false)
				return;

			if (vibrationType == VibrationType.Unknown)
				throw new ArgumentOutOfRangeException(nameof(vibrationType), vibrationType, null);

			if (_vibrationDatas.TryGetValue(vibrationType, out VibrationData vibrationData) == false)
				throw new KeyNotFoundException($"Vibration type {vibrationType} was not found.");

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

			IosHapticsNative.Vibrate(force, duration);
		}

		public void Dispose()
		{
			Cancel();
		}
	}
}