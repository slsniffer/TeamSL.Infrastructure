using NHibernate;

namespace TeamSL.Infrastructure.Data.NHibernate
{
    public abstract class BaseQueryCriteria<TResult> : IQueryCriteria<TResult>
    {
        protected ICriteria _criteria;

        public abstract void Initialize(ISession session);

        public virtual TResult Get()
        {
            return default(TResult);
        }
    }
}