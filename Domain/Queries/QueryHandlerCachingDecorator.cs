using System;
using System.Reflection;
using TeamSL.Infrastructure.Domain.Caching;
using TeamSL.Infrastructure.Tools.Logging;

namespace TeamSL.Infrastructure.Domain.Queries
{
    public class QueryHandlerCachingDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : class, IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> _decorated;
        private readonly ICacheStorage _storage;
        private readonly IQueryCacheKeyBuilder _keyBuilder;

        public ILogger Logger { get; set; }

        public QueryHandlerCachingDecorator(
            IQueryHandler<TQuery, TResult> decorated,
            ICacheStorage storage,
            IQueryCacheKeyBuilder keyBuilder)
        {
            _decorated = decorated;
            _storage = storage;
            _keyBuilder = keyBuilder;
            Logger = NullLogger.Instance;
        }

        public TResult Ask(TQuery query)
        {
            TResult result;
            var cacheKey = _keyBuilder.Build(query);

            Logger.Debug("Try get from cache [{0}]", cacheKey);
            if (_storage.TryGet(_keyBuilder.Build(query), out result))
            {
                Logger.Debug("Retrieve from cache [{0}]", cacheKey);
                return result;
            }

            Logger.Debug("Hit original with cache [{0}]", cacheKey);
            result = _decorated.Ask(query);

            if (result == null)
                return default(TResult);

            var cacheQueryAttr = query.GetType().GetCustomAttribute<CacheQueryAttribute>();
            if (cacheQueryAttr != null)
            {
                Logger.Debug("Store cache [{0}]", cacheKey);
                _storage.Set(cacheKey, result, DateTime.UtcNow.AddSeconds(cacheQueryAttr.Ttl));
            }

            return result;
        }
    }
}