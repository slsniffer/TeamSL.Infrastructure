using System;
using System.Runtime.Caching;

namespace TeamSL.Infrastructure.Domain.Caching
{
    public class MemoryCacheStorage : ICacheStorage
    {
        private static readonly MemoryCache _cache = new MemoryCache("TeamSL.Cache");

        public T Get<T>(string key)
        {
            return (T)_cache.Get(key);
        }

        public bool TryGet<T>(string key, out T value)
        {
            value = default(T);

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

        public void Set<T>(string key, T value)
        {
            Set(key, value, DateTime.Now.AddMinutes(30));
        }

        public void Set<T>(string key, T value, DateTime absoluteExpiration)
        {
            SetInternal(key, value, new CacheItemPolicy { AbsoluteExpiration = absoluteExpiration });
        }

        public void Set<T>(string key, T value, TimeSpan slidingExpiration)
        {
            SetInternal(key, value, new CacheItemPolicy { SlidingExpiration = slidingExpiration });
        }

        private void SetInternal<T>(string key, T value, CacheItemPolicy policy)
        {
            _cache.Add(key, value, policy);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}