using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Extensions.Primitives
{
    using Common.Types;
    using Resources;

    public class StringExtensionsTest
    {
        #region Base64

        [Fact]
        public void FromBase64_Convert()
        {
            const string base64Input = "SGVsbG8gV29ybGQhISE=";
            const string expected = "Hello World!!!";

            var result = base64Input.ToStringFromBase64();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToBase64_Convert()
        {
            const string strInput = "Hello World!!!";
            const string expected = "SGVsbG8gV29ybGQhISE=";

            var result = strInput.ToBase64();

            Assert.Equal(expected, result);
        }

#endregion

        #region ToGuid

        [Fact]
        public void ToGuid_Convert()
        {
            var strGuid = "DDADCD3F-A494-474C-87AA-D66D882879A0";
            // {DDADCD3F-A494-474C-87AA-D66D882879A0}
            var expected = new Guid(0xddadcd3f, 0xa494, 0x474c, 0x87, 0xaa, 0xd6, 0x6d, 0x88, 0x28, 0x79, 0xa0);

            var result = strGuid.ToGuid();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToGuid_Detect_BadFormatGuid()
        {
            var strGuid = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
            var expected = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";

            //Guid result=Guid.Empty;
            Action act = () => strGuid.ToGuid();

            Exception ex = Assert.Throws<FormatException>(act);

            Assert.Equal($"{strGuid} is not a valid GUID", ex.Message);
            Assert.Equal(expected, strGuid);
        }
        
        #endregion ToGuid
        
        #region ToInt
        [Fact]
        public void ToInt_DefaultValue_Must_Be_Zero()
        {
            var result = "a".ToInt();
            Assert.Equal(0, result);

            var result_1 = "-1.3".ToInt();
            Assert.Equal(0, result_1);
        }

        [Fact]
        public void ToInt_Must_Be_Int()
        {
            var result = "1".ToInt();
            Assert.Equal(1, result);

            var result_1 = "-1".ToInt();
            Assert.Equal(-1, result_1);
        }

        [Fact]
        public void ToInt_NullOrEmptyString_Must_Be_Zero()
        {
            var result = string.Empty.ToInt();
            Assert.Equal(0, result);

            var result_1 = StringExtensions.ToInt(null);
            Assert.Equal(0, result_1);
        }

        #endregion ToInt

        #region SplitTo
        [Fact]
        public void SplitTo_Should_Be_As_Spectated()
        {
            var input = "a,b,c";
            var result = input.SplitTo<string>(',');

            result
                .Should()
                .NotBeNullOrEmpty()
                .And
                .BeAssignableTo<IEnumerable<string>>()
                .And
                .ContainInOrder("a", "b", "c")
                .And
                .HaveCount(3)
                ;
        }


        [Fact]
        public void SplitTo_Null_String_Should_Be_As_Spectated()
        {
            string input = null;
            var result = input.SplitTo<string>(',');

            result
                .Should()
                .NotBeNull()
                .And
                .BeAssignableTo<IEnumerable<string>>()
                .And
                .BeEmpty()
                ;
        }



        [Fact]
        public void SplitTo_Empty_String_Should_Be_As_Spectated()
        {
            string input = string.Empty;
            var result = input.SplitTo<string>(',');

            result
                .Should()
                .NotBeNull()
                .And
                .BeAssignableTo<IEnumerable<string>>()
                .And
                .BeEmpty()
                ;
        }

        #endregion SplitTo

        #region ToEnum

        [Fact]
        public void ToEnum_ValidString_Should_Be_As_Spectated()
        {
            string input = "One";

            var result = input.ToEnum<EnumSample>();

            result.Should()
                .BeAssignableTo<EnumSample>()
                .And.Be(EnumSample.One);


        }

        [Fact]
        public void ToEnum_ValidString_IgnoreCase_Should_Be_As_Spectated()
        {


            "ONE".ToEnum<EnumSample>()

            .Should()
                .BeAssignableTo<EnumSample>()
                .And.Be(EnumSample.One);



            "one".ToEnum<EnumSample>()

           .Should()
               .BeAssignableTo<EnumSample>()
               .And.Be(EnumSample.One);



            "oNe".ToEnum<EnumSample>()

                .Should()
                .BeAssignableTo<EnumSample>()
                .And.Be(EnumSample.One);

        }


        [Fact]
        public void ToEnum_InvalidString_Should_Be_As_Spectated()
        {
            string input = null;


            //I prefer use AAA 

            Action act = () => input.ToEnum<EnumSample>();
            act.Should()
                .Throw<FormatException>()
                .WithMessage(ExceptionMessages.StringNullArgumentFormat);

            "".Invoking(s => s.ToEnum<EnumSample>())
                .Should()
                .Throw<FormatException>()
                .WithMessage(ExceptionMessages.StringNullArgumentFormat);

        }

        [Fact]
        public void ToEnum_InvalidStringValue__Should_Be_As_Spectated()
        {
            string input = "Ten";


            //I prefer use AAA 

            Action act = () => input.ToEnum<EnumSample>();
            act.Should()
                .Throw<ArgumentException>();

        }

        #endregion ToEnum
    }
}