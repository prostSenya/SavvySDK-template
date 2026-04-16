using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace App.Scripts.Services.Windows.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ActionButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _buttonText;
        
        private Button _button;
        private UnityAction _onClick;

        private void Awake() =>
            _button = GetComponent<Button>();

        public void Construct(UnityAction onClick, string buttonText = null)                   
        {
            _onClick = onClick;

            if (_buttonText && !string.IsNullOrEmpty(buttonText)) 
                _buttonText.text = buttonText;
            
            _button.onClick.AddListener(_onClick);
        }

        private void OnDestroy() => 
            _button.onClick.RemoveListener(_onClick);
    }
}