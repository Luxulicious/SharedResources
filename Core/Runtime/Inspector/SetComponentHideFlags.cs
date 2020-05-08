using System.Linq;
using UnityEngine;

namespace TheLuxGames.SharedResources.Inspector
{
    [ExecuteAlways]
    public class SetComponentsHideFlags : MonoBehaviour
    {
        private Component[] _prevComponents;
        [SerializeField] private Component[] _components;
        private HideFlags _previousFlags = HideFlags.None;
        [SerializeField] private HideFlags _flags = HideFlags.None;

        void Update()
        {
            if (_previousFlags != _flags)
            {
                foreach (var component in _components)
                {
                    component.hideFlags = _flags;
                }
            }
            else
                foreach (var component in _components.Except(_prevComponents))
                {
                    component.hideFlags = _flags;
                }

            _previousFlags = _flags;
            _prevComponents = _components;
        }
    }
}