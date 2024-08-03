using JetBrains.Annotations;
using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    
    public static class Vector3IntExtensions
    {
        /// <summary>
        /// Converts a Vector3Int to a Vector2Int by discarding the z-coordinate.
        /// </summary>
        /// <param name="vector">The Vector3Int instance to be converted.</param>
        /// <returns>A new Vector2Int instance with the x and y coordinates of the input Vector3Int.</returns>
        [PublicAPI]
        public static Vector2Int ToVector2Int(this Vector3Int vector)
        {
            return new Vector2Int(vector.x, vector.y);
        }
    }
}