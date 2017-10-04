using TeamSL.Infrastructure.Tools.Logging;

namespace TeamSL.Infrastructure.Domain.Queries
{
    public class QueryHandlerLoggingDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : class, IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> _decorated;

        public ILogger Logger { get; set; }

        public QueryHandlerLoggingDecorator(IQueryHandler<TQuery, TResult> decorated)
        {
            _decorated = decorated;
            Logger = NullLogger.Instance;
        }

        public TResult Ask(TQuery query)
        {
            try
            {
                Logger.Debug("Query [{0}] start asking.", typeof(TQuery).Name);
                return _decorated.Ask(query);
            }
            finally
            {
                Logger.Debug("Query [{0}] finish asking.", typeof(TQuery).Name);
            }
        }
    }
}