using System.Collections.Generic;
using Savvy.Interfaces;
using UnityEngine;

namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters.Android
{
	[CreateAssetMenu(fileName = nameof(AndroidVibrationConfig), menuName = "Config/"+nameof(AndroidVibrationConfig))]
	public class AndroidVibrationConfig : ScriptableObject, IToolkitView
	{
		[field: SerializeField] private List<VibrationData> _vibrationDatas;

		public IReadOnlyList<VibrationData> VibrationDatas => _vibrationDatas;
	}
}