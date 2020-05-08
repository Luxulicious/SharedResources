using System;
using UnityEngine;

namespace TheLuxGames.SharedResources.Inspector
{
    [Obsolete("Use TheLuxGames.SharedResources.Inspector.SetComponentHideFlags")]
    [ExecuteAlways]
    public class LockedTransform : MonoBehaviour
    {
        [SerializeField] private bool _hide = true;

        void Update()
        {
            if (_hide)
                this.transform.hideFlags = HideFlags.HideInInspector;
            else
                this.transform.hideFlags = HideFlags.NotEditable;
        }
    }
}