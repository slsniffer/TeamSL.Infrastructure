﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TeamSL.Infrastructure.Data
{
    public static class EnumerableExtensions
    {
        public static IList<T> ToReadOnlyCollection<T>(this IEnumerable<T> enumerable)
        {
            Checks.NotNull(enumerable, nameof(enumerable));

            return new ReadOnlyCollection<T>(enumerable.ToList());
        }
    }
}