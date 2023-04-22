// ReSharper disable IdentifierTypo
namespace Rene.Utils.Core.UnitTest.CommonSources
{
    using Core.CommonSources;
    using FluentAssertions;
    using Xunit;

    public class ConstantsTest
    {
        [Fact]
        public void VOCALES_MAYUSCULAS_ACENTUADAS() => Assert.Equal("ÁÉÍÓÚ", Constants.VOCALES_MAYUSCULAS_ACENTUADAS);

        [Fact]
        public void VOCALES_MINUSCULAS_ACENTUADAS() => Assert.Equal("áéíóú", Constants.VOCALES_MINUSCULAS_ACENTUADAS); 

        [Fact]
        public void LETRAS_MAYUSCULAS() => Assert.Equal("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ", Constants.LETRAS_MAYUSCULAS);

        [Fact]
        public void LETRAS_MINUSCULAS() => Assert.Equal("abcdefghijklmnñopqrstuvwxyz", Constants.LETRAS_MINUSCULAS);
        [Fact]
        public void LETRAS_MAYUSCULAS_INCLUYEACENTOS() => Assert.Equal("ABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚ", Constants.LETRAS_MAYUSCULAS_INCLUYEACENTOS); 
        [Fact]
        public void LETRAS_MINUSCULAS_INCLUYEACENTOS() => Assert.Equal("abcdefghijklmnñopqrstuvwxyzáéíóú", Constants.LETRAS_MINUSCULAS_INCLUYEACENTOS);
        [Fact]
        public void LETRAS() => Assert.Equal("ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz", Constants.LETRAS);
        [Fact]
        public void NUMEROS() => Assert.Equal("0123456789", Constants.NUMEROS);

        [Fact]
        public void BASE64_CARS() => Constants.BASE64_CARS_PERMITIDOS.Should().Be("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/");
    }
}
