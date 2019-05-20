using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rene.Utils.Core.SimpleCache;

namespace Rene.Utils.Core.UnitTest.SimpleCache
{
    public class SimpleCacheEngineTest : IDisposable
    {
        private SimpleCacheEngine<string, string> _cache;

        public SimpleCacheEngineTest()
        {
            _cache= new SimpleCacheEngine<string,string>(TimeSpan.FromMilliseconds(10));
        }


        public void Dispose()
        {
        }
    }
}
