using App.Scripts.Constants;
using App.Scripts.Interfaces.GameNavigation;
using App.Scripts.Interfaces.GameStateMachine;
using Savvy.Container;
using Savvy.Interfaces;

namespace App.Scripts.Services.GameNavigation
{
    public class GameNavigationService : NetSavvyResources, IGameNavigationService
    {
        private readonly string _settingsPath = $"{PathConstants.ServicesDir}/{nameof(GameNavigationSettings)}";
        private readonly GameNavigationSettings _settings;
        
        private IGameStateMachine _gameStateMachine;
        
        public GameNavigationService() => 
            _settings = LoadResources<GameNavigationSettings>(_settingsPath);

        public void Inject() => 
            _gameStateMachine = GetService<IGameStateMachine>();
        
        public void ToLoad() => 
            NavigateTo(StateType.Load);

        public void ToMenu() => 
            NavigateTo(StateType.Menu);

        public void ToGame() => 
            NavigateTo(StateType.Game);

        private void NavigateTo(StateType stateType)
        {
            Debug($"Go to '{stateType}' state", _settings.Debug);
            _gameStateMachine.Enter(stateType);
        }
    }
}