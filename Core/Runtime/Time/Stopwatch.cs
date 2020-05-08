using System;
using UnityEngine;
using SOA.Common.Primitives;
using SOA.Base;

namespace TheLuxGames.SharedResources.Time
{
    public class Stopwatch : RegisteredMonoBehaviour
    {
        [SerializeField] private bool _resetOnStart = true;
        [SerializeField] private bool paused = false;

        [SerializeField] private FloatReference _time;
        [SerializeField] private bool _autoListen = true;
        [SerializeField] private StringReference _timeInText;

        void OnEnable()
        {
            if (_time != null && _timeInText != null && _autoListen)
            {
                _time.AddListenerToOnValueChanged(SetTimeInText);
            }
        }

        void Start()
        {
            if (_resetOnStart)
                Reset();
        }

        // Update is called once per frame
        void Update()
        {
            if (paused) return;
            _time.Value += UnityEngine.Time.deltaTime;
        }

        public void SetTimeInText(float seconds)
        {
            var timeSpan = TimeSpan.FromSeconds(seconds);
            _timeInText.Value = timeSpan.ToString().Remove(timeSpan.ToString().Length - 4);
        }

        public void Resume()
        {
            paused = false;
        }

        public void Pause()
        {
            paused = true;
        }

        public void Reset()
        {
            _time.Value = 0f;
        }

        public override void Register()
        {
            _time.Register(this);
            _timeInText.Register(this);
        }
    }
}