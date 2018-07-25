using System.Linq;

namespace TeamSL.Infrastructure.Data.Specifications
{
    public interface IQuerySpecification<T>
    {
        IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates);
    }
}