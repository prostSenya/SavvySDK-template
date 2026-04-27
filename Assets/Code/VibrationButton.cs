using System;
using Code.Infrastructure.Services.CustomVibrationServices;
using Savvy.Container;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public class VibrationButton : MonoSavvy
	{
		private ICustomVibrationService _vibrationService;

		[SerializeField] private Button _button;
		[SerializeField] private VibrationType _vibrationType;
		
		private void Awake() => 
			_vibrationService = GetService<ICustomVibrationService>();

		private void OnEnable()
		{
			_button.onClick.AddListener(Vibrate);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(Vibrate);
		}

		private void Vibrate()
		{
			if (_vibrationService.IsEnabled == false)
				return;
			
			_vibrationService.Vibrate(_vibrationType);
		}
	}
}