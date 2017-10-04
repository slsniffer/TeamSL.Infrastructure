using System;
using System.Collections.Generic;
using System.Linq;
using TeamSL.Infrastructure.Tools.Logging;

namespace TeamSL.Infrastructure.Domain.Caching
{
    public interface IQueryCacheObserver
    {
        void Subscribe(string key, Type type);
        void Publish(Type type);
        ICacheStorage Cache { get; }
    }

    [Obsolete]
    public class QueryCacheObserver : IQueryCacheObserver
    {
        private readonly ICacheStorage _cacheStorage;
        private readonly IDictionary<Type, List<string>> _subscribers = new Dictionary<Type, List<string>>();
        private readonly IDictionary<Type, CacheObserverAttribute> _observerTypes = new Dictionary<Type, CacheObserverAttribute>();

        public ICacheStorage Cache { get { return _cacheStorage; } }
        public ILogger Logger { get; set; }

        public QueryCacheObserver(ICacheStorage cacheStorage)
        {
            _cacheStorage = cacheStorage;
            Logger = NullLogger.Instance;
        }

        public void Subscribe(string key, Type type)
        {
            CacheObserverAttribute observer = GetObserver(type);

            if (observer == null)
                return;

            foreach (var command in observer.Commands)
            {
                if (!_subscribers.ContainsKey(command))
                    _subscribers.Add(command, new List<string>());

                if (!_subscribers[command].Exists(k => k.Equals(key)))
                    _subscribers[command].Add(key);
            }
        }

        public void Publish(Type type)
        {
            if (_subscribers.ContainsKey(type))
            {
                Logger.Debug("Notify query subscribers for type: {0}", type.Name);
                foreach (var cacheKey in _subscribers[type])
                {
                    _cacheStorage.Remove(cacheKey);
                }

                _subscribers[type].Clear();
            }
        }

        private CacheObserverAttribute GetObserver(Type type)
        {
            if (_observerTypes.ContainsKey(type))
            {
                return _observerTypes[type];
            }
            
            var customAttributes = type.GetCustomAttributes(typeof (CacheObserverAttribute), true);

            if (!customAttributes.Any())
                return null;

            var observer = (CacheObserverAttribute) customAttributes.First();

            _observerTypes.Add(type, observer);

            return observer;
        }
    }
}