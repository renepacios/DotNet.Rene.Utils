

namespace Rene.Utils.Core.UnitTest.Extensions.Collections
{

    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using FluentAssertions;

    public class EnumerableExtensionsToDataTableTest
    {
        private class TestClass
        {
            public int Colum1 { get; set; }
            public string Colum2 { get; set; }
        }


        [Fact]
        public void ToDataTable_tableName_defaultName_work_as_should()
        {
            var data = GetDataToTest();
            var dt = data.ToDataTable();
            dt.TableName.Should()
                .NotBeNullOrEmpty()
                .And.BeEquivalentTo(nameof(TestClass));
        }

        [Fact]
        public void ToDataTable_tableName_work_as_should()
        {
            string tableName = "tableName";
            var data = GetDataToTest();

            var dt = data.ToDataTable(tableName);

            dt.TableName.Should()
                .NotBeNullOrEmpty()
                .And.BeEquivalentTo(tableName);
        }

        [Fact]
        public void ToDataTable_work_as_should()
        {
            string tableName = "tableName";
            int rowscount = 1;

            var data = GetDataToTest(rowscount).ToList();

            var dt = data.ToDataTable(tableName);

            dt.Columns.Count.Should().Be(2);
            dt.Rows.Count.Should().Be(rowscount);

            dt.Columns[0].ColumnName.Should().Be(nameof(TestClass.Colum1));
            dt.Columns[1].ColumnName.Should().Be(nameof(TestClass.Colum2));

           
            dt.Rows[0][0].Should()
                .BeAssignableTo<int>()
                .And.Be(data.First().Colum1);

            dt.Rows[0][1].Should()
                .BeAssignableTo(data.First().Colum2.GetType())
                .And.Be(data.First().Colum2);

        }


        private IEnumerable<TestClass> GetDataToTest(int count = 5)
            => Enumerable.Range(1, count)
                .Select(s => new TestClass() { Colum1 = s, Colum2 = $"Col-{s}" });


    }
}
