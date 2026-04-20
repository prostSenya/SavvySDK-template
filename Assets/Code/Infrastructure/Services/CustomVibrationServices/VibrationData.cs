using System;
using UnityEngine;

namespace Code.Infrastructure.Services.CustomVibrationServices
{
	[Serializable]
	public class VibrationData
	{
		[field: SerializeField] public VibrationType VibrationType { get; private set; }
		[field: SerializeField] public float Force { get; private set; }
		[field: SerializeField] public float Duration { get; private set; }
	}
}