using System;
using System.Linq;
using TeamSL.Infrastructure.Data.Specifications;
using TeamSL.Infrastructure.Utils;

namespace TeamSL.Infrastructure.Data
{
    public static class QueryableExtensions
    {
        public static IQueryable<TRecord> Fetch<TRecord>(this IQueryable<TRecord> source, IFetchStrategy<TRecord> fetchStrategy) where TRecord : Record
        {
            Checks.NotNull(source, nameof(source));

            return fetchStrategy.Apply(source);
        }

        public static IQueryable<TRecord> FilterBy<TRecord>(this IQueryable<TRecord> source, IQuerySpecification<TRecord> specification) where TRecord : Record
        {
            Checks.NotNull(source, nameof(source));

            return specification.SatisfyingElementsFrom(source);
        }

        public static IQueryable<TRecord> OrderBy<TRecord>(this IQueryable<TRecord> queryable, Action<Orderable<TRecord>> order) where TRecord : Record
        {
            Checks.NotNull(queryable, nameof(queryable));

            var orderable = new Orderable<TRecord>(queryable);
            order(orderable);
            return orderable.Queryable;
        }
    }
}