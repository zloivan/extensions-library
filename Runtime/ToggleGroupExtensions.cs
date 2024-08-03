using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine.UI;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class ToggleGroupExtensions
    {
        private const string M_TOGGLES = "m_Toggles";
        private static FieldInfo _togglesInfo;

        /// <summary>
        /// Retrieves the list of Toggle components within the specified ToggleGroup.
        /// </summary>
        /// <param name="toggleGroup">The ToggleGroup instance to retrieve the Toggle components from.</param>
        /// <returns>An IReadOnlyList of Toggle components within the specified ToggleGroup.</returns>
        [PublicAPI]
        public static IReadOnlyList<Toggle> GetToggles(this ToggleGroup toggleGroup)
        {
            _togglesInfo = typeof(ToggleGroup).GetField(M_TOGGLES, BindingFlags.Instance | BindingFlags.NonPublic);

            if (_togglesInfo == null)
                throw new System.Exception(
                    "UnityEngine.UI.ToggleGroup source code must have changed and is no longer compatible with this version of extension.");

            return _togglesInfo.GetValue(toggleGroup) as IReadOnlyList<Toggle>;
        }
    }
}