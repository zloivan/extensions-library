using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class PropertyInfoExtensions
    {
        /// <summary>Determines whether a property is an auto property.</summary>
        [PublicAPI]
        public static bool IsAutoProperty(this PropertyInfo propInfo, bool allowVirtual = false)
        {
            if (!propInfo.CanWrite || !propInfo.CanRead)
                return false;
            if (!allowVirtual)
            {
                var getMethod = propInfo.GetGetMethod(true);
                var setMethod = propInfo.GetSetMethod(true);
                if (getMethod != null && (getMethod.IsAbstract || getMethod.IsVirtual) ||
                    setMethod != null && (setMethod.IsAbstract || setMethod.IsVirtual))
                    return false;
            }

            const BindingFlags BINDING_ATTR = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic;
            var str = "<" + propInfo.Name + ">";

            return propInfo.DeclaringType != null &&
                   propInfo.DeclaringType.GetFields(BINDING_ATTR).Any(field => field.Name.Contains(str));
        }
    }
}