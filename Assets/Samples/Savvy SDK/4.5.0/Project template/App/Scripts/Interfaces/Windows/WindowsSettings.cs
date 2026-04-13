using App.Scripts.Constants;
using UnityEngine;

namespace App.Scripts.Interfaces.Windows
{
    [CreateAssetMenu(menuName = PathConstants.ServicesDir + "/" + nameof(WindowsSettings), fileName = nameof(WindowsSettings))]
    public class WindowsSettings : ScriptableObject
    {
        [Header("Logging")]
        [SerializeField] private bool _debug;
        
        public bool Debug => _debug;
    }
}