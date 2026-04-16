using System;
using System.Collections.Generic;
using App.Scripts.Interfaces.StaticData;
using UnityEngine;

namespace App.Scripts.Services.StaticData
{
    public class StaticDataProvider<TEnum, TData> : IStaticDataProvider
        where TEnum : struct, Enum
        where TData : ScriptableObject
    {
        private readonly Dictionary<TEnum, TData> _map;

        public StaticDataProvider(Dictionary<TEnum, TData> map) => 
            _map = map;

        public ScriptableObject Get(Enum id) =>
            id is TEnum key ? _map.GetValueOrDefault(key) : null;

        public object GetAll() =>
            _map;
    }
}