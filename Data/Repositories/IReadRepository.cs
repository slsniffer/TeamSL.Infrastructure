using System;
using System.Collections.Generic;
using TeamSL.Infrastructure.Data.Specifications;

namespace TeamSL.Infrastructure.Data
{
    public interface IReadRepository<TRecord> where TRecord : Record
    {
        TRecord Load(long id);
        TRecord Load(long id, IFetchStrategy<TRecord> fetchStrategy);
        TRecord Find(IQuerySpecification<TRecord> specification);
        TRecord Find(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy);
        int Count();
        int Count(IQuerySpecification<TRecord> specification);
        IList<TRecord> FindAll();
        IList<TRecord> FindAll(Action<Orderable<TRecord>> order);
        IList<TRecord> FindAll(Action<Orderable<TRecord>> order, int skip, int count);
        IList<TRecord> FindAll(IQuerySpecification<TRecord> specification);
        IList<TRecord> FindAll(IQuerySpecification<TRecord> specification, Action<Orderable<TRecord>> order);
        IList<TRecord> FindAll(IQuerySpecification<TRecord> specification, Action<Orderable<TRecord>> order, int skip, int count);
        IList<TRecord> FindAll(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy);
        IList<TRecord> FindAll(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy, Action<Orderable<TRecord>> order);
        IList<TRecord> FindAll(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy, Action<Orderable<TRecord>> order, int skip, int count);
        IList<TRecord> FindAll(IFetchStrategy<TRecord> fetchStrategy);
        IList<TRecord> FindAll(IFetchStrategy<TRecord> fetchStrategy, Action<Orderable<TRecord>> order, int skip, int count);
    }
}