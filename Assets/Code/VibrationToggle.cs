using System;
using Code.Infrastructure.Services.CustomVibrationServices;
using Savvy.Container;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public class VibrationToggle : MonoSavvy
	{
		[SerializeField] private Toggle _toggle;

		private ICustomVibrationService _vibrationService;

		private void Awake() => 
			_vibrationService = GetService<ICustomVibrationService>();

		private void Start() => 
			_toggle.isOn = _vibrationService.IsEnabled;

		private void OnEnable() => 
			_toggle.onValueChanged.AddListener(VibrateEnableChanged);

		private void OnDisable() => 
			_toggle.onValueChanged.RemoveListener(VibrateEnableChanged);

		private void VibrateEnableChanged(bool isEnable) => 
			_vibrationService.SetEnabled(isEnable);
	}
}