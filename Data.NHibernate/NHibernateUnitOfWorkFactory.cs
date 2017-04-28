using System.Data;
using NHibernate;

namespace TeamSL.Infrastructure.Data.NHibernate
{
    public class NHibernateUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ISessionFactory _sessionFactory;

        public NHibernateUnitOfWorkFactory(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        #region IUnitOfWorkFactory Members

        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return new NHibernateUnitOfWork(_sessionFactory.OpenSession(), isolationLevel);
        }

        public IUnitOfWork Create()
        {
            return Create(IsolationLevel.ReadCommitted);
        }

        #endregion
    }
}