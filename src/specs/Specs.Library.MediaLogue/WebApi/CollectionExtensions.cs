using System.Collections.Generic;

namespace Specs.Library.MediaLogue.WebApi
{
    internal static class CollectionExtensions
    {

        internal static void AddTo<T>(
            this ICollection<T> destination,
            IEnumerable<T> source)
        {

            foreach (T item in source)
            {
                destination.Add(item);
            }
        }
    }
}