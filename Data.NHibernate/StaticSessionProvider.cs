using NHibernate;
using NHibernate.Context;

namespace TeamSL.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Draft version
    /// </summary>
    public class StaticSessionProvider : ISessionProvider
    {
        private readonly ISessionFactory _sessionFactory;

        public StaticSessionProvider(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        #region ISessionProvider Members

        public ISession CurrentSession
        {
            get
            {
                if (!CurrentSessionContext.HasBind(_sessionFactory))
                    CurrentSessionContext.Bind(_sessionFactory.OpenSession());

                return _sessionFactory.GetCurrentSession();
            }
        }

        #endregion

        public void Dispose()
        {
            ISession currentSession = CurrentSessionContext.Unbind(_sessionFactory);

            currentSession.Close();
            currentSession.Dispose();
        }
    }
}