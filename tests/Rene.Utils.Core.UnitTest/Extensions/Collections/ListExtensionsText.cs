using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Extensions.Collections
{
    public class ListExtensionsText
    {

        [Fact]
        public void Add_Item_IfNotExist()
        {
            var list = new List<int>();
            const int v = 1;
            list.AddIfNotExist(v, x => x == v);
            list.Should()
                .HaveCount(1)
                .And.Contain(v)
                ;
        }

        [Fact]
        public void Add_Item_IfNotExist_With_OverrideOption_works_as_should()
        {
            var list = new List<int>();
            const int v = 1;
            const int v2 = 2;
            list.AddIfNotExist(v, x => x == v);
            list.Should()
                .HaveCount(1)
                .And.Contain(v)
                ;
            list.AddIfNotExist(v2, x => x == v);
            list.Should()
                .HaveCount(1)
                .And.Contain(v)
                .And.NotContain(v2)
                ;
            list.AddIfNotExist(v2, x => x == v, true);
            list.Should()
                .HaveCount(1)
                .And.Contain(v2)
                .And.NotContain(v)
                ;

        }

        [Fact]
        public void Add_Item_IfNotExist_NullList_ThrowsException()
        {
            List<int> list = null;
            const int v = 1;
            var act = () => list.AddIfNotExist(v, x => x == v);
            act.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void Add_Item_IfNotExist_NullCondition_ThrowsException()
        {
            var list = new List<int>();
            const int v = 1;
            Func<int, bool> condition = null;
            var act = () => list.AddIfNotExist(v, condition);
            act.Should().Throw<ArgumentException>();
        }

    }
}
