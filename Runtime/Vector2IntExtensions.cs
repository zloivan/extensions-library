// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using UnityEngine;

namespace UnityExtensions
{
    public static class Vector2IntExtensions
    {
        public static Vector2Int Abs(this Vector2Int vector)
        {
            return new Vector2Int(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        }

        public static Vector3Int ToVector3Int(this Vector2Int vector)
        {
            return new Vector3Int(vector.x, vector.y, 0);
        }

        public static Vector3 ToVector3(this Vector2Int vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }

        public static Vector2 ToVector2(this Vector2Int vector)
        {
            return new Vector2(vector.x, vector.y);
        }
    }
}