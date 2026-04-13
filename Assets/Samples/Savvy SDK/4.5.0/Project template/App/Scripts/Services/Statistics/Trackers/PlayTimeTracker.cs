using System.Collections;
using App.Scripts.Interfaces.Analytics;
using App.Scripts.Interfaces.SaveLoad;
using App.Scripts.Interfaces.Statistics.PlayTime;
using Savvy.Constants;
using Savvy.Container;
using Savvy.Interfaces;
using UnityEngine;

namespace App.Scripts.Services.Statistics.Trackers
{
    public class PlayTimeTracker : NetSavvy, IPlayTimeTracker
    {
        private readonly IAnalyticsService _analyticsService;
        private readonly ICoroutineRunnerService _coroutineRunnerService;
        private readonly bool _debug;

        private Coroutine _coroutine;
        private long _playTimeSec;

        public PlayTimeTracker(bool debug, long playTimeSec)
        {
            _analyticsService = GetService<IAnalyticsService>();
            _coroutineRunnerService = GetService<ICoroutineRunnerService>();
            _debug = debug;
            _playTimeSec = playTimeSec;

            if (_coroutine == null)
                _coroutine = _coroutineRunnerService.StartCoroutine(TrackPlaytimeCoroutine());
        }

        public void UpdateProgress(ref ProgressData data) =>
            data.PlayTimeSec = _playTimeSec;

        public void Dispose()
        {
            if (_coroutine != null)
            {
                _coroutineRunnerService.StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator TrackPlaytimeCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(SecConstants.Sec);

                _playTimeSec++;

                Debug($"Update '{nameof(_playTimeSec)}' = {_playTimeSec}", _debug);

                if (_playTimeSec % SecConstants.Min == 0)
                    _analyticsService.SendEvent(GetPlayTimeData());
            }
        }

        private PlayTimeData GetPlayTimeData() => new()
        {
            PlayTime = _playTimeSec / SecConstants.Min
        };
    }
}