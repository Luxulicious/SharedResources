using System;
using UnityEngine;

namespace TheLuxGames.SharedResources.Inspector
{
    [Obsolete("Use TheLuxGames.SharedResources.Inspector.SetComponentHideFlags")]
    [RequireComponent(typeof(Rigidbody2D))]
    [ExecuteAlways]
    public class UneditableRigidbody : MonoBehaviour
    {
        [SerializeField, Disable] private Rigidbody2D _rb;
        [Observe("CheckHide")] public bool hide;

        void OnEnable()
        {
            if (!_rb)
                _rb = this.GetComponent<Rigidbody2D>();
            CheckHide();
        }

        private void CheckHide()
        {
            _rb.hideFlags = !hide ? HideFlags.NotEditable : HideFlags.HideInInspector;
        }

        void OnDisable()
        {
            _rb.hideFlags = HideFlags.None;
        }
    }
}
