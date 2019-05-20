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

        public TValue Get(TKey key) => TryGetValue(key, out var cacheEntry) ? cacheEntry : default(TValue);

        public TValue GetOrCreate(TKey key, Func<TValue> createItem, TimeSpan? expiresAfter = null)
        {
//            if (_cache.TryGetValue(key, out var cached)) return cached.Value;
            if (TryGetValue(key, out var cacheEntry)) return cacheEntry;

            // Key not in cache, so get data.
            cacheEntry = createItem();

            Store(key, cacheEntry, expiresAfter ?? _defaultExpiresTime);

            return cacheEntry;
        }

        private bool TryGetValue(TKey key, out TValue cacheValue)
        {
            if (!_cache.TryGetValue(key, out var cached))
            {
                cacheValue= default(TValue);
                return false;
            }


          
            if (DateTimeOffset.Now - cached.Created >= cached.ExpiresAfter)
            {
                _cache.Remove(key);
                cacheValue = default(TValue);
                return false;
            }

            cacheValue = cached.Value;
            return true;
        }

    }
}

