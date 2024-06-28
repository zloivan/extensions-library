// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityExtensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Check if the transform is within a certain distance and optionally within a certain angle (FOV) from the target transform.
        /// </summary>
        /// <param name="source">The transform to check.</param>
        /// <param name="target">The target transform to compare the distance and optional angle with.</param>
        /// <param name="maxDistance">The maximum distance allowed between the two transforms.</param>
        /// <param name="maxAngle">The maximum allowed angle between the transform's forward vector and the direction to the target (default is 360).</param>
        /// <returns>True if the transform is within range and angle (if provided) of the target, false otherwise.</returns>
        public static bool InRangeOf(this Transform source, Transform target, float maxDistance, float maxAngle = 360f)
        {
            var directionToTarget = (target.position - source.position).With(y: 0);
            return directionToTarget.magnitude <= maxDistance &&
                   Vector3.Angle(source.forward, directionToTarget) <= maxAngle / 2;
        }

        /// <summary>
        /// Resets transform's position, scale and rotation
        /// </summary>
        /// <param name="transform">Transform to use</param>
        public static void Reset(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public static IEnumerable<Transform> Children(this Transform parent)
        {
            foreach (Transform child in parent)
            {
                yield return child;
            }
        }

        public static IEnumerable<Transform> ActiveChildren(this Transform parent)
        {
            return parent.Children().Where(x => x.gameObject.activeInHierarchy);
        }

        public static void DestroyChildren(this Transform parent)
        {
            parent.ForEveryChild(child => Object.Destroy(child.gameObject));
        }

        /// <summary>
        /// Immediately destroys all child game objects of the given transform.
        /// </summary>
        /// <param name="parent">The Transform whose child game objects are to be immediately destroyed.</param>
        public static void DestroyChildrenImmediate(this Transform parent)
        {
            parent.ForEveryChild(child => Object.DestroyImmediate(child.gameObject));
        }

        public static void EnableChildren(this Transform parent)
        {
            parent.ForEveryChild(child => child.gameObject.SetActive(true));
        }

        public static void DisableChildren(this Transform parent)
        {
            parent.ForEveryChild(child => child.gameObject.SetActive(false));
        }

        public static void ForEveryChild(this Transform parent, System.Action<Transform> action)
        {
            for (var i = parent.childCount - 1; i >= 0; i--)
            {
                action(parent.GetChild(i));
            }
        }
    }
}