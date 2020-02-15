
namespace Rene.Utils.Core.CommonSources
{
    public static class Constants
    {
        public const string VOCALES_MAYUSCULAS_ACENTUADAS = "ÁÉÍÓÚ"; //"AEIOU"
        public const string VOCALES_MINUSCULAS_ACENTUADAS = "áéíóú"; //"AEIOU"
        public const string LETRAS_MAYUSCULAS = "ABCDEFGHIJKLMNñOPQRSTUVWXYZ";
        public const string LETRAS_MINUSCULAS = "abcdefghijklmnñopqrstuvwxyz";
        public const string LETRAS_MAYUSCULAS_INCLUYEACENTOS = LETRAS_MAYUSCULAS + VOCALES_MAYUSCULAS_ACENTUADAS;
        public const string LETRAS_MINUSCULAS_INCLUYEACENTOS = LETRAS_MINUSCULAS + VOCALES_MINUSCULAS_ACENTUADAS;
        public const string LETRAS = LETRAS_MAYUSCULAS + LETRAS_MINUSCULAS;
        public const string NUMEROS = "0123456789";
    }
}
