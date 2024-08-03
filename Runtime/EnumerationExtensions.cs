using System;
using System.Collections.Generic;
using IKhom.ExtensionsLibrary.Runtime.helpers;
using JetBrains.Annotations;

namespace IKhom.ExtensionsLibrary.Runtime
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
        [PublicAPI]
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            Validator.ValidateNotNull(sequence, nameof(sequence));
            Validator.ValidateNotNull(action, nameof(action));

            foreach (var item in sequence)
            {
                action(item);
            }
        }

        /// <summary>
        /// Performs the specified action on each element of the IEnumerable, providing the index of the element.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence of elements to iterate over.</param>
        /// <param name="action">The action to perform on each element, providing the index of the element.</param>
        [PublicAPI]
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T, int> action)
        {
            Validator.ValidateNotNull(sequence, nameof(sequence));
            Validator.ValidateNotNull(action, nameof(action));

            var index = 0;
            foreach (var item in sequence)
            {
                action(item, index);
                index++;
            }
        }
    }
}