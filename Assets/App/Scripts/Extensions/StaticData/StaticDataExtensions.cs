using System;
using App.Scripts.Interfaces.Currency;
using App.Scripts.Interfaces.StaticData;
using App.Scripts.Interfaces.Windows;
using Savvy.Container;
using Savvy.Interfaces;
using UnityEngine;

namespace App.Scripts.Extensions.StaticData
{
    public static class StaticDataExtensions
    {
        public static WindowStaticData GetStaticData(this WindowId id) => 
            GetStaticData<WindowStaticData>(id);
        
        public static CurrencyStaticData GetStaticData(this CurrencyId id) => 
            GetStaticData<CurrencyStaticData>(id);
        
        private static TStaticData GetStaticData<TStaticData>(this Enum id) where TStaticData : ScriptableObject =>
            GetService<IStaticDataService>().GetStaticData<TStaticData>(id);
        
        private static TService GetService<TService>() where TService : class, IService => 
            ServiceLocator.Container.GetSingle<TService>();
    }
}