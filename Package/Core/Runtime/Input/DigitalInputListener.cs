using System;
using SOA.Base;
using SOA.Common.Primitives;
using UnityEngine;
using UnityEngine.Events;
using SerializedMonoBehaviour = OdinSerializer.SerializedMonoBehaviour;

namespace TheLuxGames.SharedResources.Input
{
    public class DigitalInputListener : SerializedMonoBehaviour, IRegisteredReferenceContainer
    {
        [Serializable]
        internal class InputActiveEvents
        {
            [SerializeField] internal FloatUnityEvent _onActive;

            [SerializeField] internal UnityEvent _onActiveStarted;

            [SerializeField] internal FloatUnityEvent _onActiveEnded;
        }

        [SerializeField] private IInput _input;

        [SerializeField] private InputActiveEvents _events = new InputActiveEvents();

        //TODO Implement commented
        [SerializeField, /*HideInEditorMode,*/ Disable]
        internal float _timeActive;


        void Update()
        {
            if (_input.Active)
            {
                if (_timeActive <= 0)
                    _events._onActiveStarted.Invoke();
                _timeActive += UnityEngine.Time.deltaTime;
                _events._onActive.Invoke(_timeActive);
            }
            else
            {
                if (_timeActive > 0)
                    _events._onActiveEnded.Invoke(_timeActive);
                _timeActive = 0;
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