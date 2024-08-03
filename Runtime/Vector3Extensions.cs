using JetBrains.Annotations;
using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Converts a Vector3 to a Vector2 by taking only the x and y components.
        /// </summary>
        /// <param name="vector">The Vector3 to convert.</param>
        /// <returns>A new Vector2 with the x and y components of the input Vector3.</returns>
        [PublicAPI]
        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        /// <summary>
        /// Returns a new Vector3 with each component absolute.
        /// </summary>
        /// <param name="vector">The Vector3 to make absolute.</param>
        /// <returns>A new Vector3 with each component absolute.</returns>
        [PublicAPI]
        public static Vector3 Abs(this Vector3 vector)
        {
            return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
        }

        /// <summary>
        /// Converts the Vector3 to screen coordinates using the specified Camera.
        /// </summary>
        /// <param name="vector">The Vector3 to convert.</param>
        /// <param name="camera">The Camera to use for the conversion.</param>
        /// <returns>A new Vector3 with the screen coordinates of the input Vector3.</returns>
        [PublicAPI]
        public static Vector3 OnScreen(this Vector3 vector, Camera camera)
        {
            return camera.WorldToScreenPoint(vector);
        }

        /// <summary>
        /// Returns a new Vector3 with the specified components, or the original components if no values are provided.
        /// </summary>
        /// <param name="vector">The Vector3 to modify.</param>
        /// <param name="x">The new x component, or null to keep the original.</param>
        /// <param name="y">The new y component, or null to keep the original.</param>
        /// <param name="z">The new z component, or null to keep the original.</param>
        /// <returns>A new Vector3 with the specified components, or the original components if no values are provided.</returns>
        [PublicAPI]
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }

        /// <summary>
        /// Returns a new Vector3 with each component added to the specified value, or 0 if no value is provided.
        /// </summary>
        /// <param name="vector">The Vector3 to modify.</param>
        /// <param name="x">The value to add to the x component, or null to keep the original.</param>
        /// <param name="y">The value to add to the y component, or null to keep the original.</param>
        /// <param name="z">The value to add to the z component, or null to keep the original.</param>
        /// <returns>A new Vector3 with each component added to the specified value, or 0 if no value is provided.</returns>
        [PublicAPI]
        public static Vector3 Add(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(vector.x + (x ?? 0), vector.y + (y ?? 0), vector.z + (z ?? 0));
        }

        /// <summary>
        /// Returns a new Vector3 with each component raised to the specified power.
        /// </summary>
        /// <param name="v">The Vector3 to raise to the specified power.</param>
        /// <param name="p">The power to raise each element of the Vector3 to.</param>
        /// <returns>A new Vector3 with each component raised to the specified power.</returns>
        [PublicAPI]
        public static Vector3 Pow(this Vector3 v, float p)
        {
            v.x = Mathf.Pow(v.x, p);
            v.y = Mathf.Pow(v.y, p);
            v.z = Mathf.Pow(v.z, p);
            return v;
        }

        /// <summary>
        /// Returns a new Vector3 with each component set to its respective sign.
        /// </summary>
        /// <param name="v">The vector to sign.</param>
        /// <returns>A new Vector3 with each component set to its respective sign.</returns>
        [PublicAPI]
        public static Vector3 Sign(this Vector3 v)
        {
            return new Vector3(Mathf.Sign(v.x), Mathf.Sign(v.y), Mathf.Sign(v.z));
        }

        /// <summary>
        /// Clamps the value of a Vector3 within the specified range.
        /// </summary>
        /// <param name="value">The vector to clamp.</param>
        /// <param name="min">The minimum value for each component.</param>
        /// <param name="max">The maximum value for each component.</param>
        /// <returns>A new Vector3 with each component clamped within the specified range.</returns>
        [PublicAPI]
        public static Vector3 Clamp(this Vector3 value, Vector3 min, Vector3 max)
        {
            return new Vector3(Mathf.Clamp(value.x, min.x, max.x), Mathf.Clamp(value.y, min.y, max.y),
                Mathf.Clamp(value.z, min.z, max.z));
        }
    }
}