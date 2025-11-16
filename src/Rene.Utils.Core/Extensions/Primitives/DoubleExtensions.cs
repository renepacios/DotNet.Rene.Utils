// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// Extension methods for Double type
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Función que devuelve un double formateado con el número de decimales que se le 
        /// indica sin redondear de ninguna manera
        /// </summary>
        /// <param name="numero">El número double a truncar</param>
        /// <param name="nDecimales">Cantidad de decimales deseados</param>
        /// <returns>Devuelve un <see cref="System.Double">Double</see> con la cantidad de decimales especificada</returns>
        public static double TruncateDecimals(this double numero, short nDecimales)
        {
            // Si nDecimales es demasiado grande, el resultado de Math.Pow puede exceder el rango de long
            // En ese caso, el número ya tiene menos decimales de los solicitados, así que lo retornamos tal cual
            if (nDecimales > 15)
            {
                return numero;
            }

            long dec;
            long num;

            dec = (long)Math.Pow(10, nDecimales);
            num = (long)(numero * dec);
            return (double)num / (double)dec;
        }
    }
}
