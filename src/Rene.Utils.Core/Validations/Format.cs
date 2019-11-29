using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rene.Utils.Core.Validations
{
    public static class Format
    {
        /// <summary>
        /// Validate is a validad e-mail address
        /// </summary>
        /// <param name="email">email to validate</param>
        /// <returns>> true if the email has a correct format; otherwise, false. </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "")]
        public static bool IsValidEmailAddress(this string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    return false;

                var rg = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
                return rg.IsMatch(email);
            }
            catch (Exception)
            {
                // Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Validate an uri
        /// </summary>
        /// <param name="uri">uri to validate</param>
        /// <returns>is valid uri</returns>
        public static bool IsValidUri(this System.Uri uri)
        {
            return uri != null && uri.ToString().IsValidUri();
        }

        /// <summary>
        /// Validate an url
        /// </summary>
        /// <param name="url">url to validate</param>
        /// <returns>is valid url</returns>
        public static bool IsValidUri(this string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;
            if (url.IndexOf(".", StringComparison.OrdinalIgnoreCase) == -1)
                return false;

            //http://msdn.microsoft.com/en-us/library/system.url.scheme(v=vs.110).aspx
            var schemes = new[]
            {
                "file",
                "ftp",
                "gopher",
                "http",
                "https",
                "ldap",
                "mailto",
                "net.pipe",
                "net.tcp",
                "news",
                "nntp",
                "telnet",
                "uuid"
            };

            var hasValidSchema = schemes.Any(s => url.StartsWith(s, StringComparison.OrdinalIgnoreCase));

            if (!hasValidSchema)
                url = "http://" + url;

            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
    }
}
