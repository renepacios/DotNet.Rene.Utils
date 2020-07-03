using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Extensions
{
    public class DateTimeExtensionsTest
    {
        [Fact]
        public void Date_Is_Between()
        {
            var expected = DateTime.Now;

            Assert.True(expected.IsBetween(expected.AddMilliseconds(-1), expected.AddMilliseconds(1)));
            Assert.True(expected.IsBetween(expected, expected.AddMilliseconds(1)));
            Assert.True(expected.IsBetween(expected.AddMilliseconds(-1), expected));
            Assert.True(expected.IsBetween(expected, expected));

            //Test when limits is swap
            Assert.True(expected.IsBetween(expected.AddMilliseconds(1), expected.AddMilliseconds(-1)));
            Assert.True(expected.IsBetween(expected, expected.AddMilliseconds(-1)));
            Assert.True(expected.IsBetween(expected.AddMilliseconds(1), expected));

        }

        [Fact]
        public void Date_IsNot_Between()
        {
            var expected = DateTime.Now;



            Assert.False(expected.IsBetween(expected.AddMilliseconds(-2), expected.AddMilliseconds(-1)));
            Assert.False(expected.IsBetween(expected.AddMilliseconds(1), expected.AddMilliseconds(2)));

            //Test when limits is swap
            Assert.False(expected.IsBetween(expected.AddHours(-1), expected.AddHours(-2)));
            Assert.False(expected.IsBetween(expected.AddHours(2), expected.AddHours(1)));
           

        }

        [Fact]
        public void Date_Is_End_Of_Day()
        {
            var today = DateTime.UtcNow;

            var expected = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59, 999);

            Assert.Equal(expected.Ticks, today.EndOfDay().Ticks);
        }

        [Fact]
        public void Date_Is_Begin_Of_Day()
        {
            var today = DateTime.Now;

            var expected = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);

            Assert.Equal(expected, today.BeginningOfDay());
        }


    }
}
