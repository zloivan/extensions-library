using System;
using JetBrains.Annotations;
using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class Vector2Extensions
    {
        /// <summary>Clamps the value of a Vector2.</summary>
        /// <param name="value">The vector to clamp.</param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value.</param>
        [PublicAPI]
        public static Vector2 Clamp(this Vector2 value, Vector2 min, Vector2 max)
        {
            return new Vector2(Mathf.Clamp(value.x, min.x, max.x), Mathf.Clamp(value.y, min.y, max.y));
        }

        /// <summary>Rotates a Vector2 by an angle.</summary>
        /// <param name="point">The point to rotate.</param>
        /// <param name="degrees">The angle to rotate.</param>
        [PublicAPI]
        public static Vector2 RotatePoint(this Vector2 point, float degrees)
        {
            var f = degrees * ((float)Math.PI / 180f);
            var num1 = Mathf.Cos(f);
            var num2 = Mathf.Sin(f);
            return new Vector2((float)(num1 * (double)point.x - num2 * (double)point.y),
                (float)(num2 * (double)point.x + num1 * (double)point.y));
        }

        /// <summary>Rotates a Vector2 around a point by an angle..</summary>
        /// <param name="point">The point to rotate.</param>
        /// <param name="around">The point to rotate around.</param>
        /// <param name="degrees">The angle to rotate.</param>
        [PublicAPI]
        public static Vector2 RotatePoint(this Vector2 point, Vector2 around, float degrees)
        {
            var f = degrees * ((float)Math.PI / 180f);
            var num1 = Mathf.Cos(f);
            var num2 = Mathf.Sin(f);
            return new Vector2(
                (float)(num1 * (point.x - (double)around.x) -
                        num2 * (point.y - (double)around.y)) + around.x,
                (float)(num2 * (point.x - (double)around.x) +
                        num1 * (point.y - (double)around.y)) + around.y);
        }
    }
}