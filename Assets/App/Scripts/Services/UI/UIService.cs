using System.Collections.Generic;
using App.Scripts.Constants;
using App.Scripts.Interfaces.UI;
using Savvy.Container;
using Savvy.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Scripts.Services.UI
{
    public class UIService : NetSavvyResources, IUIService
    {
        private readonly string _settingsPath = $"{PathConstants.ServicesDir}/{nameof(UISettings)}";
        private readonly UISettings _settings;
        
        private readonly List<Behaviour> _inputBehaviours = new();
        
        public Camera UICamera { get; private set; }
        public Transform UiTransform { get; private set; }
        
        private IGameObjectFactory _gameObjectFactory;

        public UIService() => 
            _settings = LoadResources<UISettings>(_settingsPath);

        /// <summary>
        /// Если в сервисе нужно запросить другой сервис!
        /// </summary>
        public void Inject() => 
            _gameObjectFactory = GetService<IGameObjectFactory>();
        
        public void UISceneSetup()
        {
            UICamera = _gameObjectFactory.Instantiate(_settings.UICamera);
            
            var uiCanvas = _gameObjectFactory.Instantiate(_settings.UICanvas);
            uiCanvas.worldCamera = UICamera;
            
            UiTransform = uiCanvas.transform;
            
            _inputBehaviours.Clear();
            AddBehaviour(UICamera.GetComponent<Physics2DRaycaster>());
            AddBehaviour(uiCanvas.GetComponent<GraphicRaycaster>());
            
            Debug("Scene setup", _settings.Debug);
        }
        
        public void DisableInput()
        {
            Debug("Disable UI input", _settings.Debug);
            
            foreach (var behaviour in _inputBehaviours) 
                behaviour.enabled = false;
        }

        public void EnableInput()
        {
            Debug("Enable UI input", _settings.Debug);
            
            foreach (var behaviour in _inputBehaviours) 
                behaviour.enabled = true;
        }
        
        private void AddBehaviour(Behaviour behaviour)
        {
            if (behaviour)
                _inputBehaviours.Add(behaviour);
        }
    }
}