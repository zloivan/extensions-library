// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using UnityEngine;

namespace UnityExtensions
{
    public static class RectTransformExtensions
    {
        public static Rect GetWorldRect(this RectTransform rectTransform)
        {
            var corners = new Vector3[4];

            rectTransform.GetWorldCorners(corners);

            var bounds = new Bounds(corners[0], Vector3.zero);
            bounds.Encapsulate(corners[2]);

            return new Rect(new Vector2(bounds.min.x, bounds.min.y), bounds.size);
        }

        public static RectInt GetScreenRect(this RectTransform rectTransform, Camera camera)
        {
            var rect = rectTransform.GetWorldRect();

            var rectMax = camera.WorldToScreenPoint(rect.max);
            var rectMin = camera.WorldToScreenPoint(rect.min);

            var position = new Vector3(rectMin.x, rectMin.y);

            var size = new Vector2(
                rectMax.x - rectMin.x,
                rectMax.y - rectMin.y
            );

            return new Rect(position, size).ToRectInt();
        }
    }
}