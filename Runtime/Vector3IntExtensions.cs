// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using UnityEngine;

namespace UnityExtensions
{
    public static class Vector3IntExtensions
    {
        public static Vector2Int ToVector2Int(this Vector3Int vector)
        {
            return new Vector2Int(vector.x, vector.y);
        }
    }
}