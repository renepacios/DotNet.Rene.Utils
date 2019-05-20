using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rene.Utils.Core.SimpleCache;
using Xunit;

namespace Rene.Utils.Core.UnitTest.SimpleCache
{
    public class SimpleCacheEngineTest : IDisposable
    {
        private SimpleCacheEngine<string, string> _cache;

        public SimpleCacheEngineTest()
        {
            _cache= new SimpleCacheEngine<string,string>(TimeSpan.FromMilliseconds(10));
        }

        [Fact]
        public void Insert_Item_Cache()
        {
            string key = nameof(Insert_Item_Cache);
            string expected = "Hello World!!";
            _cache.Store(key,expected,TimeSpan.FromSeconds(1));
            Assert.Equal(expected, _cache.Get(key));
        }

        [Fact]
        public void Insert_Item_Cache_If_Expired()
        {
            string key = nameof(Insert_Item_Cache);

            string expected1 = "Hello World!!";
            string expected2 = Guid.NewGuid().ToString();

            var expire = TimeSpan.FromMilliseconds(150);

            _cache.Store(key, expected1, expire);

            var res = _cache.GetOrCreate(key, () => expected2, expire);
            Assert.Equal(expected1, res);

            System.Threading.Thread.Sleep(expire.Add(TimeSpan.FromMilliseconds(1)));

            var res2 = _cache.GetOrCreate(key, () => expected2, expire);
            Assert.NotEqual(res, res2);
            Assert.Equal(expected2, res2);



        }


        [Fact]
        public void Expired_Item_Cache()
        {
            string key = nameof(Expired_Item_Cache);
            string expected = "Hello World!!";
            _cache.Store(key, expected, TimeSpan.FromMilliseconds(150));
            System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(200));
            Assert.Equal(default(string), _cache.Get(key));
        }




        public void Dispose()
        {
        }
    }
}
