using App.Scripts.Constants;
using UnityEngine;

namespace App.Scripts.Interfaces.GameNavigation
{
    [CreateAssetMenu(menuName = PathConstants.ServicesDir + "/" + nameof(GameNavigationSettings), fileName = nameof(GameNavigationSettings))]
    public class GameNavigationSettings : ScriptableObject
    {
        [Header("Logging")]
        [SerializeField] private bool _debug;
        
        public bool Debug => _debug;
    }
}