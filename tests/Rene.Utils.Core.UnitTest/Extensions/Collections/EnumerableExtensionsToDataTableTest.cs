

using System.ComponentModel;

namespace Rene.Utils.Core.UnitTest.Extensions.Collections
{

    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using FluentAssertions;

    public class EnumerableExtensionsToDataTableTest
    {
        private const string COLUMN_DESCRIPTION = "Test Colunm";

        private class TestClass
        {
            public int Column1 { get; set; }
            [Description(COLUMN_DESCRIPTION)]
            public string Column2 { get; set; }

            
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

            dt.Columns[0].ColumnName.Should().Be(nameof(TestClass.Column1));
            dt.Columns[1].ColumnName.Should().Be(COLUMN_DESCRIPTION);

           
            dt.Rows[0][0].Should()
                .BeAssignableTo<int>()
                .And.Be(data.First().Column1);

            dt.Rows[0][1].Should()
                .BeAssignableTo(data.First().Column2.GetType())
                .And.Be(data.First().Column2);

        }


        private IEnumerable<TestClass> GetDataToTest(int count = 5)
            => Enumerable.Range(1, count)
                .Select(s => new TestClass() { Column1 = s, Column2 = $"Col-{s}" });


    }
}
