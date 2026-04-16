using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Constants;
using App.Scripts.Interfaces.Vibration;
using Savvy.Container;
using UnityEngine;

namespace App.Scripts.Services.Vibration
{
	public class AndroidVibrationAdapter : NetSavvyResources, ICustomVibrationAdapter
	{
		private readonly string _configPath = $"{PathConstants.ServicesDir}/{nameof(VibrationConfig)}";
		private readonly Dictionary<VibrationForce, VibrationInfo> _config;

		private AndroidJavaObject _vibrator;

		public AndroidVibrationAdapter()
		{
			_config = LoadResources<VibrationConfig>(_configPath).Vibrations.ToDictionary(x => x.Force, x => x);
		}

		public void Init() =>
			InitPlatform();

		private void InitPlatform()
		{
			using var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			_vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
		}

		public void Vibrate(VibrationForce force)
		{
			if (_config.TryGetValue(force, out VibrationInfo info) == false)
				throw new Exception("Vibration Force Not Found");
			
			_vibrator.Call("vibrate", info.Duration);
		}
	}
}