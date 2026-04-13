using System;
using System.Collections.Generic;
using Savvy.Interfaces;
using UnityEngine;

namespace App.Scripts.Interfaces.StaticData
{
    public interface IStaticDataService : IService
    {
        Dictionary<TEnum, TStaticData> GetStaticData<TEnum, TStaticData>()
            where TEnum : struct, Enum
            where TStaticData : ScriptableObject;

        TStaticData GetStaticData<TStaticData>(Enum id) where TStaticData : ScriptableObject;
    }
}