using System;
using UnityEngine;

namespace App.Scripts.Interfaces.StaticData
{
    public interface IStaticDataProvider
    {
        ScriptableObject Get(Enum id);
        object GetAll();
    }
}