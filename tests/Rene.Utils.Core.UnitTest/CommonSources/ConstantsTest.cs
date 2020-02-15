// ReSharper disable IdentifierTypo
namespace Rene.Utils.Core.UnitTest.CommonSources
{
    using Core.CommonSources;
    using Xunit;

    public class ConstantsTest
    {
        [Fact]
        public void VOCALES_MAYUSCULAS_ACENTUADAS() => Assert.Equal("ÁÉÍÓÚ", Constants.VOCALES_MAYUSCULAS_ACENTUADAS);

        [Fact]
        public void VOCALES_MINUSCULAS_ACENTUADAS() => Assert.Equal("áéíóú", Constants.VOCALES_MINUSCULAS_ACENTUADAS); 

        [Fact]
        public void LETRAS_MAYUSCULAS() => Assert.Equal("ABCDEFGHIJKLMNñOPQRSTUVWXYZ", Constants.LETRAS_MAYUSCULAS);

        [Fact]
        public void LETRAS_MINUSCULAS() => Assert.Equal("abcdefghijklmnñopqrstuvwxyz", Constants.LETRAS_MINUSCULAS);
        [Fact]
        public void LETRAS_MAYUSCULAS_INCLUYEACENTOS() => Assert.Equal("ABCDEFGHIJKLMNñOPQRSTUVWXYZÁÉÍÓÚ", Constants.LETRAS_MAYUSCULAS_INCLUYEACENTOS); 
        [Fact]
        public void LETRAS_MINUSCULAS_INCLUYEACENTOS() => Assert.Equal("abcdefghijklmnñopqrstuvwxyzáéíóú", Constants.LETRAS_MINUSCULAS_INCLUYEACENTOS);
        [Fact]
        public void LETRAS() => Assert.Equal("ABCDEFGHIJKLMNñOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz", Constants.LETRAS);
        [Fact]
        public void NUMEROS() => Assert.Equal("0123456789", Constants.NUMEROS);
    }
}
