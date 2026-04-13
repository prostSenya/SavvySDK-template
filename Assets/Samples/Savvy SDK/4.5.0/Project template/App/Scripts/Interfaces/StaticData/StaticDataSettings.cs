using App.Scripts.Constants;
using UnityEngine;

namespace App.Scripts.Interfaces.StaticData
{
    [CreateAssetMenu(menuName = PathConstants.ServicesDir + "/" + nameof(StaticDataSettings), fileName = nameof(StaticDataSettings))]
    public class StaticDataSettings : ScriptableObject
    {
        [Header("Logging")]
        [SerializeField] private bool _debug;
        
        public bool Debug => _debug;
    }
}