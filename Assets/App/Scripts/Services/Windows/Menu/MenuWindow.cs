using App.Scripts.Interfaces.GameNavigation;
using App.Scripts.Services.Windows.Buttons;
using UnityEngine;

namespace App.Scripts.Services.Windows.Menu
{
    public class MenuWindow : WindowBase
    {
        [Header("Buttons")]
        [SerializeField] private ActionButton _playBtn;
        
        private IGameNavigationService _gameNavigationService;

        protected override void OnAwake() => 
            _gameNavigationService = GetService<IGameNavigationService>();

        public void Construct() => 
            _playBtn.Construct(ToGame);
        
        private void ToGame() => 
            _gameNavigationService.ToGame();
    }
}