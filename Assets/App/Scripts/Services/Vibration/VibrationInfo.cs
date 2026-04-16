using System;
using App.Scripts.Interfaces.Vibration;
using UnityEngine;

namespace App.Scripts.Services.Vibration
{
	[Serializable]
	public class VibrationInfo
	{
		[SerializeField] private long _duration;
		[SerializeField] private VibrationForce _force;

		public long Duration => _duration;
		public VibrationForce Force => _force;
	}
}