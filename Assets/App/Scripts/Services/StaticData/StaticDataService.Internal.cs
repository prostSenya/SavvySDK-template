using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Constants;
using App.Scripts.Interfaces.StaticData;
using UnityEngine;

namespace App.Scripts.Services.StaticData
{
    public partial class StaticDataService
    {
        private const string ServicesDir = PathConstants.ServicesDir;

        private readonly string _settingsPath = $"{PathConstants.ServicesDir}/{nameof(StaticDataSettings)}";
        private readonly StaticDataSettings _settings;
        private readonly Dictionary<Type, IStaticDataProvider> _providers = new();

        public StaticDataService()
        {
            _settings = LoadResources<StaticDataSettings>(_settingsPath);
            LoadStaticData();
        }

        public TStaticData GetStaticData<TStaticData>(Enum id) where TStaticData : ScriptableObject
        {
            if (_providers.TryGetValue(typeof(TStaticData), out var provider))
            {
                Debug($"Retrieved '{typeof(TStaticData).Name}' with key '{id}'", _settings.Debug);
                return provider.Get(id) as TStaticData;
            }

            Error($"'{typeof(TStaticData).Name}' not found with key '{id}'");
            return null;
        }

        public Dictionary<TEnum, TStaticData> GetStaticData<TEnum, TStaticData>()
            where TEnum : struct, Enum
            where TStaticData : ScriptableObject
        {
            if (_providers.TryGetValue(typeof(TStaticData), out var provider))
            {
                Debug($"Retrieved Dictionary '{typeof(TStaticData).Name}' with key '{typeof(TEnum).Name}'",
                    _settings.Debug);
                return provider.GetAll() as Dictionary<TEnum, TStaticData>;
            }

            Error($"'{typeof(TStaticData).Name}' not found with key '{typeof(TEnum).Name}'");
            return null;
        }

        private void LoadAndRegister<TEnum, TStaticData>(
            Func<TStaticData, TEnum> keySelector)
            where TEnum : struct, Enum
            where TStaticData : ScriptableObject
        {
            var map = LoadResourcesAll<TStaticData>(GetResourcesPath<TStaticData>())
                .OrderBy(keySelector)
                .ToDictionary(keySelector, x => x);

            Register(map);
        }

        private void Register<TEnum, TData>(Dictionary<TEnum, TData> map)
            where TEnum : struct, Enum
            where TData : ScriptableObject
        {
            _providers[typeof(TData)] = new StaticDataProvider<TEnum, TData>(map);
            Debug($"Registered static data for type '{typeof(TData).Name}' with {map.Count} entries", _settings.Debug);
        }

        private string GetResourcesPath<TStaticData>() =>
            $"{ServicesDir}/{typeof(TStaticData).Name}";
    }
}