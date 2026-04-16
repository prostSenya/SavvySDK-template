using System;
using System.Collections;
using Savvy.Container;
using Savvy.Interfaces;
using UnityEngine;

namespace App.Scripts.Logic.Curtain
{
    public class CurtainController : MonoSavvy, ICurtain
    {
        [SerializeField] private GameObject _background;
        [SerializeField] private float _delay = 0.25f;
        
        private ICoroutineRunnerService _coroutineRunnerService;
        private Action _showFinished;
        private Action _hideFinished;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _coroutineRunnerService = GetService<ICoroutineRunnerService>();
        }

        public void Show(Action finished)
        {
            _showFinished = finished;
            _coroutineRunnerService.StartCoroutine(ShowCoroutine());
        }

        public void Hide(Action finished)
        {
            _hideFinished = finished;
            _coroutineRunnerService.StartCoroutine(HideCoroutine());
        }

        private IEnumerator ShowCoroutine()
        {
            _background.SetActive(true);
            yield return new WaitForSeconds(_delay);
            OnShowFinished();
        }

        private IEnumerator HideCoroutine()
        {
            _background.SetActive(true);
            yield return new WaitForSeconds(_delay);
            OnHideFinished();
        }

        private void OnShowFinished() => 
            _showFinished?.Invoke();

        private void OnHideFinished()
        {
            _background.SetActive(false);
            _hideFinished?.Invoke();
        }
    }
}