using System.Collections.Generic;
using App.Scripts.Constants;
using UnityEngine;

namespace App.Scripts.Services.Vibration
{
    [CreateAssetMenu(
        menuName = PathConstants.ServicesDir + "/" + nameof(VibrationConfig),
        fileName = nameof(VibrationConfig))]
    public class VibrationConfig : ScriptableObject
    {
        [SerializeField] private List<VibrationInfo> _vibrations;

        public IReadOnlyList<VibrationInfo> Vibrations => _vibrations;
    }
}
