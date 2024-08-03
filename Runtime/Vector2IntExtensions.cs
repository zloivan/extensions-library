using JetBrains.Annotations;
using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class Vector2IntExtensions
    {
        /// <summary>
        /// Returns a new <see cref="Vector2Int"/> with the absolute values of the components.
        /// </summary>
        /// <param name="vector">The input <see cref="Vector2Int"/>.</param>
        /// <returns>A new <see cref="Vector2Int"/> with the absolute values of the components.</returns>
        [PublicAPI]
        public static Vector2Int Abs(this Vector2Int vector)
        {
            return new Vector2Int(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        }

        /// <summary>
        /// Converts the <see cref="Vector2Int"/> to a <see cref="Vector3Int"/> with a zero z-component.
        /// </summary>
        /// <param name="vector">The input <see cref="Vector2Int"/>.</param>
        /// <returns>A new <see cref="Vector3Int"/> with the same x and y components as the input, and a zero z-component.</returns>
        [PublicAPI]
        public static Vector3Int ToVector3Int(this Vector2Int vector)
        {
            return new Vector3Int(vector.x, vector.y, 0);
        }

        /// <summary>
        /// Converts the <see cref="Vector2Int"/> to a <see cref="Vector3"/> with a zero z-component.
        /// </summary>
        /// <param name="vector">The input <see cref="Vector2Int"/>.</param>
        /// <returns>A new <see cref="Vector3"/> with the same x and y components as the input, and a zero z-component.</returns>
        [PublicAPI]
        public static Vector3 ToVector3(this Vector2Int vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }

        /// <summary>
        /// Converts the <see cref="Vector2Int"/> to a <see cref="Vector2"/>.
        /// </summary>
        /// <param name="vector">The input <see cref="Vector2Int"/>.</param>
        /// <returns>A new <see cref="Vector2"/> with the same x and y components as the input.</returns>
        [PublicAPI]
        public static Vector2 ToVector2(this Vector2Int vector)
        {
            return new Vector2(vector.x, vector.y);
        }
    }
}