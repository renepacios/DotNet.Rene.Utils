using FluentAssertions;
using System;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Extensions.Primitives;

public class DoubleExtensionsTest
{
    #region TruncateDecimals

    [Theory]
    [InlineData(3.14159, 0, 3.0)]
    [InlineData(3.14159, 1, 3.1)]
    [InlineData(3.14159, 2, 3.14)]
    [InlineData(3.14159, 3, 3.141)]
    [InlineData(3.14159, 4, 3.1415)]
    [InlineData(3.14159, 5, 3.14159)]
    public void TruncateDecimals_PositiveNumber_Should_Truncate_Without_Rounding(double numero, short nDecimales, double expected)
    {
   // Act
        var result = numero.TruncateDecimals(nDecimales);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-3.14159, 0, -3.0)]
    [InlineData(-3.14159, 1, -3.1)]
    [InlineData(-3.14159, 2, -3.14)]
    [InlineData(-3.14159, 3, -3.141)]
    [InlineData(-3.14159, 4, -3.1415)]
    [InlineData(-3.14159, 5, -3.14159)]
    public void TruncateDecimals_NegativeNumber_Should_Truncate_Without_Rounding(double numero, short nDecimales, double expected)
    {
   // Act
        var result = numero.TruncateDecimals(nDecimales);

   // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void TruncateDecimals_Zero_Decimals_Should_Return_Integer_Part()
  {
        // Arrange
  double numero = 123.456789;
        short nDecimales = 0;

        // Act
var result = numero.TruncateDecimals(nDecimales);

    // Assert
        result.Should().Be(123.0);
    }

    [Fact]
    public void TruncateDecimals_Should_Not_Round_Up()
    {
        // Arrange
        double numero = 1.9999;
        short nDecimales = 2;

        // Act
        var result = numero.TruncateDecimals(nDecimales);

        // Assert
   result.Should().Be(1.99);
    result.Should().NotBe(2.0); // Verifica que NO redondea
    }

    [Fact]
    public void TruncateDecimals_Should_Not_Round_Down()
    {
        // Arrange
      double numero = 1.111;
        short nDecimales = 2;

        // Act
     var result = numero.TruncateDecimals(nDecimales);

        // Assert
        result.Should().Be(1.11);
    }

    [Theory]
    [InlineData(0.0, 0, 0.0)]
    [InlineData(0.0, 2, 0.0)]
    [InlineData(0.0, 5, 0.0)]
    public void TruncateDecimals_Zero_Should_Return_Zero(double numero, short nDecimales, double expected)
    {
        // Act
    var result = numero.TruncateDecimals(nDecimales);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(123.456, 10, 123.456)]
    [InlineData(1.5, 20, 1.5)]
    public void TruncateDecimals_More_Decimals_Than_Available_Should_Return_Same_Number(double numero, short nDecimales, double expected)
    {
        // Act
  var result = numero.TruncateDecimals(nDecimales);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(999999.999999, 0, 999999.0)]
    [InlineData(999999.999999, 2, 999999.99)]
    [InlineData(999999.999999, 6, 999999.999999)]
    public void TruncateDecimals_Large_Numbers_Should_Work_Correctly(double numero, short nDecimales, double expected)
    {
   // Act
        var result = numero.TruncateDecimals(nDecimales);

        // Assert
        result.Should().Be(expected);
 }

    [Theory]
    [InlineData(0.123456, 0, 0.0)]
    [InlineData(0.123456, 1, 0.1)]
    [InlineData(0.123456, 2, 0.12)]
    [InlineData(0.123456, 3, 0.123)]
    [InlineData(0.123456, 4, 0.1234)]
    public void TruncateDecimals_Small_Numbers_Less_Than_One_Should_Work_Correctly(double numero, short nDecimales, double expected)
    {
        // Act
        var result = numero.TruncateDecimals(nDecimales);

      // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1.5555, 2, 1.55)]
    [InlineData(2.6666, 2, 2.66)]
    [InlineData(3.7777, 2, 3.77)]
    [InlineData(4.8888, 2, 4.88)]
    [InlineData(5.9999, 2, 5.99)]
  public void TruncateDecimals_Numbers_That_Would_Round_Up_Should_Truncate_Instead(double numero, short nDecimales, double expected)
    {
 // Act
        var result = numero.TruncateDecimals(nDecimales);

        // Assert
        result.Should().Be(expected);
    }

  [Fact]
    public void TruncateDecimals_Integer_Number_Should_Return_Same_Value()
    {
        // Arrange
        double numero = 42.0;
        short nDecimales = 2;

  // Act
        var result = numero.TruncateDecimals(nDecimales);

        // Assert
        result.Should().Be(42.0);
    }

    [Theory]
    [InlineData(10.005, 2, 10.0)]  // Importante: trunca, no redondea
    [InlineData(10.015, 2, 10.01)]
    [InlineData(10.025, 2, 10.02)]
    [InlineData(10.095, 2, 10.09)]
  public void TruncateDecimals_Edge_Cases_With_Five_Should_Truncate_Not_Round(double numero, short nDecimales, double expected)
    {
        // Act
        var result = numero.TruncateDecimals(nDecimales);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void TruncateDecimals_One_Decimal_Should_Be_As_Expected()
    {
 // Arrange
      double numero = 123.456789;
  short nDecimales = 1;

   // Act
     var result = numero.TruncateDecimals(nDecimales);

        // Assert
      result.Should().Be(123.4);
    }

    [Theory]
    [InlineData(-0.123456, 2, -0.12)]
    [InlineData(-0.999999, 2, -0.99)]
    [InlineData(-1.999, 1, -1.9)]
    public void TruncateDecimals_Negative_Decimal_Numbers_Should_Work_Correctly(double numero, short nDecimales, double expected)
    {
        // Act
      var result = numero.TruncateDecimals(nDecimales);

     // Assert
 result.Should().Be(expected);
    }

    [Theory]
    [InlineData(100.0, 0, 100.0)]
    [InlineData(100.0, 1, 100.0)]
    [InlineData(100.0, 2, 100.0)]
    public void TruncateDecimals_Whole_Numbers_Should_Remain_Same(double numero, short nDecimales, double expected)
    {
        // Act
   var result = numero.TruncateDecimals(nDecimales);

        // Assert
    result.Should().Be(expected);
    }

    #endregion TruncateDecimals
}
