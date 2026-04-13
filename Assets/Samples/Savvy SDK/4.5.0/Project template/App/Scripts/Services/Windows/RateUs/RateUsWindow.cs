using App.Scripts.Services.Windows.Buttons;
using Savvy.Interfaces;
using UnityEngine;

namespace App.Scripts.Services.Windows.RateUs
{
    public class RateUsWindow : WindowBase
    {
        [Header("Buttons")]
        [SerializeField] private ActionButton _yesBtn;
        [SerializeField] private ActionButton _notBtn;
        
        private ISocialService _socialService;

        protected override void OnAwake()
        {
            _socialService = GetService<ISocialService>();
            _socialService.SetActiveRateUs(false);
        }
        
        public void Construct()
        {
            _yesBtn.Construct(OpenRateUsStars);
            _notBtn.Construct(OpenRateUsFeedback);
        }
        
        private void OpenRateUsStars()
        {
            _windowsFactory.CreateRateUsStars();
            Close();
        }
        
        private void OpenRateUsFeedback()
        {
            _windowsFactory.CreateRateUsFeedback();
            Close();
        }
    }
}