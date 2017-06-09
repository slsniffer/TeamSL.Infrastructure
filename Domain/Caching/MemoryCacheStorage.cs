using System;
using System.Runtime.Caching;

namespace TeamSL.Infrastructure.Domain.Caching
{
    public class MemoryCacheStorage : ICacheStorage
    {
        private readonly ICacheConfiguration _configuration;
        private static readonly MemoryCache _cache = new MemoryCache("cache");

        public MemoryCacheStorage(ICacheConfiguration configuration)
        {
            _configuration = configuration;
        }

        public T Get<T>(string key)
        {
            if (!_configuration.IsEnabled)
                return default(T);

            return (T)_cache.Get(key);
        }

        public bool TryGet<T>(string key, out T value)
        {
            value = default(T);

            if (!_configuration.IsEnabled)
                return false;

            if (_cache.Contains(key))
            {
                object existingValue = _cache.Get(key);
                if (existingValue != null)
                {
                    value = (T)existingValue;
                    return true;
                }
            }

            return false;
        }

        public MemoryCache Cache
        {
            get { return _cache; }
        }

        public void Set<T>(string key, T value)
        {
            if (_configuration.IsEnabled)
                Set(key, value, DateTime.Now.AddMinutes(30));
        }

        public void Set<T>(string key, T value, DateTime absoluteExpiration)
        {
            if (_configuration.IsEnabled)
                SetInternal(key, value, new CacheItemPolicy { AbsoluteExpiration = absoluteExpiration });
        }

        public void Set<T>(string key, T value, TimeSpan slidingExpiration)
        {
            if (_configuration.IsEnabled)
                SetInternal(key, value, new CacheItemPolicy { SlidingExpiration = slidingExpiration });
        }

        private void SetInternal<T>(string key, T value, CacheItemPolicy policy)
        {
            if (_configuration.IsEnabled)
                _cache.Add(key, value, policy);
        }

        public void Remove(string key)
        {
            if (_configuration.IsEnabled)
                _cache.Remove(key);
        }
    }
}