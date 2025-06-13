using JetBrains.Annotations;
using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class ComponentExtensions
    {
        /// <summary>
        /// Gets or adds a component to the GameObject.
        /// </summary>
        /// <typeparam name="T">The type of the component to get or add.</typeparam>
        /// <param name="target">The component to get or add the component to.</param>
        /// <returns>The component of type T.</returns>
        [PublicAPI]
        public static T GetOrAddComponent<T>(this Component target) where T : Component =>
            target.gameObject.GetOrAddComponent<T>();
    }
}