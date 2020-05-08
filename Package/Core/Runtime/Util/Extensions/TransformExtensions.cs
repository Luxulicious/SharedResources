using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheLuxGames.SharedResources.Extensions
{
    public static class TransformExtensions
    {
        public static T[] GetComponentsInEntireTransformHierarchy<T>(this Transform transform) where T : Component
        {
            var componentsFound = new HashSet<T>();
            var thisComponents = transform.GetComponents<T>();
            componentsFound.AddRange(thisComponents);
            var lowerComponents = transform.root.GetComponentsLowerInHierarchy<T>();
            componentsFound.AddRange(lowerComponents);
            return componentsFound.OrderBy(x => x.transform == transform).ToArray();
        }

        public static T[] GetComponentInHigherHierarchy<T>(this Transform transform) where T : Component
        {
            var upperComponents = new HashSet<T>();
            if (transform.parent != null)
            {
                //Add parent components
                upperComponents.AddRange(transform.GetComponentsInParent<T>());
                //Move to parent and repeat above process
                upperComponents.AddRange(transform.GetComponentInHigherHierarchy<T>());
            }

            return upperComponents.ToArray();
        }

        public static T[] GetComponentsLowerInHierarchy<T>(this Transform transform) where T : Component
        {
            var lowerComponents = new HashSet<T>();
            if (transform.childCount > 0)
            {
                //Add child components
                lowerComponents.AddRange(transform.GetComponentsInChildren<T>());
                //Move to each child and repeat above process
                foreach (Transform child in transform)
                {
                    lowerComponents.AddRange(child.GetComponentsLowerInHierarchy<T>());
                }
            }

            return lowerComponents.ToArray();
        }
    }
}