using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TeamSL.Infrastructure.Utils.Extensions
{
    public static class EnumerableExtensions
    {
        public static IList<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
        {
            Checks.NotNull(source, nameof(source));

            return new ReadOnlyCollection<T>(source.ToList());
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> predicate)
        {
            Checks.NotNull(source, nameof(source));
            Checks.NotNull(predicate, nameof(predicate));

            foreach (var item in source)
            {
                predicate(item);
            }

            return source;
        }
    }
}
