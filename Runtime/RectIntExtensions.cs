// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class RectIntExtensions
    {
        /// <summary>
        /// Computes the intersection of two RectInt objects.
        /// </summary>
        /// <param name="rectA">The first RectInt object.</param>
        /// <param name="rectB">The second RectInt object.</param>
        /// <returns>A new RectInt object representing the intersection of rectA and rectB.</returns>
        public static RectInt Intersection(this RectInt rectA, RectInt rectB)
        {
            return new RectInt(
                Mathf.Max(rectA.x, rectB.x),
                Mathf.Max(rectA.y, rectB.y),
                Mathf.Min(rectA.x + rectA.width, rectB.width) - Mathf.Max(rectA.x, rectB.x),
                Mathf.Min(rectA.y + rectA.height, rectB.height) - Mathf.Max(rectA.y, rectB.y)
            );
        }
    }
}