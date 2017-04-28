using System;
using System.Collections.Generic;
using TeamSL.Infrastructure.Data.Specifications;
using TeamSL.Infrastructure.Tools.Logging;

namespace TeamSL.Infrastructure.Data
{
    public class ReadRepositoryLoggingDecorator<TRecord> : IReadRepository<TRecord> where TRecord : Record
    {
        private readonly IReadRepository<TRecord> _decorated;

        public ILogger Logger { get; set; }

        public ReadRepositoryLoggingDecorator(IReadRepository<TRecord> decorated)
        {
            _decorated = decorated;
            Logger = NullLogger.Instance;
        }

        TRecord IReadRepository<TRecord>.Load(long id)
        {
            Logger.Information("Loading {0}.Id: {0}", typeof(TRecord).Name, id);

            return _decorated.Load(id);
        }

        TRecord IReadRepository<TRecord>.Load(long id, IFetchStrategy<TRecord> fetchStrategy)
        {
            Logger.Information("Loading {0}.Id: {1} with fetching: {2}", typeof(TRecord).Name, id, fetchStrategy.GetType().Name);

            return _decorated.Load(id, fetchStrategy);
        }

        TRecord IReadRepository<TRecord>.Find(IQuerySpecification<TRecord> specification)
        {
            Logger.Information("Find {0} by specification: {1}", typeof(TRecord).Name, specification.GetType().Name);

            return _decorated.Find(specification);
        }

        TRecord IReadRepository<TRecord>.Find(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy)
        {
            Logger.Information("Find {0} by specification: {1} with fetching: {2}", typeof(TRecord).Name, specification.GetType().Name, fetchStrategy.GetType().Name);

            return _decorated.Find(specification, fetchStrategy);
        }

        int IReadRepository<TRecord>.Count()
        {
            Logger.Information("Counting {0}", typeof(TRecord).Name);

            return _decorated.Count();
        }

        int IReadRepository<TRecord>.Count(IQuerySpecification<TRecord> specification)
        {
            Logger.Information("Counting {0} with spec: {1}", typeof(TRecord).Name, specification.GetType().Name);

            return _decorated.Count(specification);
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll()
        {
            Logger.Information("Find all {0}", typeof(TRecord).Name);

            return _decorated.FindAll();
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(Action<Orderable<TRecord>> order)
        {
            Logger.Information("Find all {0} with ordering", typeof(TRecord).Name);

            return _decorated.FindAll(order);
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(Action<Orderable<TRecord>> order, int skip, int count)
        {
            Logger.Information("Find all {0} with ordering, skip:{1}, count:{2}", typeof(TRecord).Name, skip, count);

            return _decorated.FindAll(order, skip, count);
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IQuerySpecification<TRecord> specification)
        {
            Logger.Information("Find all {0} with spec:{1}", typeof(TRecord).Name, specification.GetType().Name);

            return _decorated.FindAll(specification);
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IQuerySpecification<TRecord> specification, Action<Orderable<TRecord>> order)
        {
            Logger.Information("Find all {0} with spec:{1} and ordering", typeof(TRecord).Name, specification.GetType().Name);

            return _decorated.FindAll(specification, order);
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IQuerySpecification<TRecord> specification, Action<Orderable<TRecord>> order, int skip, int count)
        {
            Logger.Information("Find all {0} with spec:{1} and ordering, skip:{2}, count:{3}", typeof(TRecord).Name, specification.GetType().Name, skip, count);

            return _decorated.FindAll(specification, order, skip, count);
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy)
        {
            Logger.Information("Find all {0} with spec:{1}, fetch:{2}", typeof(TRecord).Name, specification.GetType().Name, fetchStrategy.GetType().Name);

            return _decorated.FindAll(specification, fetchStrategy);
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy, Action<Orderable<TRecord>> order)
        {
            Logger.Information("Find all {0} with spec:{1}, fetch:{2} and ordering", typeof(TRecord).Name, specification.GetType().Name, fetchStrategy.GetType().Name);

            return _decorated.FindAll(specification, fetchStrategy, order);
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy, Action<Orderable<TRecord>> order,
            int skip, int count)
        {
            Logger.Information("Find all {0} with spec:{1}, fetch:{2} and ordering, skip:{3}, count:{4}", typeof(TRecord).Name, specification.GetType().Name,
                fetchStrategy.GetType().Name, skip, count);

            return _decorated.FindAll(specification, fetchStrategy, order, skip, count);
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IFetchStrategy<TRecord> fetchStrategy)
        {
            Logger.Information("Find all {0} with fetch:{1}", typeof(TRecord).Name, fetchStrategy.GetType().Name);

            return _decorated.FindAll(fetchStrategy);
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IFetchStrategy<TRecord> fetchStrategy, Action<Orderable<TRecord>> order, int skip, int count)
        {
            Logger.Information("Find all {0} with fetch:{1} and ordering, skip:{2}, count:{3}", typeof(TRecord).Name, fetchStrategy.GetType().Name, skip, count);

            return _decorated.FindAll(fetchStrategy, order, skip, count);
        }
    }
}