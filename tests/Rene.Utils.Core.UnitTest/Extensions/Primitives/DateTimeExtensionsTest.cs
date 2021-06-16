using System;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Extensions.Primitives
{
    using FluentAssertions;

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

        [Fact]
        public void Date_Next_Day_Works_As_Should()
        {

            var monday = new DateTime(2021, 5, 31);
            var tuesday = new DateTime(2021, 6, 1);
            var wednesday = new DateTime(2021, 6, 2);
            var thursday = new DateTime(2021, 6, 3);
            var friday = new DateTime(2021, 6, 4);
            var saturday = new DateTime(2021, 6, 5);
            var sunday = new DateTime(2021, 6, 6);

            monday.Next(DayOfWeek.Monday)
                .Should()
                .Be(monday.AddDays(7));


            wednesday.Next(DayOfWeek.Tuesday)
                .Should()
                .Be(tuesday.AddDays(7));

            thursday.Next(DayOfWeek.Friday)
                .Should()
                .Be(friday);

            sunday.Next(DayOfWeek.Monday)
                .Should()
                .Be(monday.AddDays(7));

        }

    }
}
