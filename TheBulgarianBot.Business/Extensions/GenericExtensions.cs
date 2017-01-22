namespace TheBulgarianBot.Business.Extensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A static class containing generic extensions.
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Filters an enumerable by taking out only instances that have distinct value on a specified property.
        /// </summary>
        /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
        /// <typeparam name="TKey">The type of the property which should be distinct.</typeparam>
        /// <param name="source">The source enumerable.</param>
        /// <param name="keySelector">The property which should be unique.</param>
        /// <returns>The filtered enumerable.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
