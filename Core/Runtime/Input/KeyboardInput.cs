using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace TheLuxGames.SharedResources.Input
{
    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardUpClickEvent : UnityEvent<float>
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardDownClickEvent : UnityEvent<float>
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardLeftClickEvent : UnityEvent<float>
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardRightClickEvent : UnityEvent<float>
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardRestartClickEvent : UnityEvent<float>
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardUpUpEvent : UnityEvent<float>
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardDownUpEvent : UnityEvent<float>
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardLeftUpEvent : UnityEvent<float>
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardRightUpEvent : UnityEvent<float>
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardUpDownEvent : UnityEvent
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardDownDownEvent : UnityEvent
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardLeftDownEvent : UnityEvent
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    [Serializable]
    public class KeyboardRightDownEvent : UnityEvent
    {
    }

    [Obsolete("Use DigitalInputListener instead")]
    public class KeyboardInput : MonoBehaviour
    {
        [Header("Controls")] [SerializeField] private KeyCode _up = KeyCode.W;
        [SerializeField] private KeyCode _down = KeyCode.S;
        [SerializeField] private KeyCode _left = KeyCode.A;
        [SerializeField] private KeyCode _right = KeyCode.D;
        [SerializeField] private KeyCode _restart = KeyCode.R;

        [Space] [Header("Keyboard Events")] [SerializeField]
        private KeyboardUpClickEvent _keyboardUpClickEvent = new KeyboardUpClickEvent();

        [SerializeField] private KeyboardDownClickEvent _keyboardDownClickEvent = new KeyboardDownClickEvent();
        [SerializeField] private KeyboardLeftClickEvent _keyboardLeftClickEvent = new KeyboardLeftClickEvent();
        [SerializeField] private KeyboardRightClickEvent _keyboardRightClickEvent = new KeyboardRightClickEvent();
        [SerializeField] private KeyboardRestartClickEvent _keyboardRestartClickEvent = new KeyboardRestartClickEvent();

        [Space] [Header("Keyboard Down Events")] [SerializeField]
        private KeyboardUpDownEvent _keyboardUpDownEvent = new KeyboardUpDownEvent();

        [SerializeField] private KeyboardDownDownEvent _keyboardDownDownEvent = new KeyboardDownDownEvent();
        [SerializeField] private KeyboardLeftDownEvent _keyboardLeftDownEvent = new KeyboardLeftDownEvent();
        [SerializeField] private KeyboardRightDownEvent _keyboardRightDownEvent = new KeyboardRightDownEvent();

        [Space] [Header("Keyboard Up Events")] [SerializeField]
        private KeyboardUpUpEvent _keyboardUpUpEvent = new KeyboardUpUpEvent();

        [SerializeField] private KeyboardDownUpEvent _keyboardDownUpEvent = new KeyboardDownUpEvent();
        [SerializeField] private KeyboardLeftUpEvent _keyboardLeftUpEvent = new KeyboardLeftUpEvent();
        [SerializeField] private KeyboardRightUpEvent _keyboardRightUpEvent = new KeyboardRightUpEvent();



        private float _keyboardUpClickTime;
        private float _keyboardDownClickTime;
        private float _keyboardLeftClickTime;
        private float _keyboardRightClickTime;
        private float _keyboardRestartClickTime;

        void Start()
        {
            List<KeyCode> keys = new List<KeyCode>();
            keys.Add(_up);
            keys.Add(_down);
            keys.Add(_left);
            keys.Add(_right);
            keys.Add(_restart);
            if (keys.Count != keys.Distinct().Count())
            {
                throw new Exception("Duplicate input!");
            }
        }


        void FixedUpdate()
        {
            //Up
            if (UnityEngine.Input.GetKey(_up))
            {
                if (_keyboardUpClickTime <= 0)
                    _keyboardUpDownEvent.Invoke();
                _keyboardUpClickTime += UnityEngine.Time.deltaTime;
                _keyboardUpClickEvent.Invoke(_keyboardUpClickTime);
            }
            else
            {
                if (_keyboardUpClickTime > 0)
                    _keyboardUpUpEvent.Invoke(_keyboardUpClickTime);
                _keyboardUpClickTime = 0;
            }

            //Down
            if (UnityEngine.Input.GetKey(_down))
            {
                if (_keyboardDownClickTime <= 0)
                    _keyboardDownDownEvent.Invoke();
                _keyboardDownClickTime += UnityEngine.Time.deltaTime;
                _keyboardDownClickEvent.Invoke(_keyboardDownClickTime);
            }
            else
            {
                if (_keyboardDownClickTime > 0)
                    _keyboardDownUpEvent.Invoke(_keyboardDownClickTime);
                _keyboardDownClickTime = 0;
            }

            //Left
            if (UnityEngine.Input.GetKey(_left))
            {
                if (_keyboardLeftClickTime <= 0)
                    _keyboardLeftDownEvent.Invoke();
                _keyboardLeftClickTime += UnityEngine.Time.deltaTime;
                _keyboardLeftClickEvent.Invoke(_keyboardLeftClickTime);
            }
            else
            {
                if (_keyboardLeftClickTime > 0)
                    _keyboardLeftUpEvent.Invoke(_keyboardLeftClickTime);
                _keyboardLeftClickTime = 0;
            }

            //Right
            if (UnityEngine.Input.GetKey(_right))
            {
                if (_keyboardRightClickTime <= 0)
                    _keyboardRightDownEvent.Invoke();
                _keyboardRightClickTime += UnityEngine.Time.deltaTime;
                _keyboardRightClickEvent.Invoke(_keyboardRightClickTime);
            }
            else
            {
                if (_keyboardRightClickTime > 0)
                    _keyboardRightUpEvent.Invoke(_keyboardRightClickTime);
                _keyboardRightClickTime = 0;
            }

            //Restart
            if (UnityEngine.Input.GetKey(_restart))
            {
                _keyboardRestartClickTime += UnityEngine.Time.deltaTime;
                _keyboardRestartClickEvent.Invoke(_keyboardRestartClickTime);
            }
            else
            {
                _keyboardRestartClickTime = 0;
            }

        }
    }
}
