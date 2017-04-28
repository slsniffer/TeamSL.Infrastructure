using System.Linq;

namespace TeamSL.Infrastructure.Data
{
    public interface IFetchStrategy<TRecord> where TRecord : RecordWithKey<long>
    {
        IQueryable<TRecord> Apply(IQueryable<TRecord> queryable);
    }
}