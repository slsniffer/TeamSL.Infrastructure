using System;
using System.Linq;
using System.Linq.Expressions;

namespace TeamSL.Infrastructure.Data.Specifications
{
    public interface IQuerySpecification<T>
    {
        IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates);
    }

    public abstract class QuerySpecification<T> : IQuerySpecification<T>
    {
        protected abstract Expression<Func<T, bool>> MatchingCriteria();

        public virtual IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates)
        {
            if (MatchingCriteria() != null)
            {
                return candidates.Where(MatchingCriteria());
            }

            return candidates;
        }
    }
}
