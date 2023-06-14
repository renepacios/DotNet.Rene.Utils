using System;

namespace Rene.Utils.Core.Security
{
    //inspired https://jonathancrozier.com/blog/base64-url-encoding-using-c-sharp 
    public static class UrlEncoder
    {
        private static readonly char[] padding = { '=' };

        public static string EncodeFromBase64(string base64String)
        {
            if (string.IsNullOrEmpty(base64String)) throw new ArgumentNullException(nameof(base64String));

            return base64String.TrimEnd(padding).Replace('+', '-').Replace('/', '_');
        }

        public static string DecodeToBase64(string encodeBase64String)
        {
            if (string.IsNullOrEmpty(encodeBase64String)) throw new ArgumentNullException(nameof(encodeBase64String));

            var decodeWithoutPad = encodeBase64String.Replace('-', '+').Replace('_', '/');

            var pad = (decodeWithoutPad.Length % 4) switch
            {
                2 => "==",
                3 => "=",
                _ => string.Empty
            };

            return $"{decodeWithoutPad}{pad}";
        }

    }
}
