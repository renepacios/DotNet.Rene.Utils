/*
												\||||||/
												 ( o o )
------------------------------------------- oooO---(_)---Oooo-------------------------------------------------------
Author: 	René Pacios
			https://www.webrene.es/	
			Copyright (c) 2012, René Pacios

Created: 2019, 11, 29, 17:43

 Permission is hereby granted, free of charge, to any person  obtaining a copy of this software and 
associated documentation files (the "Software"), to deal in the Software without  restriction, including 
without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
copies of the Software, and to permit persons to whom the Software is furnished to do so, subject 
to the following  conditions:
 
  	The above copyright notice and this permission notice shall be
	included in all copies or substantial portions of the Software.
 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.

										   oooO
										  (    )      Oooo
-------------------------------------------\  (------(    )----------------------------------------------------------------
											\_)       )  /
													  (_/

*/
using System;
using System.Collections.Generic;
using System.Globalization;
using Rene.Utils.Core.Resources;

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

            if (createItem == null) throw new NullReferenceException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.NulleReferenceExceptioX0, nameof(createItem)));
            // Key not in cache, so get data.
            cacheEntry = createItem();

            Store(key, cacheEntry, expiresAfter ?? _defaultExpiresTime);

            return cacheEntry;
        }

        private bool TryGetValue(TKey key, out TValue cacheValue)
        {
            if (!_cache.TryGetValue(key, out var cached))
            {
                cacheValue = default(TValue);
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

