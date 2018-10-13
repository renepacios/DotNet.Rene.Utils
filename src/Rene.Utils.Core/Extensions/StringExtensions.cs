/*
 *  Copyright (C) 2018  René Pacios
 *
 *  You can use  for Personal or commercial presuppose, but you must maintain the copyright information and author
 *  This code is distributed on an "AS IS" BASIS,  * WITHOUT WARRANTIES OF ANY KIND, USE ON YOUR OWN RISK
 *
 */

using System.Text;

// ReSharper disable once CheckNamespace
namespace System
{
    public static class StringExtensions
    {
        #region Base 64

        /// <summary>
        ///     Converts string to its equivalent string that is encoded with base-64 digits.
        /// </summary>
        /// <param name="text">The string to convert</param>
        /// <returns>String encoded with base-64 equivalent to text </returns>
        public static string ToBase64(this string text)
        {
            var b = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(b);
        }

        /// <summary>
        ///     Converts the specified string, which encodes binary data as base-64 digits, to an equivalent clear text string
        /// </summary>
        /// <param name="base64String">The string to convert</param>
        /// <returns>A String that is equivalent to base64String</returns>
        public static string ToStringFromBase64(this string base64String)
        {
            var b = Convert.FromBase64String(base64String);
            return Encoding.UTF8.GetString(b);
        }

        #endregion

        #region Conversiones

        /// <summary>
        ///     Converts the string representation of a GUID to the equivalent System.Guid structure.
        /// </summary>
        /// <param name="s">The String GUID to convert</param>
        /// <returns>
        ///     A  valid System.Guid.
        /// </returns>
        public static Guid ToGuid(this string s)
        {
            Guid g;
            if (!Guid.TryParse(s, out g))
                throw new FormatException($"{s} is not a valid GUID");

            return g;
        }

        /// <summary>
        ///     Converts the string representation of a number to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="s">A string containing a number to convert</param>
        /// <returns>
        ///     Number
        ///     When this method returns, contains the 32-bit signed integer value equivalent
        ///     of the number contained in s, if the conversion succeeded, or zero if the conversion *
        ///     failed.
        /// </returns>
        public static int ToInt(this string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            int.TryParse(s.Trim(), out var salida);
            return salida;
        }

        #endregion
    }
}