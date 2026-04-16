using App.Scripts.Interfaces.GameNavigation;
using Savvy.Container;
using Savvy.Interfaces;

namespace App.Scripts.Services.GameStateMachine
{
    public class LoadState : NetSavvy, IState
    {
        private readonly IGameNavigationService _gameNavigationService;

        public LoadState() => 
            _gameNavigationService = GetService<IGameNavigationService>();

        public void Enter() => 
            _gameNavigationService.ToMenu();
    }
}