using App.Scripts.Constants;
using UnityEngine;

namespace App.Scripts.Interfaces.Analytics
{
    [CreateAssetMenu(menuName = PathConstants.ServicesDir + "/" + nameof(AnalyticsSettings), fileName = nameof(AnalyticsSettings))]
    public class AnalyticsSettings : ScriptableObject
    {
        [Header("Logging")]
        [SerializeField] private bool _debug;
        
        public bool Debug => _debug;
    }
}