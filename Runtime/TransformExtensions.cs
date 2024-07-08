// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Checks if the transform is within a certain distance and optionally within a certain angle (FOV) from the target transform.
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
        /// Resets the transform's position, scale, and rotation to their default values.
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        public static void Reset(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Gets an enumerable collection of the transform's children.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
        /// <returns>An enumerable collection of the parent transform's children.</returns>
        public static IEnumerable<Transform> Children(this Transform parent)
        {
            foreach (Transform child in parent)
            {
                yield return child;
            }
        }

        /// <summary>
        /// Gets an enumerable collection of the transform's active children.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
        /// <returns>An enumerable collection of the parent transform's active children.</returns>
        public static IEnumerable<Transform> ActiveChildren(this Transform parent)
        {
            return parent.Children().Where(x => x.gameObject.activeInHierarchy);
        }

        /// <summary>
        /// Destroys all child game objects of the given transform.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
        public static void DestroyChildren(this Transform parent)
        {
            parent.ForEveryChild(child => Object.Destroy(child.gameObject));
        }

        /// <summary>
        /// Immediately destroys all child game objects of the given transform.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
        public static void DestroyChildrenImmediate(this Transform parent)
        {
            parent.ForEveryChild(child => Object.DestroyImmediate(child.gameObject));
        }

        /// <summary>
        /// Enables all child game objects of the given transform.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
        public static void EnableChildren(this Transform parent)
        {
            parent.ForEveryChild(child => child.gameObject.SetActive(true));
        }

        /// <summary>
        /// Disables all child game objects of the given transform.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
        public static void DisableChildren(this Transform parent)
        {
            parent.ForEveryChild(child => child.gameObject.SetActive(false));
        }

        /// <summary>
        /// Executes the specified action for every child of the given transform.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
        /// <param name="action">The action to perform on each child transform.</param>
        public static void ForEveryChild(this Transform parent, System.Action<Transform> action)
        {
            for (var i = parent.childCount - 1; i >= 0; i--)
            {
                action(parent.GetChild(i));
            }
        }

        /// <summary>
        /// Moves the transform by a specific value in the X, Y, and Z axes.
        /// </summary>
        /// <param name="target">The transform to move.</param>
        /// <param name="x">The value to move in the X axis. Default is 0.</param>
        /// <param name="y">The value to move in the Y axis. Default is 0.</param>
        /// <param name="z">The value to move in the Z axis. Default is 0.</param>
        /// <param name="relativeTo">The space to move the transform relative to. Default is Space.Self.</param>
        /// <remarks>
        /// This method adds the specified values to the transform's position in the specified space.
        /// If <paramref name="relativeTo"/> is set to Space.Self, the transform's local coordinates are used.
        /// Otherwise, the global coordinates are used.
        /// </remarks>
        public static void Move(this Transform target, float? x = null, float? y = null, float? z = null, Space relativeTo = Space.Self)
        {
            if (target is RectTransform rectTransform)
            {
                rectTransform.Move(x, y);
            }
            else
            {
                var moveTo = new Vector3(x ?? 0, y ?? 0, z ?? 0);
                if (relativeTo == Space.Self)
                {
                    target.Translate(moveTo, relativeTo);
                }
                else
                {
                    target.position += moveTo;
                }
            }
        }
    }
}
