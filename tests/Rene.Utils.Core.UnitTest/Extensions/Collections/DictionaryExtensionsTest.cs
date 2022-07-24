
/*
 *  Copyright (C) 2019  René Pacios
 *
 *  You can use  for Personal or commercial presuppose, but you must maintain the copyright information and author
 *  This code is distributed on an "AS IS" BASIS,  * WITHOUT WARRANTIES OF ANY KIND, USE ON YOUR OWN RISK
 *
 */

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Extensions.Collections
{
    public class DictionaryExtensionsTest
    {
        [Fact]
        public void Add_Item_IfNotExist()
        {

            var dic = new Dictionary<int, int>();
            const int k = 1;
            const int v = 1;

            dic.AddIfNotExist(k, v);

            dic.Should()
                .HaveCount(1)
                .And.ContainKey(k)
                .And.Subject[k].Should().Be(v)
                ;
        }

        [Fact]
        public void Add_Item_IfNotExist_ExistItem()
        {
            var dic = new Dictionary<int, int>();
            const int k = 1;
            const int v = 1;
            const int v2 = 2;

            dic.Add(k, v);

            dic.AddIfNotExist(k, v2);

            dic.Should()
                .HaveCount(1)
                .And.ContainKey(k)
                .And.Subject[k].Should().Be(v)
                ;
            dic[k].Should().NotBe(v2);
         

            dic.AddIfNotExist(k, v2, true);

            dic.Should()
                .HaveCount(1)
                .And.ContainKey(k)
                .And.Subject[k].Should().Be(v2)
                ;
            dic[k].Should().NotBe(v);

        }



        [Fact]
        public void AddToGroup_Item_Into_Group()
        {

            IDictionary<int, IList<int>> dic = new Dictionary<int, IList<int>>();

            const int key = 1;
            const int valueToAdd = 2;

            dic.AddToGroup(key, valueToAdd);

            dic.Keys
                .Should()
                .NotBeNullOrEmpty()
                .And.NotContainNulls()
                .And.OnlyContain(w => w == key);

            dic.Values
                .Should()
                .NotBeNullOrEmpty()
                .And.NotContainNulls()
                .And.BeAssignableTo<ICollection<IList<int>>>()
                .And.HaveCount(1)
                .And.OnlyContain(grupo => grupo.Count(l => l == valueToAdd) == 1);

        }
        [Fact]
        public void AddToGroup_Item_Into_Group_Existing_Dictionary()
        {

            const int keyList1 = 10;
            const int keyList2 = 20;
            const int valueIntoList = 20;

            IDictionary<int, IList<int>> dic = new Dictionary<int, IList<int>>()
            {
                {keyList1,new List<int>(valueIntoList)},
                {keyList2,new List<int>(valueIntoList)}
            };

            const int key = 1;
            const int valueToAdd = 2;

            int dictionaryLength = dic.Count;

            dic.AddToGroup(key, valueToAdd);

            dic.Keys
                .Should()
                .NotBeNullOrEmpty()
                .And.NotContainNulls()
                .And.Contain(w => w == key)
                .And.HaveCount(dictionaryLength + 1);

            dic.Values
                .Should()
                .NotBeNullOrEmpty()
                .And.NotContainNulls()
                .And.BeAssignableTo<ICollection<IList<int>>>()
                .And.HaveCount(dictionaryLength + 1);

            dic[key]
                .Should()
                .ContainSingle()
                .And.NotContainNulls()
                .And.OnlyContain(w => w == valueToAdd);


        }


        [Fact]
        public void AddToGroup_Item_ExistGroup()
        {
            const int keyList1 = 10;
            const int keyList2 = 20;
            const int valueIntoList = 20;

            IDictionary<int, IList<int>> dic = new Dictionary<int, IList<int>>()
            {
                {keyList1,new List<int>(){valueIntoList }},
                {keyList2,new List<int>(){valueIntoList }}
            };

            const int key = 10;
            const int valueToAdd = 2;

            int dictionaryLength = dic.Count;

            dic.AddToGroup(key, valueToAdd);

            dic.Keys
                .Should()
                .NotBeNullOrEmpty()
                .And.Contain(w => w == key)
                .And.HaveCount(dictionaryLength);

            dic.Values
                .Should()
                .NotBeNullOrEmpty()
                .And.BeAssignableTo<ICollection<IList<int>>>()
                .And.HaveCount(dictionaryLength);

            dic[key]
                .Should()
                .NotBeNullOrEmpty()
                .And.NotContainNulls()
                .And.HaveCount(2)
                .And.Contain(w => w == valueIntoList)
                .And.Contain(w => w == valueToAdd);

        }
    }

}

