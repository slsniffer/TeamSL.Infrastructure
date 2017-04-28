using System.Linq;
using NHibernate.Linq;

namespace TeamSL.Infrastructure.Data.NHibernate
{
    public class NHibernateLinqProvider : ILinqProvider
    {
        private readonly ISessionProvider _sessionProvider;

        public NHibernateLinqProvider(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        #region ILinqProvider Members

        public IQueryable<TRecord> Query<TRecord>() where TRecord : Record
        {
            return _sessionProvider.CurrentSession.Query<TRecord>();
        }

        #endregion
    }
}