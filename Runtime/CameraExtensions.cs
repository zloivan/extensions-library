using IKhom.ExtensionsLibrary.Runtime.helpers;
using JetBrains.Annotations;
using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class CameraExtensions
    {
        /// <summary>
        /// Calculates and returns viewport extents with an optional margin. Useful for calculating a frustum for culling.
        /// </summary>
        /// <param name="camera">The camera object this method extends.</param>
        /// <param name="viewportMargin">Optional margin to be applied to viewport extents. Default is 0.2, 0.2.</param>
        /// <returns>Viewport extents as a Vector2 after applying the margin.</returns>
        [PublicAPI]
        public static Vector2 GetViewportExtentsWithMargin(this Camera camera, Vector2? viewportMargin = null)
        {
            var margin = viewportMargin ?? new Vector2(0.2f, 0.2f);

            Vector2 result;
            var halfFieldOfView = camera.fieldOfView * 0.5f * Mathf.Deg2Rad;
            result.y = camera.nearClipPlane * Mathf.Tan(halfFieldOfView);
            result.x = result.y * camera.aspect + margin.x;
            result.y += margin.y;
            return result;
        }
        
        /// <summary>
        /// Converts screen coordinates to world coordinates considering the viewport margin.
        /// </summary>
        /// <param name="camera">The camera object this method extends.</param>
        /// <param name="screenPosition">Screen position to be converted.</param>
        /// <param name="viewportMargin">Optional margin to be applied to viewport extents. Default is 0.2, 0.2.</param>
        /// <returns>World coordinates as a Vector3 after applying the margin.</returns>
        [PublicAPI]
        public static Vector3 ScreenToWorldPointWithMargin(this Camera camera, Vector3 screenPosition, Vector2? viewportMargin = null)
        {
            Validator.ValidateNotNull(camera, nameof(camera));

            var margin = viewportMargin ?? new Vector2(0.2f, 0.2f);
            var viewportPosition = camera.ScreenToViewportPoint(screenPosition);
            viewportPosition.x = Mathf.Clamp(viewportPosition.x, margin.x, 1f - margin.x);
            viewportPosition.y = Mathf.Clamp(viewportPosition.y, margin.y, 1f - margin.y);

            return camera.ViewportToWorldPoint(viewportPosition);
        }
    }
}