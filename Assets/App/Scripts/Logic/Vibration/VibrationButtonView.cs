using App.Scripts.Interfaces.Vibration;
using Savvy.Container;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Logic.Vibration
{
    public class VibrationButtonView : MonoSavvy
    {
        [SerializeField] private Button _button;
        [SerializeField] private VibrationForce _force;

        private ICustomVibrationService _vibrationService;

        private void Awake()
        {
            _vibrationService = GetService<ICustomVibrationService>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _vibrationService.Vibrate(_force);
        }
    }
}
