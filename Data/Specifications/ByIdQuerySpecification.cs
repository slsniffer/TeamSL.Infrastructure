using System.Linq;

namespace TeamSL.Infrastructure.Data.Specifications
{
    public class ByIdQuerySpecification<TRecord> : IQuerySpecification<TRecord>
        where TRecord : Record
    {
        private readonly long _recordId;

        public ByIdQuerySpecification(long recordId)
        {
            _recordId = recordId;
        }

        public virtual IQueryable<TRecord> SatisfyingElementsFrom(IQueryable<TRecord> candidates)
        {
            return candidates.Where(x => x.Id == _recordId);
        }
    }
}