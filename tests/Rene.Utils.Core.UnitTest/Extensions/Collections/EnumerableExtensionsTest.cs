using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Extensions.Collections
{
    using FluentAssertions;

    public class EnumerableExtensionsTest
    {
        [Fact]
        public void Append_Add_Item_To_End()
        {
            var source = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };

            const int itemValue = -1;

            var result = EnumerableExtensions.Append(source, itemValue);

            var aResult = result.ToArray();


            source.Should().HaveCount(8);
            aResult.Should()
                           .EndWith(itemValue)
                           .And.Subject.Should().HaveCount(source.Count + 1)
                           .And.Subject.Should().HaveElementAt(source.Count - 1, source[^1])
                           ;


            //Assert.Equal(itemValue, aResult[aResult.Length - 1]);
            //Assert.Equal(7, aResult[aResult.Length - 2]);

            //Assert.Equal(8, source.Count());
            //Assert.Equal(9, aResult.Length);
        }


        [Fact]
        public void Index_Must_Be_Continuous()
        {
            var source = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
            source.ForEach((item, i) => Assert.Equal(item, i));
        }

        [Fact]
        public void Prepend_Add_Item_To_Begin()
        {
            var source = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
            const int itemValue = 8;

            var result = EnumerableExtensions.Prepend(source, itemValue);

            var aResult = result.ToArray();

            source.Should().HaveCount(8);
            aResult.Should()
                .StartWith(itemValue)
                .And.Subject.Should().EndWith(source[^1])
                .And.Subject.Should().HaveCount(source.Count + 1)
                .And.Subject.Should().HaveElementAt(1, 0)
                ;

        }

        [Fact]
        public void SelectEach_Apply_Function()
        {
            var source = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
            var expected = new List<int> { 0, 2, 4, 6, 8, 10, 12, 14 };

            var result = source.SelectEach(n => n *= 2);

            result.Should().BeEquivalentTo(expected);
            //Assert.Equal(expected, result);
        }

        [Fact]
        public void AnyNotNull_Match()
        {
            var source = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };

            source.AnyNotNull().Should().BeTrue();
            source.AnyNotNull(w => 3 == w).Should().BeTrue();
            source.AnyNotNull(w => 8 == w).Should().BeFalse();
        }

        [Fact]
        public void AnyNotNull_With_Null_Instances()
        {
            List<int> source = null;

            source.AnyNotNull().Should().BeFalse();
            source.Should().BeNull();
            
        }


        [Fact]
        public void AsEnumerableWithIndex()
        {
            IList<string> source = new List<string>()
            {
                "0","1","2"
            };

            var i = 0;

            foreach ((string item, int index) tuple in source.AsEnumerableWithIndex())
            {
                tuple.item.Should().Be(source[i]);
                tuple.index.Should().Be(i);
                
                i++;
            }

            source.Should().HaveCount(i);
            


        }
    }
}
