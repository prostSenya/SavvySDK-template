using Savvy.Interfaces;
using UnityEngine;

namespace App.Scripts.Interfaces.UI
{
    public interface IUIService : IService
    {
        Camera UICamera { get; }
        Transform UiTransform { get; }
        void UISceneSetup();
        void DisableInput();
        void EnableInput();
    }
}