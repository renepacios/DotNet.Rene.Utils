using System;
using System.Collections.Generic;

namespace Rene.Utils.Core.SimpleCache
{

    public class SimpleCacheEngine<TKey, TValue>
    {
        private readonly Dictionary<TKey, CacheItem<TValue>> _cache = new Dictionary<TKey, CacheItem<TValue>>();

        private readonly TimeSpan _defaultExpiresTime;

        /// <summary>
        /// Initialize Cache Engine with 60 seconds of expiration time
        /// </summary>
        public SimpleCacheEngine()
        {
            _defaultExpiresTime = TimeSpan.FromSeconds(60);
        }

        public SimpleCacheEngine(TimeSpan defaultExpiresTime)
        {
            _defaultExpiresTime = defaultExpiresTime;
        }


        public void Store(TKey key, TValue value)
        {
            Store(key, value, _defaultExpiresTime);
        }

        public void Store(TKey key, TValue value, TimeSpan expiresAfter)
        {
            _cache[key] = new CacheItem<TValue>(value, expiresAfter);
        }

        public TValue Get(TKey key)
        {
            if (!_cache.ContainsKey(key)) return default(TValue);


            if (!_cache.TryGetValue(key, out var cached)) return default(TValue);


            if (DateTimeOffset.Now - cached.Created >= cached.ExpiresAfter)
            {
                _cache.Remove(key);
                return default(TValue);
            }

            return cached.Value;


        }

        public TValue GetOrCreate(TKey key, Func<TValue> createItem, TimeSpan? expiresAfter = null)
        {
            if (_cache.TryGetValue(key, out var cached)) return cached.Value;
            
            // Key not in cache, so get data.
            var cacheEntry = createItem();

            Store(key, createItem(), expiresAfter ?? _defaultExpiresTime);

            return cacheEntry;
        }
    }
}

