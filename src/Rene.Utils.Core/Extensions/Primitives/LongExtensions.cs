using System.Globalization;

#pragma warning disable CA1305
// ReSharper disable once CheckNamespace
namespace System
{
    public static class LongExtensions
    {
        // Con estas constantes evitamos hacer uso de Math.Pow, mejorando el rendimiento
        private const double KB = 1024.0;
        private const double MB = 1024.0 * 1024.0;
        private const double GB = 1024.0 * 1024.0 * 1024.0;
        private const double TB = 1024.0 * 1024.0 * 1024.0 * 1024.0;

        /// <summary>
        /// Convierte un tamaño en bytes a un formato legible (KB, MB, GB, TB)
        /// </summary>
        /// <param name="sizeInBytes">Tamaño en bytes</param>
        /// <returns>Cadena formateada con el tamaño legible usando la cultura del sistema</returns>
        public static string ToReadableSize(this long sizeInBytes)
        {
            return sizeInBytes.ToReadableSize(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convierte un tamaño en bytes a un formato legible (KB, MB, GB, TB)
        /// </summary>
        /// <param name="sizeInBytes">Tamaño en bytes</param>
        /// <param name="culture">Cultura a utilizar para el formateo. Si es null, usa la cultura del sistema</param>
        /// <returns>Cadena formateada con el tamaño legible</returns>
        public static string ToReadableSize(this long sizeInBytes, CultureInfo culture)
        {
            var formatCulture = culture ?? CultureInfo.CurrentCulture;

            if (sizeInBytes >= TB)
                return (sizeInBytes / TB).ToString("0.00", formatCulture) + " Tb";
            else if (sizeInBytes >= GB)
                return (sizeInBytes / GB).ToString("0.00", formatCulture) + " Gb";
            else if (sizeInBytes >= MB)
                return (sizeInBytes / MB).ToString("0.00", formatCulture) + " Mb";
            else if (sizeInBytes >= KB)
                return (sizeInBytes / KB).ToString("0.00", formatCulture) + " Kb";
            else
                return sizeInBytes + " bytes";
        }
    }

}
