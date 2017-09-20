using NHibernate;

namespace TeamSL.Infrastructure.Data.NHibernate
{
    public interface IContentReader
    {
        TResult Read<TResult>(IQueryCriteria<TResult> queryCriteria);
    }

    public class ContentReader : IContentReader
    {
        private readonly ISessionProvider _sessionProvider;

        public ContentReader(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public TResult Read<TResult>(IQueryCriteria<TResult> queryCriteria)
        {
            queryCriteria.Initialize(_sessionProvider.CurrentSession);
            return queryCriteria.Get();
        }
    }

    public interface IQueryCriteria<out TResult>
    {
        void Initialize(ISession session);
        TResult Get();
    }
}