// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using UnityEngine;

namespace UnityExtensions
{
    public static class RectIntExtensions
    {
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