using System;
using System.Diagnostics;
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
        public static bool IsValidEmailAddress(this string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    return false;

                var rg = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
                return rg.IsMatch(email);
            }
            catch (Exception e)
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
        public static bool IsValidUri(this string uri)
        {
            if (string.IsNullOrEmpty(uri))
                return false;

            if (uri.IndexOf(".", StringComparison.OrdinalIgnoreCase) == -1)
                return false;

            //http://msdn.microsoft.com/en-us/library/system.uri.scheme(v=vs.110).aspx
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

            var hasValidSchema = schemes.Any(s => uri.StartsWith(s, StringComparison.OrdinalIgnoreCase));

            if (!hasValidSchema)
                uri = "http://" + uri;

            return Uri.IsWellFormedUriString(uri, UriKind.Absolute);
        }
    }
}
