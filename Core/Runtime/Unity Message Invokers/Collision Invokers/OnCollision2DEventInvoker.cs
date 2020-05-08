using System;
using UnityEngine;
using UnityEngine.Events;

namespace TheLuxGames.SharedResources.UnityMessageInvocation
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class OnCollision2DEventInvoker : MonoBehaviour
    {
        [Serializable]
        protected class Collision2DEvent : UnityEvent<Collision2D>
        {
        }

        [SerializeField] protected Collision2DEvent _callback = new Collision2DEvent();

#if UNITY_EDITOR
        public virtual void AddPersistentListener(UnityAction<Collision2D> action)
        {
            Debug.Log($"Added persistent listener to event {_callback} with action {action}");
            UnityEditor.Events.UnityEventTools.AddPersistentListener(_callback, action);
        }

        public virtual void RemovePersistentListener(UnityAction<Collision2D> action)
        {
            Debug.Log($"Removed persistent listener from event {_callback} with action {action}");
            UnityEditor.Events.UnityEventTools.RemovePersistentListener(_callback, action);
        }
#endif

        public virtual void AddListener(UnityAction<Collision2D> action)
        {
            _callback.AddListener(action);
        }

        public virtual void RemoveListener(UnityAction<Collision2D> action)
        {
            _callback.RemoveListener(action);
        }

        public virtual void Invoke(Collision2D data)
        {
            _callback.Invoke(data);
        }
    }
}