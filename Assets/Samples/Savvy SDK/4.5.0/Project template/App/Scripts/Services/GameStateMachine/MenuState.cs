using App.Scripts.Interfaces;
using App.Scripts.Interfaces.UI;
using App.Scripts.Interfaces.Windows;
using Savvy.Container;
using Savvy.Interfaces;

namespace App.Scripts.Services.GameStateMachine
{
    public class MenuState : NetSavvy, IState
    {
        private const string SceneName = nameof(SceneNames.Menu);

        private readonly IUIService _uiService;
        private readonly IWindowsFactory _windowsFactory;
        private readonly ISceneLoaderService _sceneLoaderService;
        private readonly ICurtainService _curtainService;
        private readonly IAudioService _audioService;
        
        public MenuState()
        {
            _uiService = GetService<IUIService>();
            _windowsFactory = GetService<IWindowsFactory>();
            _sceneLoaderService = GetService<ISceneLoaderService>();
            _curtainService = GetService<ICurtainService>();
            _audioService = GetService<IAudioService>();
        }

        public void Enter() => 
            _curtainService.Show(LoadScene);
        
        private void LoadScene() => 
            _sceneLoaderService.LoadSceneAsync(SceneName, OnLoaded);
        
        private void OnLoaded()
        {
            _audioService.InitAudioMixerGroup();
            _uiService.UISceneSetup();
            _windowsFactory.CreateMenu();
            _curtainService.Hide();
        }
    }
}