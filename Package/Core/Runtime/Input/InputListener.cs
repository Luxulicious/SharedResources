using System;
using OdinSerializer;
using SOA.Base;
using SOA.Common.Primitives;
using UnityEngine;
using UnityEngine.Events;

namespace TheLuxGames.SharedResources.Input
{
    [Obsolete("Use DigitalInputListener instead")]
    public class InputListener : SerializedMonoBehaviour, IRegisteredReferenceContainer
    {
        //TODO Implement this in editor properly
        [SerializeField] private IInput _input;
        [SerializeField, Disable] private float _activeTime = 0;
        [SerializeField] private FloatUnityEvent _onActiveEvent = new FloatUnityEvent();
        [SerializeField] private UnityEvent _onStartActiveEvent = new UnityEvent();
        [SerializeField] private FloatUnityEvent _onEndActiveEvent = new FloatUnityEvent();


        void Update()
        {
            if (_input.Active)
            {
                if (_activeTime <= 0)
                    _onStartActiveEvent.Invoke();
                _activeTime += UnityEngine.Time.deltaTime;
                _onActiveEvent.Invoke(_activeTime);
            }
            else
            {
                if (_activeTime > 0)
                    _onEndActiveEvent.Invoke(_activeTime);
                _activeTime = 0;
            }
        }

        public void Register()
        {
            var input = _input as IRegisteredReference;
            input?.Register(this);
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