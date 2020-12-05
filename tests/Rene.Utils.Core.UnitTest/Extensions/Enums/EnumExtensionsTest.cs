namespace Rene.Utils.Core.UnitTest.Extensions.Enums
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Xunit;

    public class EnumExtensionsTest
    {
        private const string First = nameof(First);
        private const string Second = nameof(Second);

        enum MyEnum
        {
            Zero = 0,
            [Description(First)] One = 1,
            [Description(Second)] Two = 2,

        }

        [Fact]
        public void ToDisplayValue_Should_As_Expected()
        {
            var zero = MyEnum.Zero;
            var one = MyEnum.One;
            var two = MyEnum.Two;

            ((int)zero)
                .Should()
                .Be(0);

            zero.ToString()
                .Should()
                .NotBeNullOrEmpty()
                .And.Be(nameof(MyEnum.Zero));

            zero.ToDisplayValue()
                .Should()
                .NotBeNullOrEmpty()
                .And.Be(nameof(MyEnum.Zero), "It's not description attribute");


            ((int)one)
                .Should()
                .Be(1);

            one.ToString()
                .Should()
                .NotBeNullOrEmpty()
                .And.Be(nameof(MyEnum.One));

            one.ToDisplayValue()
                .Should()
                .NotBeNullOrEmpty()
                .And.Be(First, "One Enum description attribute (First)");



            ((int)two)
                .Should()
                .Be(2);



        }
        
        [Fact]
        public void EnumHelper_Parse_Should_As_Expected()
        {
            EnumSource<MyEnum>.Parse("Zero")
                .Should()
                .Be(MyEnum.Zero);



            EnumSource<MyEnum>.Parse("One")
                .Should()
                .Be(MyEnum.One, "Enum with Description attribute parse from enum string name");


            EnumSource<MyEnum>.Parse("ZERO")
                .Should()
                .Be(MyEnum.Zero, "Enum parse works ignore case mode");

            EnumSource<MyEnum>.Parse("one")
                .Should()
                .Be(MyEnum.One, "Enum parse works ignore case mode");

        }

        [Fact]
        public void EnumHelper_GetValues_Should_As_Expected()
        {
            EnumSource<MyEnum>
                .GetValues()
                .Should()
                .NotBeEmpty()
                .And.Equal(new List<MyEnum>
                {
                    MyEnum.Zero,
                    MyEnum.One,
                    MyEnum.Two
                });
        }

        [Fact]
        public void EnumHelper_GetNames_Should_As_Expected()
        {
            EnumSource<MyEnum>
                .GetNames()
                .Should()
                .NotBeEmpty()
                .And.Equal(new List<string>
                {
                    nameof(MyEnum.Zero),
                    nameof(MyEnum.One),
                    nameof(MyEnum.Two)
                });
        }


        [Fact]
        public void EnumHelper_GetDisplayValues_Should_As_Expected()
        {
            EnumSource<MyEnum>
                .GetDisplayValues()
                .Should()
                .NotBeEmpty()
                .And.Equal(new List<string>
                {
                    nameof(MyEnum.Zero),
                   First,
                    Second
                });
        }



        [Fact]
        public void EnumHelper_GetNameValueDescriptions_Should_As_Expected()
        {
            EnumSource<MyEnum>
                .GetNameValueDescriptions()
                .Should()
                .NotBeEmpty()
                .And.Equal(new List<(int, string, string)>
                {
                  (0,MyEnum.Zero.ToString(),MyEnum.Zero.ToString()),
                  (1,MyEnum.One.ToString(),First),
                  (2,MyEnum.Two.ToString(),Second),
                });
        }



    }
}
