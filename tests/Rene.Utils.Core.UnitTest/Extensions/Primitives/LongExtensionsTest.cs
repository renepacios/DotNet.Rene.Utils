using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Extensions.Primitives;

public class LongExtensionsTest
{
    #region ToReadableSize

    [Theory]
    [InlineData(0, "0 bytes")]
    [InlineData(1, "1 bytes")]
    [InlineData(512, "512 bytes")]
    [InlineData(1023, "1023 bytes")]
    public void ToReadableSize_Bytes_Should_Be_As_Expected(long sizeInBytes, string expected)
    {
        // Act
        var result = sizeInBytes.ToReadableSize(CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1024, "1.00 Kb")]
    [InlineData(1536, "1.50 Kb")]
    [InlineData(2048, "2.00 Kb")]
    [InlineData(10240, "10.00 Kb")]
    [InlineData(1048575, "1024.00 Kb")] // Just below 1 MB
    public void ToReadableSize_Kilobytes_Should_Be_As_Expected(long sizeInBytes, string expected)
    {
        // Act
        var result = sizeInBytes.ToReadableSize(CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1048576, "1.00 Mb")]     // 1024 * 1024
    [InlineData(2097152, "2.00 Mb")]       // 2 * 1024 * 1024
    [InlineData(5242880, "5.00 Mb")]     // 5 * 1024 * 1024
    [InlineData(10485760, "10.00 Mb")]     // 10 * 1024 * 1024
    [InlineData(1073741823, "1024.00 Mb")] // Just below 1 GB
    public void ToReadableSize_Megabytes_Should_Be_As_Expected(long sizeInBytes, string expected)
    {
        // Act
        var result = sizeInBytes.ToReadableSize(CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1073741824, "1.00 Gb")]      // 1024 * 1024 * 1024
    [InlineData(2147483648, "2.00 Gb")]      // 2 * 1024 * 1024 * 1024
    [InlineData(5368709120, "5.00 Gb")]      // 5 * 1024 * 1024 * 1024
    [InlineData(10737418240, "10.00 Gb")]    // 10 * 1024 * 1024 * 1024
    [InlineData(1099511627775, "1024.00 Gb")] // Just below 1 TB
    public void ToReadableSize_Gigabytes_Should_Be_As_Expected(long sizeInBytes, string expected)
    {
        // Act
        var result = sizeInBytes.ToReadableSize(CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1099511627776, "1.00 Tb")]   // 1024 * 1024 * 1024 * 1024
    [InlineData(2199023255552, "2.00 Tb")]   // 2 * 1024 * 1024 * 1024 * 1024
    [InlineData(5497558138880, "5.00 Tb")]   // 5 * 1024 * 1024 * 1024 * 1024
    [InlineData(10995116277760, "10.00 Tb")] // 10 * 1024 * 1024 * 1024 * 1024
    public void ToReadableSize_Terabytes_Should_Be_As_Expected(long sizeInBytes, string expected)
    {
        // Act
        var result = sizeInBytes.ToReadableSize(CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ToReadableSize_NegativeValue_Should_Return_Negative_Bytes()
    {
        // Arrange
        long sizeInBytes = -1024;

        // Act
        var result = sizeInBytes.ToReadableSize(CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be("-1024 bytes");
    }

    [Fact]
    public void ToReadableSize_MaxLongValue_Should_Return_Terabytes()
    {
        // Arrange
        long sizeInBytes = long.MaxValue;

        // Act
        var result = sizeInBytes.ToReadableSize(CultureInfo.InvariantCulture);

        // Assert
        result.Should().Contain("Tb");
    }

    [Theory]
    [InlineData(1536, "1.50 Kb")]
    [InlineData(1572864, "1.50 Mb")]     // 1.5 * 1024 * 1024
    [InlineData(1610612736, "1.50 Gb")]    // 1.5 * 1024 * 1024 * 1024
    [InlineData(1649267441664, "1.50 Tb")] // 1.5 * 1024 * 1024 * 1024 * 1024
    public void ToReadableSize_DecimalValues_Should_Format_With_Two_Decimals(long sizeInBytes, string expected)
    {
        // Act
        var result = sizeInBytes.ToReadableSize(CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1025, "1.00 Kb")]    // Slightly above 1 KB
    [InlineData(1048577, "1.00 Mb")] // Slightly above 1 MB
    [InlineData(1073741825, "1.00 Gb")] // Slightly above 1 GB
    public void ToReadableSize_BoundaryValues_Should_Round_To_Next_Unit(long sizeInBytes, string expected)
    {
        // Act
        var result = sizeInBytes.ToReadableSize(CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(expected);
    }

    #endregion ToReadableSize

    #region ToReadableSize with Culture

    [Fact]
    public void ToReadableSize_WithSpanishCulture_Should_Use_Comma_As_Decimal_Separator()
    {
        // Arrange
        long sizeInBytes = 1536; // 1.5 KB
        var spanishCulture = new CultureInfo("es-ES");

        // Act
        var result = sizeInBytes.ToReadableSize(spanishCulture);

        // Assert
        result.Should().Be("1,50 Kb");
    }

    [Fact]
    public void ToReadableSize_WithEnglishCulture_Should_Use_Dot_As_Decimal_Separator()
    {
        // Arrange
        long sizeInBytes = 1536; // 1.5 KB
        var englishCulture = new CultureInfo("en-US");

        // Act
        var result = sizeInBytes.ToReadableSize(englishCulture);

        // Assert
        result.Should().Be("1.50 Kb");
    }

    [Fact]
    public void ToReadableSize_WithInvariantCulture_Should_Use_Dot_As_Decimal_Separator()
    {
        // Arrange
        long sizeInBytes = 1536; // 1.5 KB

        // Act
        var result = sizeInBytes.ToReadableSize(CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be("1.50 Kb");
    }

    [Fact]
    public void ToReadableSize_WithNullCulture_Should_Use_CurrentCulture()
    {
        // Arrange
        long sizeInBytes = 1536; // 1.5 KB

        // Act
        var result = sizeInBytes.ToReadableSize(null);

        // Assert
        // Verificamos que no lanza excepción y retorna un valor válido
        result.Should().NotBeNullOrEmpty();
        result.Should().Contain("Kb");
    }

    [Fact]
    public void ToReadableSize_WithoutCultureParameter_Should_Use_CurrentCulture()
    {
        // Arrange
        long sizeInBytes = 1024; // 1 KB

        // Act
        var result = sizeInBytes.ToReadableSize();

        // Assert
        // Verificamos que no lanza excepción y retorna un valor válido
        result.Should().NotBeNullOrEmpty();
        result.Should().Contain("Kb");
    }

    #endregion ToReadableSize with Culture
}
