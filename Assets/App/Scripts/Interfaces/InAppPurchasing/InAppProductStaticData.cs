using System;
using App.Scripts.Constants;
using Savvy.Interfaces;
using UnityEngine;

namespace App.Scripts.Interfaces.InAppPurchasing
{
    [CreateAssetMenu(menuName = PathConstants.StaticDataDir + "/" + nameof(InAppProductStaticData))]
    public class InAppProductStaticData : ProductStaticData
    {
        [SerializeField] private InAppProductId _inAppProductId;
        [SerializeField] private string _googlePlayProductId = "com.company_name.product_name.product_id";
        [SerializeField] private string _appleAppProductId = "com.company_name.product_name.product_id";

        public override Enum InAppProductId => _inAppProductId;
        public override string GooglePlayProductId => _googlePlayProductId;
        public override string AppleAppProductId => _appleAppProductId;
    }
}