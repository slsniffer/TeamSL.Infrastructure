using System;
using NHibernate;
using NHibernate.Context;

namespace TeamSL.Infrastructure.Data.NHibernate
{
    public class PerRequestSessionProvider : ISessionProvider
    {
        private readonly ISessionFactory _sessionFactory;
        private bool _disposed;
        private bool _preventCommit;
        private ISession _session;
        private ITransaction _transaction;

        public PerRequestSessionProvider(ISessionFactory sessionFactory)
        {
            if (sessionFactory == null)
                throw new ArgumentNullException(nameof(sessionFactory));

            _sessionFactory = sessionFactory;

            _session = _sessionFactory.OpenSession();
            _session.FlushMode = FlushMode.Commit;

            _transaction = _session.BeginTransaction();

            CurrentSessionContext.Bind(_session);
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            if (_session == null)
                return;

            try
            {
                if (_preventCommit)
                    _transaction.Rollback();
                else
                    _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
            }

            if (CurrentSessionContext.HasBind(_session.SessionFactory))
                CurrentSessionContext.Unbind(_session.SessionFactory);

            _session.Dispose();
            _session = null;
            _transaction = null;
            _disposed = true;
        }

        public ISession CurrentSession
        {
            get
            {
                if (_disposed)
                    throw new InvalidOperationException("Object already disposed. Probably container has wrong lifestyle type");

                if (_session != null)
                    return _session;

                return _session;
            }
        }

        public void PreventCommit()
        {
            _preventCommit = true;
        }
    }
}