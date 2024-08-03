using JetBrains.Annotations;
using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class LayerMaskExtensions
    {
        /// <summary>
        /// Checks if the given layer number is contained in the LayerMask.
        /// </summary>
        /// <param name="mask">The LayerMask to check.</param>
        /// <param name="layerNumber">The layer number to check if it is contained in the LayerMask.</param>
        /// <returns>True if the layer number is contained in the LayerMask, otherwise false.</returns>
        [PublicAPI]
        public static bool Contains(this LayerMask mask, int layerNumber)
        {
            return mask == (mask | (1 << layerNumber));
        }

        /// <summary>
        /// Checks if the given GameObject's layer is contained in the LayerMask.
        /// </summary>
        /// <param name="mask">The LayerMask to check.</param>
        /// <param name="gameObject">The GameObject to check if its layer is contained in the LayerMask.</param>
        /// <returns>True if the GameObject's layer is contained in the LayerMask, otherwise false.</returns>
        [PublicAPI]
        public static bool Contains(this LayerMask mask, GameObject gameObject)
        {
            return mask.Contains(gameObject.layer);
        }

        /// <summary>
        /// Checks if the given Component's layer is contained in the LayerMask.
        /// </summary>
        /// <param name="mask">The LayerMask to check.</param>
        /// <param name="component">The Component to check if its layer is contained in the LayerMask.</param>
        /// <returns>True if the Component's layer is contained in the LayerMask, otherwise false.</returns>
        [PublicAPI]
        public static bool Contains(this LayerMask mask, Component component)
        {
            return mask.Contains(component.gameObject.layer);
        }
    }
}