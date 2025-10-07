using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Extensions.Collections
{
    public class ListExtensionsTest
    {
        #region AddItemIfNotExist
        [Fact]
        public void Add_Item_IfNotExist()
        {
            var list = new List<int>();
            const int v = 1;
            list.AddIfNotExist(v, (x,y) => x == y);
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
            list.AddIfNotExist(v, (x, y) => x == y);
            list.Should()
                .HaveCount(1)
                .And.Contain(v)
                ;
            list.AddIfNotExist(v2, (x, y) => x == y);
            list.Should()
                .HaveCount(2)
                .And.Contain(v)
                .And.Contain(v2)
                ;
            list.AddIfNotExist(v2, (x, y) => x == y, true);
            list.Should()
                .HaveCount(2)
                .And.Contain(v2)
                .And.Contain(v)
                ;

        }

        [Fact]
        public void Add_Item_IfNotExist_NullList_ThrowsException()
        {
            List<int> list = null;
            const int v = 1;
            var act = () => list.AddIfNotExist(v, (x, y) => x == y);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Add_Item_IfNotExist_NullCondition_ThrowsException()
        {
            var list = new List<int>();
            const int v = 1;
            Func<int,int, bool> condition = null;
            var act = () => list.AddIfNotExist(v, condition);
            act.Should().Throw<ArgumentException>();
        }


        #endregion

        #region AddRangeIfNotExist

        [Fact]
        public void Add_Range_IfNotExist()
        {
            var list = new List<int>();
            var values = new List<int> { 1, 2, 3 };
            list.AddRangeIfNotExist(values, (x, y) => x == y);
            list.Should()
                .HaveCount(3)
                .And.Contain(new[] { 1, 2, 3 })
                ;
        }

        [Fact]
        public void Add_Range_IfNotExist_With_OverrideOption_works_as_should()
        {
            var list = new List<int>();
            var values = new List<int> { 1, 2, 3 };
            var values2 = new List<int> { 3, 4, 5 };
            list.AddRangeIfNotExist(values, (x, y) => x == y);
            list.Should()
                .HaveCount(3)
                .And.Contain(new[] { 1, 2, 3 })
                ;
            list.AddRangeIfNotExist(values2, (x, y) => x == y);
            list.Should()
                .HaveCount(5)
                .And.Contain(new[] { 1, 2, 3 })
                .And.Contain(new[] { 4, 5 })
                ;
            list.AddRangeIfNotExist(values2, (x, y) => x == y, true);
            list.Should()
                .HaveCount(5)
                .And.Contain(new[] { 3, 4, 5 })
                .And.Contain(new[] { 1, 2 })
                ;
        }

        [Fact]
        public void Add_Range_IfNotExist_NullList_ThrowsException()
        {
            List<int> list = null;
            var values = new List<int> { 1, 2, 3 };
            var act = () => list.AddRangeIfNotExist(values, (x, y) => x == y);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Add_Range_IfNotExist_NullCondition_ThrowsException()
        {
            var list = new List<int>();
            var values = new List<int> { 1, 2, 3 };
            Func<int,int, bool> condition = null;
            var act = () => list.AddRangeIfNotExist(values, condition);
            act.Should().Throw<ArgumentException>();
        }


        #endregion

    }
}
