using System;
using App.Scripts.Constants;
using App.Scripts.Extensions.StaticData;
using App.Scripts.Interfaces.UI;
using App.Scripts.Interfaces.Windows;
using App.Scripts.Services.Windows.Confirmation;
using App.Scripts.Services.Windows.Error;
using App.Scripts.Services.Windows.Game;
using App.Scripts.Services.Windows.Info;
using App.Scripts.Services.Windows.Menu;
using App.Scripts.Services.Windows.RateUs;
using Savvy.Container;
using Savvy.Interfaces;

namespace App.Scripts.Services.Windows
{
    public class WindowsFactory : NetSavvyResources, IWindowsFactory
    {
        private readonly string _settingsPath = $"{PathConstants.ServicesDir}/{nameof(WindowsSettings)}";
        private readonly WindowsSettings _settings;

        private IUIService _uiService;
        private IGameObjectFactory _gameObjectFactory;

        public WindowsFactory() => 
            _settings = LoadResources<WindowsSettings>(_settingsPath);

        public void Inject()
        {
            _uiService = GetService<IUIService>();
            _gameObjectFactory = GetService<IGameObjectFactory>();
        }

        public void CreateInfo(string description) =>
            InstantiateWindow<InfoWindow>(WindowId.Info)
                .Construct(description);

        public void CreateError(string description) =>
            InstantiateWindow<ErrorWindow>(WindowId.Error)
                .Construct(description);

        public void CreateConfirmation(string description, Action confirm, Action cancel,
            string confirmText, string cancelText) =>
            InstantiateWindow<ConfirmationWindow>(WindowId.Confirmation)
                .Construct(description, confirm, cancel, confirmText, cancelText);

        public void CreateRateUsWindow() =>
            InstantiateWindow<RateUsWindow>(WindowId.RateUs)
                .Construct();

        public void CreateRateUsStars() =>
            InstantiateWindow<RateUsStarsWindow>(WindowId.RateUsStars)
                .Construct();

        public void CreateRateUsFeedback() =>
            InstantiateWindow<RateUsFeedbackWindow>(WindowId.RateUsFeedback)
                .Construct();

        public void CreateMenu() =>
            InstantiateWindow<MenuWindow>(WindowId.Menu)
                .Construct();

        public void CreateGame() =>
            InstantiateWindow<GameWindow>(WindowId.Game)
                .Construct();

        private TWindow InstantiateWindow<TWindow>(WindowId windowId) where TWindow : WindowBase
        {
            Debug($"Create window by '{windowId}'", _settings.Debug);
            var staticData = windowId.GetStaticData();
            return _gameObjectFactory.Instantiate(staticData.WindowPrefab, _uiService.UiTransform) as TWindow;
        }
    }
}