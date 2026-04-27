using System.Collections.Generic;
using Savvy.Interfaces;
using UnityEngine;

namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters.Ios
{
	[CreateAssetMenu(fileName = nameof(IosVibrationConfig), menuName = "Config/"+nameof(IosVibrationConfig))]
	public class IosVibrationConfig : ScriptableObject, IToolkitView
	{
		[field: SerializeField] private List<VibrationData> _vibrationDatas;

		public IReadOnlyList<VibrationData> VibrationDatas => _vibrationDatas;
	}
}