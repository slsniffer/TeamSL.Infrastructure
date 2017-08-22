using System;
using System.Linq;
using TeamSL.Infrastructure.Data.Specifications;

namespace TeamSL.Infrastructure.Data
{
    public static class QueryableExtensions
    {
        public static IQueryable<TRecord> Fetch<TRecord>(this IQueryable<TRecord> source, IFetchStrategy<TRecord> fetchStrategy) where TRecord : Record
        {
            return fetchStrategy.Apply(source);
        }

        public static IQueryable<TRecord> FilterBy<TRecord>(this IQueryable<TRecord> source, IQuerySpecification<TRecord> specification) where TRecord : Record
        {
            return specification.SatisfyingElementsFrom(source);
        }

        public static IQueryable<TRecord> OrderBy<TRecord>(this IQueryable<TRecord> queryable, Action<Orderable<TRecord>> order) where TRecord : Record
        {
            var orderable = new Orderable<TRecord>(queryable);
            order(orderable);
            return orderable.Queryable;
        }

        public static IQueryable<T> PageBy<T>(this IQueryable<T> queryable, int skip, int take)
        {
            if (queryable == null)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            return queryable.Skip(skip).Take(take);
        }
    }
}