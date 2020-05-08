using System;
using UnityEngine;
using UnityEngine.Events;

namespace TheLuxGames.SharedResources.UnityMessageInvocation
{
    public class VoidEventInvoker : MonoBehaviour
    {
        [Serializable]
        protected class VoidEvent : UnityEvent
        {
        }

        [SerializeField] protected VoidEvent _callback = new VoidEvent();
    }
}