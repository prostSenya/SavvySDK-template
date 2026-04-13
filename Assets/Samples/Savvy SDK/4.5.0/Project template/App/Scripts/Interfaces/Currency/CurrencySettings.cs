using App.Scripts.Constants;
using UnityEngine;

namespace App.Scripts.Interfaces.Currency
{
    [CreateAssetMenu(menuName = PathConstants.ServicesDir + "/" + nameof(CurrencySettings), fileName = nameof(CurrencySettings))]
    public class CurrencySettings : ScriptableObject
    {
        [Header("Logging")]
        [SerializeField] private bool _debug;
        
        public bool Debug => _debug;
    }
}