using System.Linq;

namespace TeamSL.Infrastructure.Utils.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> PageBy<T>(this IQueryable<T> queryable, int skip, int take)
        {
            Checks.NotNull(queryable, nameof(queryable));

            return queryable.Skip(skip).Take(take);
        }
    }
}
