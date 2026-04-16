using App.Scripts.Constants;
using Savvy.Container;
using Savvy.Extensions;
using Savvy.Interfaces;
using TMPro;

namespace App.Scripts.Logic.Mediation
{
    public class InterstitialAdCountdown : MonoSavvy
    {
        private IMediationService _mediationService;
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponentInChildren<TMP_Text>();
            _mediationService = GetService<IMediationService>();
            _mediationService.InterstitialAdTimerUpdate += OnInterstitialAdTimerUpdate;
        }

        private void OnDestroy() => 
            _mediationService.InterstitialAdTimerUpdate -= OnInterstitialAdTimerUpdate;

        private void OnInterstitialAdTimerUpdate(int time) => 
            _text.text = LocalizationConstants.AdvertisingViaKey.ToLocalization(time);
    }
}