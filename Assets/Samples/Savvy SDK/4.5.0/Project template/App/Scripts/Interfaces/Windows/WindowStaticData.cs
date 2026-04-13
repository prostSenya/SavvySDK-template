using App.Scripts.Constants;
using UnityEngine;

namespace App.Scripts.Interfaces.Windows
{
    [CreateAssetMenu(menuName = PathConstants.StaticDataDir + "/" + nameof(WindowStaticData))]
    public class WindowStaticData : ScriptableObject
    {
        [SerializeField] private WindowId _windowId;
        [SerializeField] private WindowPrefab _windowPrefab;
        
        public WindowId WindowId => _windowId;
        public WindowPrefab WindowPrefab => _windowPrefab;
    }
}