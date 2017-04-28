using System.Linq;

namespace TeamSL.Infrastructure.Data
{
    public interface ILinqProvider
    {
        IQueryable<TRecord> Query<TRecord>()
            where TRecord : Record;
    }
}
