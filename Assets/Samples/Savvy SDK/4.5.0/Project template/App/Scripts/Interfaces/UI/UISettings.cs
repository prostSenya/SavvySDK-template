using App.Scripts.Constants;
using UnityEngine;

namespace App.Scripts.Interfaces.UI
{
    [CreateAssetMenu(menuName = PathConstants.ServicesDir + "/" + nameof(UISettings), fileName = nameof(UISettings))]
    public class UISettings : ScriptableObject
    {
        [Header("Logging")]
        [SerializeField] private bool _debug;
        
        [Header("UI")]
        [SerializeField] private Camera _uiCamera;
        [SerializeField] private Canvas _uiCanvas;
        
        public bool Debug => _debug;
        public Camera UICamera => _uiCamera;
        public Canvas UICanvas => _uiCanvas;
    }
}