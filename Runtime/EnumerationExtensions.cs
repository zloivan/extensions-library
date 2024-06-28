// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;

namespace UnityExtensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerationExtensions
    {
        /// <summary>
        /// Performs the specified action on each element of the IEnumerable.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence of elements to iterate over.</param>
        /// <param name="action">The action to perform on each element.</param>
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (var item in sequence)
            {
                action(item);
            }
        }
    }
}