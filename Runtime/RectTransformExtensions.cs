using IKhom.ExtensionsLibrary.Runtime.helpers;
using JetBrains.Annotations;
using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class RectTransformExtensions
    {
        /// <summary>
        /// Gets the world space Rect of the RectTransform.
        /// </summary>
        /// <param name="rectTransform">The RectTransform to get the world Rect for.</param>
        /// <returns>A Rect representing the world space bounds of the RectTransform.</returns>
        [PublicAPI]
        public static Rect GetWorldRect([NotNull] this RectTransform rectTransform)
        {
            Validator.ValidateNotNull(rectTransform, nameof(rectTransform));

            var corners = new Vector3[4];

            rectTransform.GetWorldCorners(corners);

            var bounds = new Bounds(corners[0], Vector3.zero);
            bounds.Encapsulate(corners[2]);

            return new Rect(new Vector2(bounds.min.x, bounds.min.y), bounds.size);
        }

        /// <summary>
        /// Gets the screen space Rect of the RectTransform.
        /// </summary>
        /// <param name="rectTransform">The RectTransform to get the screen Rect for.</param>
        /// <param name="camera">The camera to use for the screen space conversion.</param>
        /// <returns>A RectInt representing the screen space bounds of the RectTransform.</returns>
        [PublicAPI]
        public static RectInt GetScreenRect([NotNull] this RectTransform rectTransform, [NotNull] Camera camera)
        {
            Validator.ValidateNotNull(rectTransform, nameof(rectTransform));
            Validator.ValidateNotNull(camera, nameof(camera));

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

        /// <summary>
        /// Moves the RectTransform by the specified amounts.
        /// </summary>
        /// <param name="rectTransform">The RectTransform to move.</param>
        /// <param name="x">The amount to move along the x-axis. If null, no movement along the x-axis.</param>
        /// <param name="y">The amount to move along the y-axis. If null, no movement along the y-axis.</param>
        [PublicAPI]
        public static void Move([NotNull] this RectTransform rectTransform,
            float? x = null,
            float? y = null)
        {
            Validator.ValidateNotNull(rectTransform, nameof(rectTransform));

            var moveTo = new Vector2(x ?? 0, y ?? 0);
            rectTransform.anchoredPosition += moveTo;
        }
    }
}