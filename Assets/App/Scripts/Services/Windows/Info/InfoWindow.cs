using App.Scripts.Services.Windows.Buttons;
using TMPro;
using UnityEngine;

namespace App.Scripts.Services.Windows.Info
{
    public class InfoWindow : WindowBase
    {
        [SerializeField] private TMP_Text _description;

        [Header("Buttons")]
        [SerializeField] private ActionButton _okBtn;
        
        public void Construct(string description)
        {
            _description.text = description;
            _okBtn.Construct(Close);
        }
    }
}