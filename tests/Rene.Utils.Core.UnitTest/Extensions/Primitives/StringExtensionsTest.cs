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


        [Fact]
        public void ToGuidOrDefault_Convert()
        {
            var strGuid = "DDADCD3F-A494-474C-87AA-D66D882879A0";
            // {DDADCD3F-A494-474C-87AA-D66D882879A0}
            var expected = new Guid(0xddadcd3f, 0xa494, 0x474c, 0x87, 0xaa, 0xd6, 0x6d, 0x88, 0x28, 0x79, 0xa0);

            var result = strGuid.ToGuidOrDefault();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToGuidOrDefault_BadFormatGuid()
        {
            var strGuid = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
            Guid expected = Guid.Empty;

            var result = strGuid.ToGuidOrDefault();

            result.Should().Be(expected);
        }

        [Fact]
        public void ToGuidOrDefaultWithDefaultValue_BadFormatGuid()
        {
            var strGuid = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";

            Guid defaultValue = Guid.Parse("032aafff-dcc9-4d27-86bc-d8a7de04114b");
            Guid expected = defaultValue;

            var result = strGuid.ToGuidOrDefault(defaultValue);

            result.Should().Be(expected);

        }


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

        #region ContainsAnyArray

        [Fact]
        public void ContainsAnyArray_Should_Be_As_Spectated()
        {
            var input = "Hello World";
            var result = input.ContainsAny(new[] { "Hello", "Universe" });
            result.Should().BeTrue();
        }

        [Fact]
        public void ContainsAnyArray_Should_Be_False()
        {
            var input = "Hello World";
            var result = input.ContainsAny(new[] { "Universe", "Galaxy" });
            result.Should().BeFalse();
        }

        [Fact]
        public void ContainsAnyArray_NullOrEmptyString_Should_Be_False()
        {
            string input = null;
            var result = input.ContainsAny(new[] { "Universe", "Galaxy" });
            result.Should().BeFalse();

            input = string.Empty;
            var result_1 = input.ContainsAny(new[] { "Universe", "Galaxy" });
            result_1.Should().BeFalse();
        }

        [Fact]
        public void ContainsAnyArray_NullOrEmptyArray_Should_Be_False()
        {
            var input = "Hello World";

            Action act1 = () => input.ContainsAny(null);
            act1.Should()
                .Throw<ArgumentException>();
                //.WithMessage(ExceptionMessages.ArrayNullOrEmptyArgumentFormat) // opcional: verificar el mensaje

            Action act2 = () => input.ContainsAny(Array.Empty<string>());
            act2.Should()
                .Throw<ArgumentException>();
                //.WithMessage(ExceptionMessages.ArrayNullOrEmptyArgumentFormat);
        }

        [Fact]
        public void ContainsAnyArray_Both_NullOrEmpty_Should_Be_False()
        {
            string input = null;
            var result = input.ContainsAny(null);
            result.Should().BeFalse();
            input = string.Empty;
            var result_1 = input.ContainsAny(Array.Empty<string>());
            result_1.Should().BeFalse();
        }



        #endregion

        #region AddSpacesToSentence

        public class StringExtensions_AddSpacesToSentence_Tests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("   ")]
            public void Returns_Empty_For_Null_Or_Whitespace(string input)
            {
                // Act
                var result = input.AddSpacesToSentence();

                // Assert
                result.Should().BeEmpty();
            }

            [Theory]
            [InlineData("A", "A")]
            [InlineData("a", "a")]
            [InlineData("NoUpper", "No Upper")]
            [InlineData("myTest", "my Test")]
            [InlineData("MyTestVariable", "My Test Variable")]
            [InlineData("HelloWorld!", "Hello World!")]
            public void Inserts_Space_Before_Uppercase_When_Preceding_Is_Not_Space(string input, string expected)
            {
                // Act
                var result = input.AddSpacesToSentence();

                // Assert
                result.Should().Be(expected);
            }

            [Theory]
            [InlineData("Already Spaced", "Already Spaced")]
            [InlineData("This  Is", "This  Is")] // conserva espacios dobles ya existentes
            [InlineData(" LeadingSpace", " Leading Space")] // agrega espacio antes de 'S' si procede
            public void Preserves_Existing_Spaces(string input, string expected)
            {
                // Act
                var result = input.AddSpacesToSentence();

                // Assert
                result.Should().Be(expected);
            }

            [Theory]
            [InlineData("HTMLParser", "H T M L Parser")]
            [InlineData("JSON", "J S O N")]
            [InlineData("XMLErrorCode", "X M L Error Code")]
            public void Splits_Acronyms_Into_Individual_Letters_With_Spaces(string input, string expected)
            {
                // Act
                var result = input.AddSpacesToSentence();

                // Assert
                result.Should().Be(expected);
            }

            [Theory]
            [InlineData("number9Test", "number9 Test")]
            [InlineData("End2EndTest", "End2 End Test")]
            public void Leaves_Digits_And_NonLetters_Intact_Only_Adds_Before_Uppercase(string input, string expected)
            {
                // Act
                var result = input.AddSpacesToSentence();

                // Assert
                result.Should().Be(expected);
            }

            [Fact]
            public void Does_Not_Remove_Or_Change_Characters_Other_Than_Adding_Spaces_Before_Uppers()
            {
                // Arrange
                var inputs = new[]
                {
                "MyTestVariable",
                "Already Spaced",
                "HelloWorld!",
                "A",
                "myTest",
                "HTMLParser"
            };

                foreach (var input in inputs)
                {
                    // Act
                    var result = input.AddSpacesToSentence();

                    // Assert: si quitamos espacios, debe quedar igual que el original sin espacios
                    result.Replace(" ", string.Empty)
                          .Should().Be(input.Replace(" ", string.Empty),
                              $"the function should not alter non-space characters for '{input}'");
                }
            }
        }

        #endregion

    }
}