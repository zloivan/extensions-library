// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class RectExtensions
    {
        public static RectInt ToRectInt(this Rect rect)
        {
            return new RectInt(
                Mathf.RoundToInt(rect.xMin),
                Mathf.RoundToInt(rect.yMin),
                Mathf.RoundToInt(rect.width),
                Mathf.RoundToInt(rect.height)
            );
        }
    }
}