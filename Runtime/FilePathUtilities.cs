using System;
using System.IO;
using System.Text;
using IKhom.ExtensionsLibrary.Runtime.helpers;
using JetBrains.Annotations;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class FilePathUtilities
    {
        /// <summary>
        /// Determines whether the directory has a given directory in its hierarchy of children.
        /// </summary>
        /// <param name="parentDir">The parent directory.</param>
        /// <param name="subDir">The subdirectory.</param>
        /// <returns>True if the parent directory has the subdirectory in its hierarchy of children, otherwise false.</returns>
        [PublicAPI]
        public static bool HasSubDirectory(this DirectoryInfo parentDir, DirectoryInfo subDir)
        {
            var str = parentDir.FullName.TrimEnd('\\', '/');
            for (; subDir != null; subDir = subDir.Parent)
            {
                if (subDir.FullName.TrimEnd('\\', '/') == str)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Finds a parent directory with a given name, or null if no such parent directory exists.
        /// </summary>
        /// <param name="dir">The directory to search for a parent directory with a given name.</param>
        /// <param name="folderName">The name of the parent directory to find.</param>
        /// <returns>The parent directory with the given name, or null if no such parent directory exists.</returns>
        [PublicAPI]
        public static DirectoryInfo FindParentDirectoryWithName(this DirectoryInfo dir, string folderName)
        {
            while (true)
            {
                if (dir.Parent == null) return null;
                if (string.Equals(dir.Name, folderName, StringComparison.InvariantCultureIgnoreCase)) return dir;
                dir = dir.Parent;
            }
        }

        /// <summary>
        /// Returns a value indicating whether a path can be made relative to another.
        /// </summary>
        /// <param name="absoluteParentPath">The parent path.</param>
        /// <param name="absolutePath">The path to make relative to the parent path.</param>
        /// <returns>True if the path can be made relative to the parent path, otherwise false.</returns>
        [PublicAPI]
        public static bool CanMakeRelative(string absoluteParentPath, string absolutePath)
        {
            Validator.ValidateNotNullOrEmpty(absoluteParentPath, nameof(absoluteParentPath));
            Validator.ValidateNotNull(absolutePath, nameof(absolutePath));
            
            
            absoluteParentPath = absoluteParentPath.Replace('\\', '/').Trim('/');
            absolutePath = absolutePath.Replace('\\', '/').Trim('/');
            return Path.GetPathRoot(absoluteParentPath)
                .Equals(Path.GetPathRoot(absolutePath), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Returns a path string to path that is relative to the parent path.
        /// </summary>
        /// <param name="absoluteParentPath">The parent path.</param>
        /// <param name="absolutePath">The path to make relative to the parent path.</param>
        /// <returns>A relative path from parent path to path.</returns>
        [PublicAPI]
        public static string MakeRelative(string absoluteParentPath, string absolutePath)
        {
            absoluteParentPath = absoluteParentPath.TrimEnd('\\', '/');
            absolutePath = absolutePath.TrimEnd('\\', '/');
            var strArray1 = absoluteParentPath.Split('/', '\\');
            var strArray2 = absolutePath.Split('/', '\\');
            var num = -1;
            for (var index = 0;
                 index < strArray1.Length && index < strArray2.Length && strArray1[index]
                     .Equals(strArray2[index], StringComparison.CurrentCultureIgnoreCase);
                 ++index)
                num = index;
            
            
            if (num == -1)
                throw new InvalidOperationException("No common directory found.");
            
            var stringBuilder = new StringBuilder();
            if (num + 1 < strArray1.Length)
            {
                for (var index = num + 1; index < strArray1.Length; ++index)
                {
                    if (stringBuilder.Length > 0)
                        stringBuilder.Append('/');
                    stringBuilder.Append("..");
                }
            }

            for (var index = num + 1; index < strArray2.Length; ++index)
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append('/');
                stringBuilder.Append(strArray2[index]);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Tries to make a path that is relative from parent path to path.
        /// </summary>
        /// <param name="absoluteParentPath">The parent path.</param>
        /// <param name="absolutePath">The path to make relative to the parent path.</param>
        /// <param name="relativePath">A relative path from parent path to path. <c>null</c> if no relative path could be made.</param>
        /// <returns>True if the method succeeded in making a relative path, otherwise false.</returns>
        [PublicAPI]
        public static bool TryMakeRelative(string absoluteParentPath, string absolutePath, out string relativePath)
        {
            if (CanMakeRelative(absoluteParentPath, absolutePath))
            {
                relativePath = MakeRelative(absoluteParentPath, absolutePath);
                return true;
            }

            relativePath = null;
            return false;
        }

        /// <summary>
        /// Combines two paths, and replaces all backslashes with forward slash.
        /// </summary>
        /// <param name="a">The first path.</param>
        /// <param name="b">The second path.</param>
        /// <returns>A combined path with all backslashes replaced by forward slashes.</returns>
        [PublicAPI]
        public static string Combine(string a, string b)
        {
            a = a.Replace("\\", "/").TrimEnd('/');
            b = b.Replace("\\", "/").TrimStart('/');
            return a + "/" + b;
        }
    }
}