using System;
using FluentAssertions;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Extensions.Primitives;

public class StringExtensionsBase64Test
{



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

    
    [Fact]
    public void ToByteArrayFromBase64_Convert()
    {
        string base64Input = StringExtensionsBuilder.Base64SampleImage;
        byte[] expected = StringExtensionsBuilder.Base64SampleImageBytes;
        var result = base64Input.ToByteArrayFromBase64();
        result.Should().Equal(expected);

    }
    [Fact]
    public void ToByteArrayFromBase64_Convert_Invalid()
    {
        Action act = () => "".ToByteArrayFromBase64();
        act.Should().Throw<ArgumentException>();
        act = () => "invalid".ToByteArrayFromBase64();
        act.Should().Throw<FormatException>();
    }

    [Fact]
    public void ToByteArrayFromBase64_Convert_Null()
    {
        Action act = () => ((string?)null)!.ToByteArrayFromBase64();
        act.Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void ToByteArrayFromBase64_Convert_Empty()
    {
        Action act = () => string.Empty.ToByteArrayFromBase64();
        act.Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void ToByteArrayFromBase64_Convert_Whitespace()
    {
        Action act = () => "   ".ToByteArrayFromBase64();
        act.Should().Throw<FormatException>();
    }
}