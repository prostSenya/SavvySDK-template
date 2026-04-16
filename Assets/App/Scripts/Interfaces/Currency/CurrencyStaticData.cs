using App.Scripts.Constants;
using UnityEngine;

namespace App.Scripts.Interfaces.Currency
{
    [CreateAssetMenu(menuName = PathConstants.StaticDataDir + "/" + nameof(CurrencyStaticData))]
    public class CurrencyStaticData : ScriptableObject
    {
        [SerializeField] private CurrencyId _currencyId;
        
        public CurrencyId CurrencyId => _currencyId;
    }
}