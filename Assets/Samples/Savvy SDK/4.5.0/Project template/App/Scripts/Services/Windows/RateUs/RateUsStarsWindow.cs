using App.Scripts.Services.Windows.Buttons;
using Savvy.Interfaces;
using UnityEngine;

namespace App.Scripts.Services.Windows.RateUs
{
    public class RateUsStarsWindow : WindowBase
    {
        [Header("Buttons")]
        [SerializeField] private ActionButton _rateStarsBtn;
        [SerializeField] private ActionButton _closeBtn;
        
        private ISocialService _socialService;

        protected override void OnAwake() => 
            _socialService = GetService<ISocialService>();

        public void Construct()
        {
            _rateStarsBtn.Construct(RateStars);
            _closeBtn.Construct(Close);
        }
        
        private void RateStars()
        {
            _socialService.OpenStore();
            Close();
        }
    }
}