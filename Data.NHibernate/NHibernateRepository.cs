using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using TeamSL.Infrastructure.Data.Specifications;

namespace TeamSL.Infrastructure.Data.NHibernate
{
    public sealed class NHibernateRepository<TRecord> : RepositoryImpl<TRecord>, IReadRepository<TRecord>, IRepository<TRecord>
        where TRecord : Record
    {
        private readonly ISessionProvider _sessionProvider;

        public NHibernateRepository(ISessionProvider sessionProvider)
        {
            if (sessionProvider == null)
                throw new ArgumentNullException(nameof(sessionProvider));

            _sessionProvider = sessionProvider;
        }

        private ISession Session
        {
            get { return _sessionProvider.CurrentSession; }
        }

        protected override IQueryable<TRecord> Table
        {
            get { return Session.Query<TRecord>().Cacheable(); }
        }

        TRecord IReadRepository<TRecord>.Load(long id)
        {
            return Load(id);
        }

        TRecord IReadRepository<TRecord>.Load(long id, IFetchStrategy<TRecord> fetchStrategy)
        {
            return Load(id, fetchStrategy);
        }

        TRecord IReadRepository<TRecord>.Find(IQuerySpecification<TRecord> specification)
        {
            return Find(specification);
        }

        TRecord IReadRepository<TRecord>.Find(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy)
        {
            return Find(specification, fetchStrategy);
        }

        int IReadRepository<TRecord>.Count()
        {
            return Count();
        }

        int IReadRepository<TRecord>.Count(IQuerySpecification<TRecord> specification)
        {
            return Count(specification);
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll()
        {
            return FindAll().ToReadOnlyCollection();
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(Action<Orderable<TRecord>> order)
        {
            return FindAll().OrderBy(order).ToReadOnlyCollection();
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(Action<Orderable<TRecord>> order, int skip, int count)
        {
            return FindAll().OrderBy(order).Skip(skip).Take(count).ToReadOnlyCollection();
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IQuerySpecification<TRecord> specification)
        {
            return FindAll(specification).ToReadOnlyCollection();
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IFetchStrategy<TRecord> fetchStrategy)
        {
            return FindAll(fetchStrategy).ToReadOnlyCollection();
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IFetchStrategy<TRecord> fetchStrategy, Action<Orderable<TRecord>> order, int skip, int count)
        {
            return FindAll(fetchStrategy).OrderBy(order).Skip(skip).Take(count).ToReadOnlyCollection();
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy)
        {
            return FindAll(specification, fetchStrategy).ToReadOnlyCollection();
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IQuerySpecification<TRecord> specification, Action<Orderable<TRecord>> order)
        {
            return FindAll(specification).OrderBy(order).ToReadOnlyCollection();
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IQuerySpecification<TRecord> specification, Action<Orderable<TRecord>> order, int skip, int count)
        {
            return FindAll(specification).OrderBy(order).Skip(skip).Take(count).ToReadOnlyCollection();
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy, Action<Orderable<TRecord>> order)
        {
            return FindAll(specification, fetchStrategy).OrderBy(order).ToReadOnlyCollection();
        }

        IList<TRecord> IReadRepository<TRecord>.FindAll(IQuerySpecification<TRecord> specification, IFetchStrategy<TRecord> fetchStrategy, Action<Orderable<TRecord>> order, int skip, int count)
        {
            return FindAll(specification, fetchStrategy).OrderBy(order).Skip(skip).Take(count).ToReadOnlyCollection();
        }

        void IRepository<TRecord>.Create(TRecord record)
        {
            Create(record);
        }

        void IRepository<TRecord>.Update(TRecord record)
        {
            Update(record);
        }

        void IRepository<TRecord>.CreateOrUpdate(TRecord record)
        {
            CreateOrUpdate(record);
        }

        void IRepository<TRecord>.Delete(TRecord record)
        {
            Delete(record);
        }

        private void Create(TRecord record)
        {
            Session.Save(record);
        }

        private void Update(TRecord record)
        {
            Session.Evict(record);
            Session.Merge(record);
        }

        private void CreateOrUpdate(TRecord record)
        {
            if (record.Id > 0)
                Update(record);
            else
                Create(record);
        }

        private void Delete(TRecord record)
        {
            Session.Delete(record);
        }

        private TRecord Load(long id)
        {
            return Session.Get<TRecord>(id);
        }
    }
}