// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class ListExtensions
    {
        /// <summary>
        /// Returns a random object from the list using Unity's Random.Range.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the list.</typeparam>
        /// <param name="list">The list to select a random element from.</param>
        /// <returns>A randomly selected element from the list.</returns>
        public static T RandomObject<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return default;
            }

            return list[Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Determines whether a collection is null or has no elements
        /// without having to enumerate the entire collection to get a count.
        /// Uses LINQ's Any() method to determine if the collection is empty,
        /// so there is some GC overhead.
        /// </summary>
        /// <param name="list">List to evaluate</param>
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || !list.Any();
        }

        /// <summary>
        /// Creates a new list that is a copy of the original list.
        /// </summary>
        /// <param name="list">The original list to be copied.</param>
        /// <returns>A new list that is a copy of the original list.</returns>
        public static List<T> Clone<T>(this IList<T> list)
        {
            return list.ToList();
        }

        /// <summary>
        /// Swaps two elements in the list at the specified indices.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="indexA">The index of the first element.</param>
        /// <param name="indexB">The index of the second element.</param>
        public static void Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            (list[indexA], list[indexB]) = (list[indexB], list[indexA]);
        }

        /// <summary>
        /// Shuffles the elements in the list using the Durstenfeld implementation of the Fisher-Yates algorithm.
        /// This method modifies the input list in-place, ensuring each permutation is equally likely, and returns the list for method chaining.
        /// Reference: http://en.wikipedia.org/wiki/Fisher-Yates_shuffle
        /// </summary>
        /// <param name="list">The list to be shuffled.</param>
        /// <typeparam name="T">The type of the elements in the list.</typeparam>
        /// <returns>The shuffled list.</returns>
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            for (var i = list.Count - 1; i > 0; i--)
            {
                var j = Random.Range(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }

            return list;
        }
    }
}
