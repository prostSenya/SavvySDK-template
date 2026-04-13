using App.Scripts.Constants;
using UnityEngine;

namespace App.Scripts.Interfaces.Statistics
{
    [CreateAssetMenu(menuName = PathConstants.ServicesDir + "/" + nameof(StatisticsSettings), fileName = nameof(StatisticsSettings))]
    public class StatisticsSettings : ScriptableObject
    {
        [Header("Logging")]
        [SerializeField] private bool _debug;
        
        public bool Debug => _debug;
    }
}