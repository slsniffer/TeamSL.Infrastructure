using System.Linq;
using TeamSL.Infrastructure.Data.Specifications;

namespace TeamSL.Infrastructure.Data
{
    public abstract class RepositoryImpl<TRecord> where TRecord : Record
    {
        protected abstract IQueryable<TRecord> Table { get; }

        protected TRecord Load(long id, IFetchStrategy<TRecord> fetchStrategy)
        {
            Checks.NotNull(fetchStrategy, "fetchStrategy");

            var queryable = Table.Where(x => x.Id == id);

            return queryable.Fetch(fetchStrategy).SingleOrDefault();
        }

        protected TRecord Find(IQuerySpecification<TRecord> specification)
        {
            Checks.NotNull(specification, "specification");

            return Table.FilterBy(specification).SingleOrDefault();
        }

        protected TRecord Find(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy)
        {
            Checks.NotNull(specification, "specification");
            Checks.NotNull(fetchStrategy, "fetchStrategy");

            return Table.FilterBy(specification).Fetch(fetchStrategy).SingleOrDefault();
        }

        protected int Count()
        {
            return Table.Count();
        }

        protected int Count(IQuerySpecification<TRecord> specification)
        {
            Checks.NotNull(specification, "specification");

            return Table.FilterBy(specification).Count();
        }

        protected IQueryable<TRecord> FindAll()
        {
            return Table;
        }

        protected IQueryable<TRecord> FindAll(IQuerySpecification<TRecord> specification)
        {
            Checks.NotNull(specification, "specification");

            return Table.FilterBy(specification);
        }

        protected IQueryable<TRecord> FindAll(IFetchStrategy<TRecord> fetchStrategy)
        {
            Checks.NotNull(fetchStrategy, "fetchStrategy");

            return Table.Fetch(fetchStrategy);
        }

        protected IQueryable<TRecord> FindAll(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy)
        {
            Checks.NotNull(specification, "specification");
            Checks.NotNull(fetchStrategy, "fetchStrategy");

            return Table.FilterBy(specification).Fetch(fetchStrategy);
        }
    }
}