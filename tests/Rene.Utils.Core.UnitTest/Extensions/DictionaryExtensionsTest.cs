

using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace Rene.Utils.Core.UnitTest.Extensions
{
    public class DictionaryExtensionsTest
    {
        [Fact]
        public void Add_Item_IfNotExist()
        {

            var dic = new Dictionary<int, int>();
            int k = 1, v = 1;

            dic.AddIfNotExist(k, v);

            Assert.True(dic.ContainsKey(k));
            Assert.Equal(dic[k], v);
            Assert.Single(dic);
        }

        [Fact]
        public void Add_ExistItem()
        {
            var dic = new Dictionary<int, int>();
            int k = 1, v = 1, v2 = 2;

            dic.Add(k, v);

            dic.AddIfNotExist(k, v2);

            Assert.True(dic.ContainsKey(k));
            Assert.NotEqual(dic[k], v2);
            Assert.Equal(dic[k], v);
            Assert.Single(dic);

            dic.AddIfNotExist(k, v2, true);

            Assert.True(dic.ContainsKey(k));
            Assert.NotEqual(dic[k], v);
            Assert.Equal(dic[k], v2);
            Assert.Single(dic);

        }
    }
}

