using System;
using UnityEngine;
using UnityEngine.Events;

namespace TheLuxGames.SharedResources.UnityMessageInvocation
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class OnTrigger2DEventInvoker : MonoBehaviour
    {
        [Serializable]
        protected class Collider2DEvent : UnityEvent<Collider2D>
        {
        }

        [SerializeField] protected Collider2DEvent _callback = new Collider2DEvent();

#if UNITY_EDITOR
        public virtual void AddPersistentListener(UnityAction<Collider2D> action)
        {
            Debug.Log($"Added persistent listener to event {_callback} with action {action}");
            UnityEditor.Events.UnityEventTools.AddPersistentListener(_callback, action);
        }

        public virtual void RemovePersistentListener(UnityAction<Collider2D> action)
        {
            Debug.Log($"Removed persistent listener from event {_callback} with action {action}");
            UnityEditor.Events.UnityEventTools.RemovePersistentListener(_callback, action);
        }
#endif

        public virtual void AddListener(UnityAction<Collider2D> action)
        {
            _callback.AddListener(action);
        }

        public virtual void RemoveListener(UnityAction<Collider2D> action)
        {
            _callback.RemoveListener(action);
        }

        public virtual void Invoke(Collider2D data)
        {
            _callback.Invoke(data);
        }


    }
}