using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Extensions
{
    public class EnumerableExtensionsTest
    {
        [Fact]
        public void Append_Add_Item_To_End()
        {
            var source = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };

            var result = EnumerableExtensions.Append(source, -1);

            var aResult = result.ToArray();

            Assert.Equal(-1, aResult[aResult.Length - 1]);
            Assert.Equal(7, aResult[aResult.Length - 2]);

            Assert.Equal(8, source.Count());
            Assert.Equal(9, aResult.Length);
        }


        [Fact]
        public void Index_Must_Be_Continius()
        {
            var source = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
            source.ForEach((item, i) => Assert.Equal(item, i));
        }

        [Fact]
        public void Prepend_Add_Item_To_Start()
        {
            var source = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };

            var result = EnumerableExtensions.Prepend(source, 8);

            var aResult = result.ToArray();

            Assert.Equal(8, aResult[0]);
            Assert.Equal(0, aResult[1]);

            Assert.Equal(8, source.Count());
            Assert.Equal(9, aResult.Length);
        }

        [Fact]
        public void SelectEach_Apply_Function()
        {
            var source = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
            var expected = new List<int> { 0, 2, 4, 6, 8, 10, 12, 14 };

            var result = source.SelectEach(n => n *= 2);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AnyNotNull_Match()
        {
            var source = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };

            Assert.True(source.AnyNotNull());

            Assert.True(source.AnyNotNull(w => 3 == w));

            Assert.False(source.AnyNotNull(w => 8 == w));

        }

        [Fact]
        public void AnyNotNull_With_Null_Instances()
        {
            List<int> source=null;
            Assert.False(source.AnyNotNull());

            Assert.Null(source);
        }


        [Fact]
        public void AsEnumerableWithIndex()
        {
            IList<string> source=new List<string>()
            {
                "0","1","2"
            };

            var i = 0;

            foreach ((string item, int index) tuple in source.AsEnumerableWithIndex())
            {
                Assert.Equal(tuple.item, source[i]);
                Assert.Equal(tuple.index,i);
                i++;
            }

            Assert.Equal(source.Count,i);


        }
    }
}
