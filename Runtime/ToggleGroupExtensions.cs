// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Reflection;
using UnityEngine.UI;

namespace UnityExtensions
{
    public static class ToggleGroupExtensions
    {
        private const string M_TOGGLES = "m_Toggles";
        private static FieldInfo _togglesInfo;

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