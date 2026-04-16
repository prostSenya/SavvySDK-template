using System;
using App.Scripts.Services.Windows.Buttons;
using TMPro;
using UnityEngine;

namespace App.Scripts.Services.Windows.Confirmation
{
    public class ConfirmationWindow : WindowBase
    {
        [SerializeField] private TMP_Text _description;
        
        [Header("Buttons")]
        [SerializeField] private ActionButton _confirmBtn;
        [SerializeField] private ActionButton _cancelBtn;

        private Action _confirm;
        private Action _cancel;

        public void Construct(string description, Action confirm, Action cancel, string confirmText, string cancelText)
        {
            _description.text = description;
            _confirm = confirm;
            _cancel = cancel;

            _confirmBtn.Construct(Confirm, confirmText);
            _cancelBtn.Construct(Cancel, cancelText);
        }
        
        private void Confirm()
        {
            _confirm?.Invoke();
            Close();
        }

        private void Cancel()
        {
            _cancel?.Invoke();
            Close();
        }
    }
}