using App.Scripts.Services.Windows.Buttons;
using Savvy.Interfaces;
using UnityEngine;

namespace App.Scripts.Services.Windows.RateUs
{
    public class RateUsFeedbackWindow : WindowBase
    {
        [Header("Buttons")]
        [SerializeField] private ActionButton _feedbackBtn;
        [SerializeField] private ActionButton _closeBtn;
        
        private ISocialService _socialService;

        protected override void OnAwake() => 
            _socialService = GetService<ISocialService>();

        public void Construct()
        {
            _feedbackBtn.Construct(Feedback);
            _closeBtn.Construct(Close);
        }

        private void Feedback()
        {
            _socialService.OpenMail();
            Close();
        }
    }
}