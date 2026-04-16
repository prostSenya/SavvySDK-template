using App.Scripts.Interfaces.GameNavigation;
using App.Scripts.Services.Windows.Buttons;
using UnityEngine;

namespace App.Scripts.Services.Windows.Game
{
    public class GameWindow : WindowBase
    {
        [Header("Buttons")]
        [SerializeField] private ActionButton _exitBtn;
        
        private IGameNavigationService _gameNavigationService;

        protected override void OnAwake() => 
            _gameNavigationService = GetService<IGameNavigationService>();

        public void Construct() => 
            _exitBtn.Construct(ToMenu);

        private void ToMenu() => 
            _gameNavigationService.ToMenu();
    }
}