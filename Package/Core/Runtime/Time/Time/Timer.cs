using System;
using OdinSerializer;
using SOA.Base;
using SOA.Common.Primitives;
using UnityEngine;
using UnityEngine.Events;

namespace TheLuxGames.SharedResources.Time
{
    //TODO Might need an update
    [ExecuteAlways]
    public class Timer : SerializedMonoBehaviour, IRegisteredReferenceContainer
    {
        [SerializeField] private bool _paused;

        [SerializeField]
        private FloatReference _defaultTime = new FloatReference(10) {Persistence = Persistence.Constant};

        [SerializeField] private FloatReference _time = new FloatReference(10);

        [Serializable]
        internal class Events
        {
            [Serializable]
            internal class FloatUnityEvent : UnityEvent<float>
            {
            }

            [SerializeField] internal FloatUnityEvent _onTimeUp = new FloatUnityEvent();
            [SerializeField] internal FloatUnityEvent _onReset = new FloatUnityEvent();
            [SerializeField] internal FloatUnityEvent _onPause = new FloatUnityEvent();
            [SerializeField] internal FloatUnityEvent _onResume = new FloatUnityEvent();
        }

        [SerializeField] private Events _events = new Events();

        //TODO Replace with decorator/filter
        [Serializable]
        internal class Filtered
        {
            //TODO Replace with decorator/filter 
            //TODO Disable value from being edited from within the inspector
            [SerializeField] internal FloatReference _percentageOfTimeLeftFromDefault = new FloatReference()
                {Persistence = Persistence.Variable, Scope = Scope.Local, Value = 10};
        }

        //TODO Replace with decorator/filter
        [SerializeField] private Filtered _filtered = new Filtered();

        private void Update()
        {
            if (Application.isPlaying)
                Tick();
            else
                UpdatePercentageLeft();
        }

        public void Tick()
        {
            if (_paused || _time.Value <= 0) return;
            Time = Mathf.Clamp(Time - UnityEngine.Time.deltaTime, 0, Mathf.Infinity);
            UpdatePercentageLeft();
            if (!(_time.Value < 0) && !(_time.Value > 0)) _events._onTimeUp.Invoke(_time.Value);
        }

        private void UpdatePercentageLeft()
        {
            _filtered._percentageOfTimeLeftFromDefault.Value = _time.Value * 100 / _defaultTime.Value;
        }

        public void PauseTimer()
        {
            Paused = true;
        }

        public void ResumeTimer()
        {
            Paused = false;
        }

        public void ResetTimer()
        {
            _time.Value = _defaultTime.Value;
            _events._onReset.Invoke(_time.Value);
        }

        public float Time
        {
            get => _time.Value;
            set
            {
                _time.Value = value;
                UpdatePercentageLeft();
            }
        }

        public bool Paused
        {
            get => _paused;
            set
            {
                if (_paused == value) return;
                _paused = value;
                if (_paused)
                    _events._onPause.Invoke(_time.Value);
                else
                    _events._onResume.Invoke(_time.Value);
            }
        }

        public void Register()
        {
            _time.Register(this);
            _defaultTime.Register(this);
        }

        protected override void OnAfterDeserialize()
        {
            base.OnAfterDeserialize();
            Register();
        }

        protected override void OnBeforeSerialize()
        {
            base.OnBeforeSerialize();
            Register();
        }
    }
}